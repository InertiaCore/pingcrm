<template>
    <div>
        <Head title="Users" />
        <h1 class="mb-8 text-3xl font-bold">Users</h1>
        <div class="mb-6 flex items-center justify-between">
            <search-filter
                v-model="form.search"
                class="mr-4 w-full max-w-md"
                @reset="reset"
            >
                <label class="block text-gray-700">Role:</label>
                <select v-model="form.role" class="form-select mt-1 w-full">
                    <option :value="null" />
                    <option value="user">User</option>
                    <option value="owner">Owner</option>
                </select>
                <label class="mt-4 block text-gray-700">Trashed:</label>
                <select v-model="form.trashed" class="form-select mt-1 w-full">
                    <option :value="null" />
                    <option value="with">With Trashed</option>
                    <option value="only">Only Trashed</option>
                </select>
            </search-filter>
            <Link class="btn-indigo" href="/users/create">
                <span>Create</span>
                <span class="hidden md:inline">&nbsp;User</span>
            </Link>
        </div>
        <div class="overflow-x-auto rounded-md bg-white shadow">
            <table class="w-full whitespace-nowrap">
                <tr class="text-left font-bold">
                    <th class="px-6 pb-4 pt-6">Name</th>
                    <th class="px-6 pb-4 pt-6">Email</th>
                    <th class="px-6 pb-4 pt-6" colspan="2">Role</th>
                </tr>
                <tr
                    v-for="user in users"
                    :key="user.id"
                    class="focus-within:bg-gray-100 hover:bg-gray-100"
                >
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4 focus:text-indigo-500"
                            :href="`/users/${user.id}/edit`"
                        >
                            <img
                                v-if="user.photo"
                                class="-my-2 mr-2 block h-5 w-5 rounded-full"
                                :src="user.photo"
                            />
                            {{ user.name }}
                            <icon
                                v-if="user.deleted_at"
                                name="trash"
                                class="ml-2 h-3 w-3 shrink-0 fill-gray-400"
                            />
                        </Link>
                    </td>
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4"
                            :href="`/users/${user.id}/edit`"
                            tabindex="-1"
                        >
                            {{ user.email }}
                        </Link>
                    </td>
                    <td class="border-t">
                        <Link
                            class="flex items-center px-6 py-4"
                            :href="`/users/${user.id}/edit`"
                            tabindex="-1"
                        >
                            {{ user.owner ? 'Owner' : 'User' }}
                        </Link>
                    </td>
                    <td class="w-px border-t">
                        <Link
                            class="flex items-center px-4"
                            :href="`/users/${user.id}/edit`"
                            tabindex="-1"
                        >
                            <icon
                                name="cheveron-right"
                                class="block h-6 w-6 fill-gray-400"
                            />
                        </Link>
                    </td>
                </tr>
                <tr v-if="users.length === 0">
                    <td class="border-t px-6 py-4" colspan="4">
                        No users found.
                    </td>
                </tr>
            </table>
        </div>
    </div>
</template>

<script setup lang="ts">
import Icon from '@/Shared/Icon.vue';
import Layout from '@/Shared/Layout.vue';
import SearchFilter from '@/Shared/SearchFilter.vue';
import type { InertiaSharedProps, User, UserFilters } from '@/Types/generated';
import { Head, Link, router } from '@inertiajs/vue3';
import mapValues from 'lodash/mapValues';
import pickBy from 'lodash/pickBy';
import throttle from 'lodash/throttle';
import { reactive, watch } from 'vue';

// Define page props
type Props = InertiaSharedProps<{
    filters: UserFilters;
    users: User[];
}>;

// Important: hand defineProps a **resolved** alias.
const props = defineProps<Props>();

// Reactive form state
const form = reactive<UserFilters>({
    search: props.filters.search,
    role: props.filters.role,
    trashed: props.filters.trashed,
});

// Watch form changes with throttling
watch(
    form,
    throttle(() => {
        router.get('/users', pickBy(form), { preserveState: true });
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
