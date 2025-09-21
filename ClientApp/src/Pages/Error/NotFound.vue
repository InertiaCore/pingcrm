<template>
    <component :is="currentLayout" :auth="auth">
        <div class="relative flex min-h-full items-center justify-center">
            <!-- Main Content -->
            <div class="mx-auto max-w-lg text-center">
                <!-- Animated 404 Icon -->
                <div class="relative mb-8">
                    <div
                        class="mx-auto mb-8 flex h-40 w-40 transform items-center justify-center rounded-3xl bg-gradient-to-br from-indigo-100 to-indigo-50 shadow-2xl transition-all duration-300 hover:scale-105"
                    >
                        <div class="relative">
                            <!-- Document Icon with Animation -->
                            <svg
                                class="h-20 w-20 animate-pulse text-indigo-500"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="1.5"
                                    d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"
                                />
                            </svg>
                            <!-- Question Mark Overlay -->
                            <div
                                class="absolute inset-0 flex items-center justify-center"
                            >
                                <span
                                    class="text-2xl font-bold text-indigo-600 opacity-80"
                                    >?</span
                                >
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Error Code with Gradient -->
                <div class="mb-6">
                    <h1
                        class="mb-2 bg-gradient-to-r from-indigo-600 via-purple-600 to-indigo-800 bg-clip-text text-8xl font-black tracking-tight text-transparent"
                    >
                        404
                    </h1>
                    <div
                        class="mx-auto h-1 w-32 rounded-full bg-gradient-to-r from-indigo-500 to-purple-500"
                    ></div>
                </div>

                <!-- Error Message -->
                <h2
                    class="mb-4 text-3xl font-bold tracking-tight text-gray-100"
                >
                    Oops! Page not found
                </h2>

                <!-- Description -->
                <p class="mb-8 text-lg leading-relaxed text-gray-600">
                    The page you're looking for seems to have wandered off into
                    the digital void. Don't worry, even the best explorers
                    sometimes take a wrong turn.
                </p>

                <!-- Action Buttons with Enhanced Styling -->
                <div
                    class="mb-12 flex flex-col justify-center gap-4 sm:flex-row"
                >
                    <InertiaLink
                        :href="auth?.user ? '/' : '/login'"
                        class="group inline-flex transform items-center justify-center rounded-xl border border-transparent bg-gradient-to-r from-indigo-600 to-indigo-700 px-8 py-4 text-base font-semibold text-white shadow-lg transition-all duration-200 hover:-translate-y-0.5 hover:from-indigo-700 hover:to-indigo-800 hover:shadow-xl focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
                    >
                        <svg
                            class="mr-2 h-5 w-5 group-hover:animate-bounce"
                            fill="none"
                            stroke="currentColor"
                            viewBox="0 0 24 24"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                            />
                        </svg>
                        {{ auth?.user ? 'Take me home' : 'Sign in' }}
                    </InertiaLink>

                    <button
                        @click="goBack"
                        class="group inline-flex transform items-center justify-center rounded-xl border-2 border-gray-300 bg-white px-8 py-4 text-base font-semibold text-gray-700 shadow-lg transition-all duration-200 hover:-translate-y-0.5 hover:border-indigo-300 hover:bg-gray-50 hover:shadow-xl focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
                    >
                        <svg
                            class="mr-2 h-5 w-5 group-hover:animate-bounce"
                            fill="none"
                            stroke="currentColor"
                            viewBox="0 0 24 24"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M10 19l-7-7m0 0l7-7m-7 7h18"
                            />
                        </svg>
                        Go back
                    </button>
                </div>

                <!-- Enhanced Quick Navigation - only show if authenticated -->
                <div
                    v-if="auth?.user"
                    class="rounded-2xl border border-gray-200 bg-white/50 p-6 shadow-lg backdrop-blur-sm"
                >
                    <h3 class="mb-4 text-lg font-semibold text-gray-800">
                        Quick navigation
                    </h3>
                    <div class="grid grid-cols-1 gap-3 sm:grid-cols-3">
                        <InertiaLink
                            href="/users"
                            class="group flex items-center rounded-lg border border-indigo-200 p-3 text-indigo-600 transition-all duration-200 hover:border-indigo-600 hover:bg-indigo-600 hover:text-white"
                        >
                            <svg
                                class="mr-2 h-5 w-5"
                                fill="none"
                                stroke="currentColor"
                                viewBox="0 0 24 24"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z"
                                />
                            </svg>
                            <span class="font-medium">Users</span>
                        </InertiaLink>

                        <InertiaLink
                            href="/organizations"
                            class="group flex items-center rounded-lg border border-indigo-200 p-3 text-indigo-600 transition-all duration-200 hover:border-indigo-600 hover:bg-indigo-600 hover:text-white"
                        >
                            <svg
                                class="mr-2 h-5 w-5"
                                fill="none"
                                stroke="currentColor"
                                viewBox="0 0 24 24"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4"
                                />
                            </svg>
                            <span class="font-medium">Organizations</span>
                        </InertiaLink>

                        <InertiaLink
                            href="/contacts"
                            class="group flex items-center rounded-lg border border-indigo-200 p-3 text-indigo-600 transition-all duration-200 hover:border-indigo-600 hover:bg-indigo-600 hover:text-white"
                        >
                            <svg
                                class="mr-2 h-5 w-5"
                                fill="none"
                                stroke="currentColor"
                                viewBox="0 0 24 24"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z"
                                />
                            </svg>
                            <span class="font-medium">Contacts</span>
                        </InertiaLink>
                    </div>
                </div>
            </div>

            <!-- Floating Background Elements -->
            <div class="pointer-events-none absolute right-10 top-10 opacity-5">
                <div
                    class="h-64 w-64 animate-pulse rounded-full bg-indigo-500"
                ></div>
            </div>

            <div
                class="pointer-events-none absolute bottom-10 left-10 opacity-5"
            >
                <div
                    class="animation-delay-1000 h-48 w-48 animate-pulse rounded-full bg-purple-500"
                ></div>
            </div>

            <div
                class="pointer-events-none absolute right-1/4 top-1/2 opacity-5"
            >
                <div
                    class="animation-delay-2000 h-32 w-32 animate-pulse rounded-full bg-indigo-400"
                ></div>
            </div>
        </div>
    </component>
</template>

<script setup lang="ts">
import GuestLayout from '@/Shared/GuestLayout.vue';
import Layout from '@/Shared/Layout.vue';
import type { InertiaSharedProps } from '@/Types/generated';
import { Link } from '@inertiajs/vue3';
import { computed } from 'vue';

// Alias for template
const InertiaLink = Link;

// Define page props
type Props = InertiaSharedProps<{
    [key: string]: unknown;
}>;

// Important: hand defineProps a **resolved** alias.
const props = defineProps<Props>();

// Computed layout
const currentLayout = computed(() => {
    return props.auth?.user ? Layout : GuestLayout;
});

// Methods
const goBack = () => {
    if (window.history.length > 1) {
        window.history.back();
    } else {
        window.location.href = '/';
    }
};
</script>

<style scoped>
@keyframes float {
    0%,
    100% {
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
