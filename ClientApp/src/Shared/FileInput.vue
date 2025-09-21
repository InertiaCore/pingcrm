<template>
  <div>
    <label v-if="label" class="form-label">{{ label }}:</label>
    <div class="form-input p-0" :class="{ error: errors.length }">
      <input ref="file" type="file" :accept="accept" class="hidden" @change="change" />
      <div v-if="!modelValue" class="p-2">
        <button type="button" class="px-4 py-1 text-white text-xs font-medium bg-gray-500 hover:bg-gray-700 rounded-sm" @click="browse">Browse</button>
      </div>
      <div v-else class="flex items-center justify-between p-2">
        <div class="flex-1 pr-1">
          {{ modelValue.name }} <span class="text-gray-500 text-xs">({{ filesize(modelValue.size) }})</span>
        </div>
        <button type="button" class="px-4 py-1 text-white text-xs font-medium bg-gray-500 hover:bg-gray-700 rounded-sm" @click="remove">Remove</button>
      </div>
    </div>
    <div v-if="errors.length" class="form-error">{{ errors[0] }}</div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'

// Define props with types
interface Props {
  modelValue?: File | null
  label?: string
  accept?: string
  errors?: string[]
}

const props = withDefaults(defineProps<Props>(), {
  errors: () => []
})

// Define emits
const emit = defineEmits<{
  'update:modelValue': [value: File | null]
}>()

// Template ref
const file = ref<HTMLInputElement>()

// Watch modelValue to clear input when null
watch(() => props.modelValue, (value) => {
  if (!value && file.value) {
    file.value.value = ''
  }
})

// Methods
const filesize = (size: number): string => {
  const i = Math.floor(Math.log(size) / Math.log(1024))
  return (size / Math.pow(1024, i)).toFixed(2) as any * 1 + ' ' + ['B', 'kB', 'MB', 'GB', 'TB'][i]
}

const browse = () => {
  file.value?.click()
}

const change = (e: Event) => {
  const target = e.target as HTMLInputElement
  const selectedFile = target.files?.[0] || null
  emit('update:modelValue', selectedFile)
}

const remove = () => {
  emit('update:modelValue', null)
}
</script>
