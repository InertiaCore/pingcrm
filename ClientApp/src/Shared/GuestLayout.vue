<template>
    <div
        class="flex min-h-screen items-center justify-center bg-gradient-to-br from-indigo-800 via-indigo-900 to-purple-900 p-6"
    >
        <!-- Background Pattern -->
        <div class="absolute inset-0 bg-black/20"></div>
        <div class="bg-pattern absolute inset-0 opacity-50"></div>

        <!-- Content Container -->
        <div class="relative w-full max-w-md">
            <!-- Logo -->
            <div class="mb-8 text-center">
                <logo
                    class="mx-auto block w-full max-w-xs fill-white drop-shadow-lg"
                    height="50"
                />
            </div>

            <!-- Main Content Slot -->
            <slot />
        </div>

        <!-- Floating Elements -->
        <div
            class="absolute left-10 top-10 h-20 w-20 animate-pulse rounded-full bg-white/10"
        ></div>
        <div
            class="animation-delay-1000 absolute bottom-10 right-10 h-16 w-16 animate-pulse rounded-full bg-white/10"
        ></div>
        <div
            class="animation-delay-2000 absolute right-1/4 top-1/3 h-12 w-12 animate-pulse rounded-full bg-white/10"
        ></div>
    </div>
</template>

<script setup lang="ts">
import Logo from '@/Shared/Logo.vue';
</script>

<style scoped>
.bg-pattern {
    background-image: url('data:image/svg+xml,%3Csvg width="60" height="60" viewBox="0 0 60 60" xmlns="http://www.w3.org/2000/svg"%3E%3Cg fill="none" fill-rule="evenodd"%3E%3Cg fill="%23ffffff" fill-opacity="0.05"%3E%3Ccircle cx="30" cy="30" r="2"/%3E%3C/g%3E%3C/g%3E%3C/svg%3E');
}

.animation-delay-1000 {
    animation-delay: 1s;
}

.animation-delay-2000 {
    animation-delay: 2s;
}
</style>
