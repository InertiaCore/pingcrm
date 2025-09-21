<template>
  <component :is="currentLayout" :auth="auth">
    <div class="relative min-h-full flex items-center justify-center">
      <!-- Main Content -->
      <div class="text-center max-w-lg mx-auto">
        <!-- Animated 404 Icon -->
        <div class="relative mb-8">
          <div class="mx-auto flex items-center justify-center h-40 w-40 rounded-3xl bg-gradient-to-br from-indigo-100 to-indigo-50 shadow-2xl mb-8 transform hover:scale-105 transition-all duration-300">
            <div class="relative">
              <!-- Document Icon with Animation -->
              <svg class="h-20 w-20 text-indigo-500 animate-pulse" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
              </svg>
              <!-- Question Mark Overlay -->
              <div class="absolute inset-0 flex items-center justify-center">
                <span class="text-indigo-600 text-2xl font-bold opacity-80">?</span>
              </div>
            </div>
          </div>
        </div>

        <!-- Error Code with Gradient -->
        <div class="mb-6">
          <h1 class="text-8xl font-black bg-gradient-to-r from-indigo-600 via-purple-600 to-indigo-800 bg-clip-text text-transparent mb-2 tracking-tight">
            404
          </h1>
          <div class="h-1 w-32 bg-gradient-to-r from-indigo-500 to-purple-500 mx-auto rounded-full"></div>
        </div>

        <!-- Error Message -->
        <h2 class="text-3xl font-bold text-gray-100 mb-4 tracking-tight">
          Oops! Page not found
        </h2>

        <!-- Description -->
        <p class="text-lg text-gray-600 mb-8 leading-relaxed">
          The page you're looking for seems to have wandered off into the digital void.
          Don't worry, even the best explorers sometimes take a wrong turn.
        </p>

        <!-- Action Buttons with Enhanced Styling -->
        <div class="flex flex-col sm:flex-row gap-4 justify-center mb-12">
          <InertiaLink
            :href="auth?.user ? '/' : '/login'"
            class="group inline-flex items-center justify-center px-8 py-4 border border-transparent text-base font-semibold rounded-xl text-white bg-gradient-to-r from-indigo-600 to-indigo-700 hover:from-indigo-700 hover:to-indigo-800 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 shadow-lg hover:shadow-xl transform hover:-translate-y-0.5 transition-all duration-200"
          >
            <svg class="w-5 h-5 mr-2 group-hover:animate-bounce" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" />
            </svg>
            {{ auth?.user ? 'Take me home' : 'Sign in' }}
          </InertiaLink>

          <button
            @click="goBack"
            class="group inline-flex items-center justify-center px-8 py-4 border-2 border-gray-300 text-base font-semibold rounded-xl text-gray-700 bg-white hover:bg-gray-50 hover:border-indigo-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 shadow-lg hover:shadow-xl transform hover:-translate-y-0.5 transition-all duration-200"
          >
            <svg class="w-5 h-5 mr-2 group-hover:animate-bounce" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 19l-7-7m0 0l7-7m-7 7h18" />
            </svg>
            Go back
          </button>
        </div>

        <!-- Enhanced Quick Navigation - only show if authenticated -->
        <div v-if="auth?.user" class="bg-white/50 backdrop-blur-sm rounded-2xl p-6 border border-gray-200 shadow-lg">
          <h3 class="text-lg font-semibold text-gray-800 mb-4">Quick navigation</h3>
          <div class="grid grid-cols-1 sm:grid-cols-3 gap-3">
            <InertiaLink
              href="/users"
              class="group flex items-center p-3 rounded-lg text-indigo-600 hover:text-white hover:bg-indigo-600 transition-all duration-200 border border-indigo-200 hover:border-indigo-600"
            >
              <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z" />
              </svg>
              <span class="font-medium">Users</span>
            </InertiaLink>

            <InertiaLink
              href="/organizations"
              class="group flex items-center p-3 rounded-lg text-indigo-600 hover:text-white hover:bg-indigo-600 transition-all duration-200 border border-indigo-200 hover:border-indigo-600"
            >
              <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
              </svg>
              <span class="font-medium">Organizations</span>
            </InertiaLink>

            <InertiaLink
              href="/contacts"
              class="group flex items-center p-3 rounded-lg text-indigo-600 hover:text-white hover:bg-indigo-600 transition-all duration-200 border border-indigo-200 hover:border-indigo-600"
            >
              <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z" />
              </svg>
              <span class="font-medium">Contacts</span>
            </InertiaLink>
          </div>
        </div>
      </div>

      <!-- Floating Background Elements -->
      <div class="absolute top-10 right-10 opacity-5 pointer-events-none">
        <div class="w-64 h-64 bg-indigo-500 rounded-full animate-pulse"></div>
      </div>

      <div class="absolute bottom-10 left-10 opacity-5 pointer-events-none">
        <div class="w-48 h-48 bg-purple-500 rounded-full animate-pulse animation-delay-1000"></div>
      </div>

      <div class="absolute top-1/2 right-1/4 opacity-5 pointer-events-none">
        <div class="w-32 h-32 bg-indigo-400 rounded-full animate-pulse animation-delay-2000"></div>
      </div>
    </div>
  </component>
</template>

<script setup lang="ts">
import { Link } from '@inertiajs/vue3'
import { computed } from 'vue'
import Layout from '@/Shared/Layout.vue'
import GuestLayout from '@/Shared/GuestLayout.vue'
import type { AuthDto } from '@/Types/generated'

// Alias for template
const InertiaLink = Link

// Define page props
interface Props {
  auth?: AuthDto
}

const props = defineProps<Props>()

// Computed layout
const currentLayout = computed(() => {
  return props.auth?.user ? Layout : GuestLayout
})

// Methods
const goBack = () => {
  if (window.history.length > 1) {
    window.history.back()
  } else {
    window.location.href = '/'
  }
}
</script>

<style scoped>
@keyframes float {
  0%, 100% {
    transform: translateY(0px);
  }
  50% {
    transform: translateY(-10px);
  }
}

.animation-delay-1000 {
  animation-delay: 1s;
}

.animation-delay-2000 {
  animation-delay: 2s;
}
</style>
