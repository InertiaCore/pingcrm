<template>
    <component :is="currentLayout" :auth="auth">
        <div class="relative flex min-h-full items-center justify-center">
            <!-- Main Content -->
            <div class="mx-auto max-w-lg text-center">
                <!-- Animated 500 Icon -->
                <div class="relative mb-8">
                    <div
                        class="mx-auto mb-8 flex h-40 w-40 transform items-center justify-center rounded-3xl bg-gradient-to-br from-red-100 to-red-50 shadow-2xl transition-all duration-300 hover:scale-105"
                    >
                        <div class="relative">
                            <!-- Server Error Icon with Animation -->
                            <svg
                                class="h-20 w-20 animate-pulse text-red-500"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="1.5"
                                    d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-2.5L13.732 4c-.77-.833-1.964-.833-2.732 0L4.072 16.5c-.77.833.192 2.5 1.732 2.5z"
                                />
                            </svg>
                            <!-- Exclamation Mark Overlay -->
                            <div
                                class="absolute inset-0 flex items-center justify-center"
                            >
                                <span
                                    class="text-2xl font-bold text-red-600 opacity-80"
                                    >!</span
                                >
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Error Code with Gradient -->
                <div class="mb-6">
                    <h1
                        class="mb-2 bg-gradient-to-r from-red-600 via-orange-600 to-red-800 bg-clip-text text-8xl font-black tracking-tight text-transparent"
                    >
                        500
                    </h1>
                    <div
                        class="mx-auto h-1 w-32 rounded-full bg-gradient-to-r from-red-500 to-orange-500"
                    ></div>
                </div>

                <!-- Error Message -->
                <h2
                    class="mb-4 text-3xl font-bold tracking-tight text-gray-100"
                >
                    Internal Server Error
                </h2>

                <!-- Description -->
                <p class="mb-8 text-lg leading-relaxed text-gray-600">
                    Something went wrong on our end. We're working to fix this
                    issue. Please try again later or contact support if the
                    problem persists.
                </p>

                <!-- Error Details (Development Only) -->
                <div
                    v-if="message && showDetails"
                    class="mb-8 rounded-lg border border-red-200 bg-red-50 p-4 text-left"
                >
                    <h3 class="mb-2 text-sm font-semibold text-red-800">
                        Error Details:
                    </h3>
                    <p class="mb-2 text-sm text-red-700">{{ message }}</p>
                    <details v-if="stackTrace" class="text-xs text-red-600">
                        <summary class="cursor-pointer font-medium">
                            Stack Trace
                        </summary>
                        <pre class="mt-2 whitespace-pre-wrap">{{
                            stackTrace
                        }}</pre>
                    </details>
                </div>

                <!-- Action Buttons with Enhanced Styling -->
                <div
                    class="mb-12 flex flex-col justify-center gap-4 sm:flex-row"
                >
                    <InertiaLink
                        :href="auth?.user ? '/' : '/login'"
                        class="group inline-flex transform items-center justify-center rounded-xl border border-transparent bg-gradient-to-r from-red-600 to-red-700 px-8 py-4 text-base font-semibold text-white shadow-lg transition-all duration-200 hover:-translate-y-0.5 hover:from-red-700 hover:to-red-800 hover:shadow-xl focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2"
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
                        class="group inline-flex transform items-center justify-center rounded-xl border-2 border-gray-300 bg-white px-8 py-4 text-base font-semibold text-gray-700 shadow-lg transition-all duration-200 hover:-translate-y-0.5 hover:border-red-300 hover:bg-gray-50 hover:shadow-xl focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2"
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
                        Try again
                    </button>

                    <button
                        @click="refreshPage"
                        class="group inline-flex transform items-center justify-center rounded-xl border-2 border-gray-300 bg-white px-8 py-4 text-base font-semibold text-gray-700 shadow-lg transition-all duration-200 hover:-translate-y-0.5 hover:border-red-300 hover:bg-gray-50 hover:shadow-xl focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2"
                    >
                        <svg
                            class="mr-2 h-5 w-5 group-hover:animate-spin"
                            fill="none"
                            stroke="currentColor"
                            viewBox="0 0 24 24"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
                            />
                        </svg>
                        Refresh
                    </button>
                </div>

                <!-- Support Contact (only show if authenticated) -->
                <div
                    v-if="auth?.user"
                    class="rounded-2xl border border-gray-200 bg-white/50 p-6 shadow-lg backdrop-blur-sm"
                >
                    <h3 class="mb-4 text-lg font-semibold text-gray-800">
                        Need help?
                    </h3>
                    <p class="mb-4 text-gray-600">
                        If this error persists, please contact our support team
                        with the details above.
                    </p>
                    <div class="flex justify-center">
                        <a
                            href="mailto:support@pingcrm.com"
                            class="inline-flex items-center rounded-md border border-red-300 bg-white px-4 py-2 text-sm font-medium text-red-700 hover:bg-red-50 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2"
                        >
                            <svg
                                class="mr-2 h-4 w-4"
                                fill="none"
                                stroke="currentColor"
                                viewBox="0 0 24 24"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M3 8l7.89 4.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"
                                />
                            </svg>
                            Contact Support
                        </a>
                    </div>
                </div>
            </div>

            <!-- Floating Background Elements -->
            <div class="pointer-events-none absolute right-10 top-10 opacity-5">
                <div
                    class="h-64 w-64 animate-pulse rounded-full bg-red-500"
                ></div>
            </div>

            <div
                class="pointer-events-none absolute bottom-10 left-10 opacity-5"
            >
                <div
                    class="animation-delay-1000 h-48 w-48 animate-pulse rounded-full bg-orange-500"
                ></div>
            </div>

            <div
                class="pointer-events-none absolute right-1/4 top-1/2 opacity-5"
            >
                <div
                    class="animation-delay-2000 h-32 w-32 animate-pulse rounded-full bg-red-400"
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

// Define page props
type Props = InertiaSharedProps<{
    message?: string;
    stackTrace?: string;
}>;

// Important: hand defineProps a **resolved** alias.
const props = defineProps<Props>();

// Alias for template
const InertiaLink = Link;

// Computed layout
const currentLayout = computed(() => {
    return props.auth?.user ? Layout : GuestLayout;
});

// Computed to show error details only in development
const showDetails = computed(() => {
    return (
        props.message &&
        (import.meta.env.DEV || window.location.hostname === 'localhost')
    );
});

// Methods
const goBack = () => {
    if (window.history.length > 1) {
        window.history.back();
    } else {
        window.location.href = props.auth?.user ? '/' : '/login';
    }
};

const refreshPage = () => {
    window.location.reload();
};
</script>

<style scoped>
.animation-delay-1000 {
    animation-delay: 1s;
}

.animation-delay-2000 {
    animation-delay: 2s;
}
</style>
