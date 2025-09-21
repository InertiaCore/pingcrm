<template>
    <div>
        <Head title="Reports" />
        <h1 class="mb-8 text-3xl font-bold">Reports</h1>
    </div>
</template>

<script setup lang="ts">
import Layout from '@/Shared/Layout.vue';
import type { InertiaSharedProps } from '@/Types/generated';
import { Head } from '@inertiajs/vue3';

// Define page props
type Props = InertiaSharedProps<{
    [key: string]: unknown;
}>;

// Important: hand defineProps a **resolved** alias.
defineProps<Props>();

// This component uses Layout as the default layout
defineOptions({
    layout: Layout,
});
</script>
