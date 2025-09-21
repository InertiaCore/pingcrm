<template>
    <button type="button" @click="show = true">
        <slot />
        <teleport v-if="show" to="#dropdown">
            <div>
                <div
                    style="
                        position: fixed;
                        top: 0;
                        right: 0;
                        left: 0;
                        bottom: 0;
                        z-index: 99998;
                        background: black;
                        opacity: 0.2;
                    "
                    @click="show = false"
                />
                <div
                    ref="dropdown"
                    style="position: absolute; z-index: 99999"
                    @click.stop="show = !autoClose"
                >
                    <slot name="dropdown" />
                </div>
            </div>
        </teleport>
    </button>
</template>

<script setup lang="ts">
import { createPopper, type Instance } from '@popperjs/core';
import {
    getCurrentInstance,
    nextTick,
    onMounted,
    onUnmounted,
    ref,
    watch,
} from 'vue';
import type { DropdownProps } from './types';

const props = withDefaults(defineProps<DropdownProps>(), {
    placement: 'bottom-end',
    autoClose: true,
});

// Reactive state
const show = ref(false);
const dropdown = ref<HTMLElement>();
let popper: Instance | null = null;

// Get current instance for $el access
const instance = getCurrentInstance();

// Watch show state to manage popper
watch(show, (newShow) => {
    if (newShow) {
        nextTick(() => {
            if (instance?.proxy?.$el && dropdown.value) {
                popper = createPopper(instance.proxy.$el, dropdown.value, {
                    placement: props.placement,
                    modifiers: [
                        {
                            name: 'preventOverflow',
                            options: {
                                altBoundary: true,
                            },
                        },
                    ],
                });
            }
        });
    } else if (popper) {
        setTimeout(() => {
            popper?.destroy();
            popper = null;
        }, 100);
    }
});

// Handle escape key
const handleKeydown = (e: KeyboardEvent) => {
    if (e.key === 'Escape') {
        show.value = false;
    }
};

onMounted(() => {
    document.addEventListener('keydown', handleKeydown);
});

onUnmounted(() => {
    document.removeEventListener('keydown', handleKeydown);
    if (popper) {
        popper.destroy();
    }
});
</script>
