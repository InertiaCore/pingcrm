<template>
  <div :class="$attrs.class">
    <label v-if="label" class="form-label" :for="id">{{ label }}:</label>
    <select :id="id" ref="input" v-model="selected" v-bind="{ ...$attrs, class: null }" class="form-select" :class="{ error: error }">
      <slot />
    </select>
    <div v-if="error" class="form-error">{{ error }}</div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { v4 as uuid } from 'uuid'

// Define props with types
interface Props {
  id?: string
  error?: string
  label?: string
  modelValue?: string | number | boolean | null
}

const props = withDefaults(defineProps<Props>(), {
  id: () => `select-input-${uuid()}`
})

// Define emits
const emit = defineEmits<{
  'update:modelValue': [value: string | number | boolean | null]
}>()

// Template ref
const input = ref<HTMLSelectElement>()

// Reactive state
const selected = ref(props.modelValue)

// Watch for changes and emit
watch(selected, (newValue) => {
  emit('update:modelValue', newValue)
}, { immediate: false })

// Watch props.modelValue to update selected when parent changes
watch(() => props.modelValue, (newValue) => {
  selected.value = newValue
})

// Methods
const focus = () => {
  input.value?.focus()
}

const select = () => {
  input.value?.select()
}

// Export methods for external access
defineExpose({
  focus,
  select
})
</script>
