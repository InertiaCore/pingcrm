<template>
    <div>
        <Head :title="`${form.first_name} ${form.last_name}`" />
        <div class="mb-8 flex max-w-3xl justify-start">
            <h1 class="text-3xl font-bold">
                <Link
                    class="text-indigo-400 hover:text-indigo-600"
                    href="/users"
                    >Users</Link
                >
                <span class="font-medium text-indigo-400">/</span>
                {{ form.first_name }} {{ form.last_name }}
            </h1>
            <img
                v-if="user.photo"
                class="ml-4 block h-8 w-8 rounded-full"
                :src="user.photo"
            />
        </div>
        <trashed-message v-if="user.deleted_at" class="mb-6" @restore="restore">
            This user has been deleted.
        </trashed-message>
        <div class="max-w-3xl overflow-hidden rounded-md bg-white shadow">
            <form @submit.prevent="update">
                <div class="-mb-8 -mr-6 flex flex-wrap p-8">
                    <text-input
                        v-model="form.first_name"
                        :error="form.errors.first_name"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="First name"
                    />
                    <text-input
                        v-model="form.last_name"
                        :error="form.errors.last_name"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Last name"
                    />
                    <text-input
                        v-model="form.email"
                        :error="form.errors.email"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Email"
                    />
                    <text-input
                        v-model="form.password"
                        :error="form.errors.password"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        type="password"
                        autocomplete="new-password"
                        label="Password"
                    />
                    <select-input
                        v-model="form.owner"
                        :error="form.errors.owner"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Owner"
                    >
                        <option :value="true">Yes</option>
                        <option :value="false">No</option>
                    </select-input>
                    <file-input
                        v-model="form.photo"
                        :error="form.errors.photo"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        type="file"
                        accept="image/*"
                        label="Photo"
                    />
                </div>
                <div
                    class="flex items-center border-t border-gray-100 bg-gray-50 px-8 py-4"
                >
                    <button
                        v-if="!user.deleted_at"
                        class="text-red-600 hover:underline"
                        tabindex="-1"
                        type="button"
                        @click="destroy"
                    >
                        Delete User
                    </button>
                    <loading-button
                        :loading="form.processing"
                        class="btn-indigo ml-auto"
                        type="submit"
                        >Update User</loading-button
                    >
                </div>
            </form>
        </div>
    </div>
</template>

<script setup lang="ts">
import FileInput from '@/Shared/FileInput.vue';
import Layout from '@/Shared/Layout.vue';
import LoadingButton from '@/Shared/LoadingButton.vue';
import SelectInput from '@/Shared/SelectInput.vue';
import TextInput from '@/Shared/TextInput.vue';
import TrashedMessage from '@/Shared/TrashedMessage.vue';
import type { AuthDto, FlashDto, User } from '@/Types/generated';
import { Head, Link, router, useForm } from '@inertiajs/vue3';

// Define page props
interface Props {
    auth: AuthDto;
    flash: FlashDto;
    user: User;
}

const props = defineProps<Props>();

// Define form interface
interface UpdateUserForm {
    _method: string;
    first_name: string;
    last_name: string;
    email: string;
    password: string;
    owner: boolean;
    photo: File | null;
}

const form = useForm<UpdateUserForm>({
    _method: 'put',
    first_name: props.user.first_name,
    last_name: props.user.last_name,
    email: props.user.email,
    password: '',
    owner: props.user.owner,
    photo: null,
});

// Methods
const update = () => {
    form.post(`/users/${props.user.id}`, {
        onSuccess: () => form.reset('password', 'photo'),
    });
};

const destroy = () => {
    if (confirm('Are you sure you want to delete this user?')) {
        router.delete(`/users/${props.user.id}`);
    }
};

const restore = () => {
    if (confirm('Are you sure you want to restore this user?')) {
        router.put(`/users/${props.user.id}/restore`);
    }
};

// This component uses Layout as the default layout
defineOptions({
    layout: Layout,
});
</script>
