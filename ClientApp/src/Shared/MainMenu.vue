<template>
  <div>
    <div class="mb-4">
      <Link class="group flex items-center py-3 gap-x-2" href="/">
        <icon name="dashboard" :icon-class="['mr-2', 'w-4', 'h-4', isUrl('') ? 'fill-white' : 'fill-indigo-400 group-hover:fill-white']" />
        <div :class="isUrl('') ? 'text-white' : 'text-indigo-300 group-hover:text-white'">Dashboard</div>
      </Link>
    </div>
    <div class="mb-4">
      <Link class="group flex items-center py-3 gap-x-2" href="/organizations">
        <icon name="office" :icon-class="['mr-2', 'w-4', 'h-4', isUrl('organizations') ? 'fill-white' : 'fill-indigo-400 group-hover:fill-white']" />
        <div :class="isUrl('organizations') ? 'text-white' : 'text-indigo-300 group-hover:text-white'">Organizations</div>
      </Link>
    </div>
    <div class="mb-4">
      <Link class="group flex items-center py-3 gap-x-2" href="/contacts">
        <icon name="users" :icon-class="['mr-2', 'w-4', 'h-4', isUrl('contacts') ? 'fill-white' : 'fill-indigo-400 group-hover:fill-white']" />
        <div :class="isUrl('contacts') ? 'text-white' : 'text-indigo-300 group-hover:text-white'">Contacts</div>
      </Link>
    </div>
    <div class="mb-4">
      <Link class="group flex items-center py-3 gap-x-2" href="/reports">
        <icon name="printer" :icon-class="['mr-2', 'w-4', 'h-4', isUrl('reports') ? 'fill-white' : 'fill-indigo-400 group-hover:fill-white']" />
        <div :class="isUrl('reports') ? 'text-white' : 'text-indigo-300 group-hover:text-white'">Reports</div>
      </Link>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Link } from '@inertiajs/vue3'
import { usePage } from '@inertiajs/vue3'
import Icon from '@/Shared/Icon.vue'

// Get page data
const page = usePage()

// Helper function to check current URL
const isUrl = (...urls: string[]) => {
  const currentUrl = page.url.substring(1)
  if (urls[0] === '') {
    return currentUrl === ''
  }
  return urls.filter((url) => currentUrl.startsWith(url)).length > 0
}
</script>
