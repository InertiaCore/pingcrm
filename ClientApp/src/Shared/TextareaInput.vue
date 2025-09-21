<template>
    <div :class="$attrs.class">
        <label v-if="label" class="form-label" :for="id">{{ label }}:</label>
        <textarea
            :id="id"
            ref="input"
            v-bind="{ ...$attrs, class: null }"
            class="form-textarea"
            :class="{ error: error }"
            :value="modelValue"
            @input="
                $emit(
                    'update:modelValue',
                    ($event.target as HTMLTextAreaElement).value,
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
    error?: string;
    label?: string;
    modelValue?: string;
}

withDefaults(defineProps<Props>(), {
    id: () => `textarea-input-${uuid()}`,
});

// Define emits
defineEmits<{
    'update:modelValue': [value: string];
}>();

// Template ref
const input = ref<HTMLTextAreaElement>();

// Methods
const focus = () => {
    input.value?.focus();
};

const select = () => {
    input.value?.select();
};

// Export methods for external access
defineExpose({
    focus,
    select,
});
</script>
