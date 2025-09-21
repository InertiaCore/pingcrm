<template>
    <div>
        <Head title="Create Contact" />
        <h1 class="mb-8 text-3xl font-bold">
            <Link class="text-indigo-400 hover:text-indigo-600" href="/contacts"
                >Contacts</Link
            >
            <span class="font-medium text-indigo-400">/</span> Create
        </h1>
        <div class="max-w-3xl overflow-hidden rounded-md bg-white shadow">
            <form @submit.prevent="store">
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
                    <select-input
                        v-model="form.organization_id"
                        :error="form.errors.organization_id"
                        class="w-full pb-8 pr-6 lg:w-1/2"
                        label="Organization"
                    >
                        <option :value="null" />
                        <option
                            v-for="organization in organizations"
                            :key="organization.id"
                            :value="organization.id"
                        >
                            {{ organization.name }}
                        </option>
                    </select-input>
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
                    class="flex items-center justify-end border-t border-gray-100 bg-gray-50 px-8 py-4"
                >
                    <loading-button
                        :loading="form.processing"
                        class="btn-indigo"
                        type="submit"
                        >Create Contact</loading-button
                    >
                </div>
            </form>
        </div>
    </div>
</template>

<script setup lang="ts">
import Layout from '@/Shared/Layout.vue';
import LoadingButton from '@/Shared/LoadingButton.vue';
import SelectInput from '@/Shared/SelectInput.vue';
import TextInput from '@/Shared/TextInput.vue';
import type {
    AuthDto,
    ContactViewModel,
    FlashDto,
    Organization,
} from '@/Types/generated';
import { Head, Link, useForm } from '@inertiajs/vue3';

// Define page props
interface Props {
    auth: AuthDto;
    flash: FlashDto;
    organizations: Organization[];
}

defineProps<Props>();

const form = useForm<ContactViewModel>({
    first_name: '',
    last_name: '',
    organization_id: 0,
    email: '',
    phone: '',
    address: '',
    city: '',
    region: '',
    country: '',
    postal_code: '',
});

// Submit function
const store = () => {
    form.post('/contacts');
};

// This component uses Layout as the default layout
defineOptions({
    layout: Layout,
});
</script>
