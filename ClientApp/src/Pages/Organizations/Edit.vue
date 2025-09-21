<template>
    <div>
        <Head :title="form.name" />
        <h1 class="mb-8 text-3xl font-bold">
            <Link
                class="text-indigo-400 hover:text-indigo-600"
                href="/organizations"
                >Organizations</Link
            >
            <span class="font-medium text-indigo-400">/</span>
            {{ form.name }}
        </h1>
        <trashed-message
            v-if="organization.deleted_at"
            class="mb-6"
            @restore="restore"
        >
            This organization has been deleted.
        </trashed-message>
        <div class="max-w-3xl overflow-hidden rounded-md bg-white shadow">
            <form @submit.prevent="update">
                <div class="-mb-8 -mr-6 flex flex-wrap p-8">
                    <text-input
                        v-model="form.name"
                        :error="form.errors.name"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Name"
                    />
                    <text-input
                        v-model="form.email"
                        :error="form.errors.email"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Email"
                    />
                    <text-input
                        v-model="form.phone"
                        :error="form.errors.phone"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Phone"
                    />
                    <text-input
                        v-model="form.address"
                        :error="form.errors.address"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Address"
                    />
                    <text-input
                        v-model="form.city"
                        :error="form.errors.city"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="City"
                    />
                    <text-input
                        v-model="form.region"
                        :error="form.errors.region"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Province/State"
                    />
                    <select-input
                        v-model="form.country"
                        :error="form.errors.country"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Country"
                    >
                        <option :value="null" />
                        <option value="CA">Canada</option>
                        <option value="US">United States</option>
                    </select-input>
                    <text-input
                        v-model="form.postal_code"
                        :error="form.errors.postal_code"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Postal code"
                    />
                </div>
                <div
                    class="flex items-center border-t border-gray-100 bg-gray-50 px-8 py-4"
                >
                    <button
                        v-if="!organization.deleted_at"
                        class="text-red-600 hover:underline"
                        tabindex="-1"
                        type="button"
                        @click="destroy"
                    >
                        Delete Organization
                    </button>
                    <loading-button
                        :loading="form.processing"
                        class="btn-indigo ml-auto"
                        type="submit"
                        >Update Organization</loading-button
                    >
                </div>
            </form>
        </div>
        <h2 class="mt-12 text-2xl font-bold">Contacts</h2>
        <div class="mt-6 overflow-x-auto rounded bg-white shadow">
            <table class="w-full whitespace-nowrap">
                <tr class="text-left font-bold">
                    <th class="px-6 pb-4 pt-6">Name</th>
                    <th class="px-6 pb-4 pt-6">City</th>
                    <th class="px-6 pb-4 pt-6" colspan="2">Phone</th>
                </tr>
                <tr
                    v-for="contact in organization.contacts"
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
                <tr v-if="organization.contacts.length === 0">
                    <td class="border-t px-6 py-4" colspan="4">
                        No contacts found.
                    </td>
                </tr>
            </table>
        </div>
    </div>
</template>

<script setup lang="ts">
import Icon from '@/Shared/Icon.vue';
import Layout from '@/Shared/Layout.vue';
import LoadingButton from '@/Shared/LoadingButton.vue';
import SelectInput from '@/Shared/SelectInput.vue';
import TextInput from '@/Shared/TextInput.vue';
import TrashedMessage from '@/Shared/TrashedMessage.vue';
import type {
    AuthDto,
    FlashDto,
    Organization,
    OrganizationViewModel,
} from '@/Types/generated';
import { Head, Link, router, useForm } from '@inertiajs/vue3';

// Define page props
interface Props {
    auth: AuthDto;
    flash: FlashDto;
    organization: Organization;
}

const props = defineProps<Props>();

const form = useForm<OrganizationViewModel>({
    name: props.organization.name,
    email: props.organization.email,
    phone: props.organization.phone,
    address: props.organization.address,
    city: props.organization.city,
    region: props.organization.region,
    country: props.organization.country,
    postal_code: props.organization.postal_code,
});

// Methods
const update = () => {
    form.put(`/organizations/${props.organization.id}`);
};

const destroy = () => {
    if (confirm('Are you sure you want to delete this organization?')) {
        router.delete(`/organizations/${props.organization.id}`);
    }
};

const restore = () => {
    if (confirm('Are you sure you want to restore this organization?')) {
        router.put(`/organizations/${props.organization.id}/restore`);
    }
};

// This component uses Layout as the default layout
defineOptions({
    layout: Layout,
});
</script>
