<template>
  <PageHead title="Login" />
  <form class="bg-white rounded-xl shadow-2xl overflow-hidden backdrop-blur-sm border border-white/20" @submit.prevent="login">
    <div class="px-10 py-12">
      <h1 class="text-center text-3xl font-bold text-gray-800">Welcome Back!</h1>
      <div class="mt-6 mx-auto w-24 border-b-2 border-indigo-500" />
      <text-input v-model="form.email" :error="form.errors.email" class="mt-10" label="Email" type="email" autofocus autocapitalize="off" />
      <text-input v-model="form.password" :error="form.errors.password" class="mt-6" label="Password" type="password" />
      <label class="flex items-center mt-6 select-none" for="remember">
        <input id="remember" v-model="form.remember" class="mr-1" type="checkbox" />
        <span class="text-sm text-gray-600">Remember Me</span>
      </label>
    </div>
    <div class="flex px-10 py-4 bg-gradient-to-r from-gray-50 to-gray-100 border-t border-gray-200">
      <loading-button :loading="form.processing" class="btn-indigo ml-auto" type="submit">Sign In</loading-button>
    </div>
  </form>
</template>

<script setup lang="ts">
import { useForm } from '@inertiajs/vue3'
import GuestLayout from '@/Shared/GuestLayout.vue'
import TextInput from '@/Shared/TextInput.vue'
import LoadingButton from '@/Shared/LoadingButton.vue'

// Define login form interface
interface LoginForm {
  email: string
  password: string
  remember: boolean
}

const form = useForm<LoginForm>({
  email: 'johndoe@example.com',
  password: 'secret',
  remember: false,
})

// Login function
const login = () => {
  form.post('/login')
}

// This component uses GuestLayout
defineOptions({
  layout: GuestLayout,
})
</script>
