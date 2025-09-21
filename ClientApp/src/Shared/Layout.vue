<template>
    <div>
        <div id="dropdown" />
        <div class="md:flex md:flex-col">
            <div class="md:flex md:h-screen md:flex-col">
                <div class="md:flex md:shrink-0">
                    <div
                        class="flex items-center justify-between bg-indigo-900 px-6 py-4 md:w-56 md:shrink-0 md:justify-center"
                    >
                        <Link class="mt-1" href="/">
                            <logo class="fill-white" width="120" height="28" />
                        </Link>
                        <dropdown class="md:hidden" placement="bottom-end">
                            <template #default>
                                <svg
                                    class="h-6 w-6 fill-white"
                                    xmlns="http://www.w3.org/2000/svg"
                                    viewBox="0 0 20 20"
                                >
                                    <path
                                        d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z"
                                    />
                                </svg>
                            </template>
                            <template #dropdown>
                                <div
                                    class="mt-2 rounded bg-indigo-800 px-8 py-4 shadow-lg"
                                >
                                    <main-menu />
                                </div>
                            </template>
                        </dropdown>
                    </div>
                    <div
                        class="md:text-md flex w-full items-center justify-between border-b bg-white p-4 text-sm md:px-12 md:py-0"
                    >
                        <div class="mr-4 mt-1">
                            {{ auth?.user?.account?.name }}
                        </div>
                        <dropdown class="mt-1" placement="bottom-end">
                            <template #default>
                                <div
                                    class="group flex cursor-pointer select-none items-center"
                                >
                                    <div
                                        class="mr-1 whitespace-nowrap text-gray-700 focus:text-indigo-600 group-hover:text-indigo-600"
                                    >
                                        <span>{{
                                            auth?.user?.first_name
                                        }}</span>
                                        <span class="hidden md:inline"
                                            >&nbsp;{{
                                                auth?.user?.last_name
                                            }}</span
                                        >
                                    </div>
                                    <icon
                                        :icon-class="[
                                            'w-5',
                                            'h-5',
                                            'fill-gray-700',
                                            'group-hover:fill-indigo-600',
                                            'focus:fill-indigo-600',
                                        ]"
                                        name="cheveron-down"
                                    />
                                </div>
                            </template>
                            <template #dropdown>
                                <div
                                    class="mt-2 rounded bg-white py-2 text-sm shadow-xl"
                                >
                                    <Link
                                        class="block px-6 py-2 hover:bg-indigo-500 hover:text-white"
                                        :href="`/users/${auth.user.id}/edit`"
                                        >My Profile</Link
                                    >
                                    <Link
                                        class="block px-6 py-2 hover:bg-indigo-500 hover:text-white"
                                        href="/users"
                                        >Manage Users</Link
                                    >
                                    <Link
                                        class="block w-full px-6 py-2 text-left hover:bg-indigo-500 hover:text-white"
                                        href="/logout"
                                        method="delete"
                                        as="button"
                                        >Logout</Link
                                    >
                                </div>
                            </template>
                        </dropdown>
                    </div>
                </div>
                <div class="md:flex md:grow md:overflow-hidden">
                    <main-menu
                        class="hidden w-56 shrink-0 overflow-y-auto bg-indigo-800 p-12 md:block"
                    />
                    <div
                        class="px-4 py-8 md:flex-1 md:overflow-y-auto md:p-12"
                        scroll-region
                    >
                        <flash-messages />
                        <slot />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import Dropdown from '@/Shared/Dropdown.vue';
import FlashMessages from '@/Shared/FlashMessages.vue';
import Icon from '@/Shared/Icon.vue';
import Logo from '@/Shared/Logo.vue';
import MainMenu from '@/Shared/MainMenu.vue';
import type { AuthDto } from '@/Types/generated';
import { Link } from '@inertiajs/vue3';

// Define props with proper types
interface Props {
    auth: AuthDto;
}

defineProps<Props>();
</script>
