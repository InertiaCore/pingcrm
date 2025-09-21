<template>
    <div>
        <Head title="Dashboard" />
        <h1 class="mb-8 text-3xl font-bold">Dashboard</h1>
        <p class="mb-8 leading-normal">
            Hey there! Welcome to Ping CRM, a demo app designed to help
            illustrate how
            <a
                class="text-indigo-500 underline hover:text-orange-600"
                href="https://inertiajs.com"
                >Inertia.js</a
            >
            works.
        </p>
    </div>
</template>

<script setup lang="ts">
import Layout from '@/Shared/Layout.vue';
import type { InertiaSharedProps } from '@/Types/generated';
import { Head } from '@inertiajs/vue3';

defineProps<InertiaSharedProps>();

// This component uses Layout as the default layout
defineOptions({
    layout: Layout,
});
</script>
