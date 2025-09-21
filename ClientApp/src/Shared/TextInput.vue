<template>
    <div :class="$attrs.class">
        <label v-if="label" class="form-label" :for="id">{{ label }}:</label>
        <input
            :id="id"
            ref="input"
            v-bind="{ ...$attrs, class: null }"
            class="form-input"
            :class="{ error: error }"
            :type="type"
            :value="modelValue"
            @input="
                $emit(
                    'update:modelValue',
                    ($event.target as HTMLInputElement).value,
                )
            "
        />
        <div v-if="error" class="form-error">{{ error }}</div>
    </div>
</template>

<script setup lang="ts">
import { v4 as uuid } from 'uuid';
import { ref } from 'vue';

// Define props with types
interface Props {
    id?: string;
    type?: string;
    error?: string;
    label?: string;
    modelValue?: string;
}

withDefaults(defineProps<Props>(), {
    id: () => `text-input-${uuid()}`,
    type: 'text',
});

// Define emits
defineEmits<{
    'update:modelValue': [value: string];
}>();

// Template ref
const input = ref<HTMLInputElement>();

// Methods
const focus = () => {
    input.value?.focus();
};

const select = () => {
    input.value?.select();
};

const setSelectionRange = (start: number, end: number) => {
    input.value?.setSelectionRange(start, end);
};

// Export methods for external access
defineExpose({
    focus,
    select,
    setSelectionRange,
});
</script>
