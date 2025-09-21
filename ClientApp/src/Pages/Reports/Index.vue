<template>
  <div>
    <Head title="Reports" />
    <h1 class="mb-8 text-3xl font-bold">Reports</h1>
  </div>
</template>

<script setup lang="ts">
import { Head } from '@inertiajs/vue3'
import Layout from '@/Shared/Layout.vue'
import type { AuthDto, FlashDto } from '@/Types/generated'

// Define page props
interface Props {
  auth: AuthDto
  flash: FlashDto
}

defineProps<Props>()

// This component uses Layout as the default layout
defineOptions({
  layout: Layout,
})
</script>
