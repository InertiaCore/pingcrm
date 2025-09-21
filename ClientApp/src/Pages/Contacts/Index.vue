<template>
    <div>
        <Head title="Contacts" />
        <h1 class="mb-8 text-3xl font-bold">Contacts</h1>
        <div class="mb-6 flex items-center justify-between">
            <search-filter
                v-model="form.search"
                class="mr-4 w-full max-w-md"
                @reset="reset"
            >
                <label class="block text-gray-700">Trashed:</label>
                <select v-model="form.trashed" class="form-select mt-1 w-full">
                    <option :value="null" />
                    <option value="with">With Trashed</option>
                    <option value="only">Only Trashed</option>
                </select>
            </search-filter>
            <Link class="btn-indigo" href="/contacts/create">
                <span>Create</span>
                <span class="hidden md:inline">&nbsp;Contact</span>
            </Link>
        </div>
        <div class="overflow-x-auto rounded-md bg-white shadow">
            <table class="w-full whitespace-nowrap">
                <tr class="text-left font-bold">
                    <th class="px-6 pb-4 pt-6">Name</th>
                    <th class="px-6 pb-4 pt-6">Organization</th>
                    <th class="px-6 pb-4 pt-6">City</th>
                    <th class="px-6 pb-4 pt-6" colspan="2">Phone</th>
                </tr>
                <tr
                    v-for="contact in contacts.data"
                    :key="contact.id"
                    class="focus-within:bg-gray-100 hover:bg-gray-100"
                >
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4 focus:text-indigo-500"
                            :href="`/contacts/${contact.id}/edit`"
                        >
                            {{ contact.name }}
                            <icon
                                v-if="contact.deleted_at"
                                name="trash"
                                class="ml-2 h-3 w-3 shrink-0 fill-gray-400"
                            />
                        </Link>
                    </td>
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4"
                            :href="`/contacts/${contact.id}/edit`"
                            tabindex="-1"
                        >
                            <div v-if="contact.organization">
                                {{ contact.organization.name }}
                            </div>
                        </Link>
                    </td>
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4"
                            :href="`/contacts/${contact.id}/edit`"
                            tabindex="-1"
                        >
                            {{ contact.city }}
                        </Link>
                    </td>
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4"
                            :href="`/contacts/${contact.id}/edit`"
                            tabindex="-1"
                        >
                            {{ contact.phone }}
                        </Link>
                    </td>
                    <td class="w-px border-t">
                        <Link
                            class="flex items-center px-4"
                            :href="`/contacts/${contact.id}/edit`"
                            tabindex="-1"
                        >
                            <icon
                                name="cheveron-right"
                                class="block h-6 w-6 fill-gray-400"
                            />
                        </Link>
                    </td>
                </tr>
                <tr v-if="contacts.data.length === 0">
                    <td class="border-t px-6 py-4" colspan="4">
                        No contacts found.
                    </td>
                </tr>
            </table>
        </div>
        <pagination class="mt-6" :links="contacts.links" />
    </div>
</template>

<script setup lang="ts">
import Icon from '@/Shared/Icon.vue';
import Layout from '@/Shared/Layout.vue';
import Pagination from '@/Shared/Pagination.vue';
import SearchFilter from '@/Shared/SearchFilter.vue';
import type {
    Contact,
    InertiaSharedProps,
    PaginatedData,
    SearchFilters,
} from '@/Types/generated';
import { Head, Link, router } from '@inertiajs/vue3';
import mapValues from 'lodash/mapValues';
import pickBy from 'lodash/pickBy';
import throttle from 'lodash/throttle';
import { reactive, watch } from 'vue';

// Define page props
type Props = InertiaSharedProps<{
    filters: SearchFilters;
    contacts: PaginatedData<Contact>;
}>;

// Important: hand defineProps a **resolved** alias.
const props = defineProps<Props>();

// Reactive form state
const form = reactive<SearchFilters>({
    search: props.filters.search,
    trashed: props.filters.trashed,
});

// Watch form changes with throttling
watch(
    form,
    throttle(() => {
        router.get('/contacts', pickBy(form), { preserveState: true });
    }, 150),
    { deep: true },
);

// Reset form function
const reset = () => {
    Object.assign(
        form,
        mapValues(form, () => null),
    );
};

// This component uses Layout as the default layout
defineOptions({
    layout: Layout,
});
</script>
