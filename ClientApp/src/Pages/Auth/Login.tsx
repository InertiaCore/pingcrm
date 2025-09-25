import LoadingButton from '@/Components/Button/LoadingButton';
import { CheckboxInput } from '@/Components/Form/CheckboxInput';
import FieldGroup from '@/Components/Form/FieldGroup';
import TextInput from '@/Components/Form/TextInput';
import Logo from '@/Components/Logo/Logo';
import { Head, useForm } from '@inertiajs/react';
import React from 'react';

export default function LoginPage() {
    const { data, setData, errors, post, processing } = useForm({
        email: 'johndoe@example.com',
        password: 'secret',
        remember: true,
    });

    function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();

        post('/login');
    }

    return (
        <div className="flex min-h-screen items-center justify-center bg-indigo-900 p-6">
            <Head title="Login" />

            <div className="w-full max-w-md">
                <Logo
                    className="mx-auto block w-full max-w-xs fill-current text-white"
                    height={50}
                />
                <form
                    onSubmit={handleSubmit}
                    className="mt-8 overflow-hidden rounded-lg bg-white shadow-xl"
                >
                    <div className="px-10 py-12">
                        <h1 className="text-center text-3xl font-bold">
                            Welcome Back!
                        </h1>
                        <div className="mx-auto mt-6 w-24 border-b-2" />
                        <div className="grid gap-6">
                            <FieldGroup
                                label="Email"
                                name="email"
                                error={errors.email}
                            >
                                <TextInput
                                    name="email"
                                    type="email"
                                    error={errors.email}
                                    value={data.email}
                                    onChange={(e) =>
                                        setData('email', e.target.value)
                                    }
                                />
                            </FieldGroup>

                            <FieldGroup
                                label="Password"
                                name="password"
                                error={errors.password}
                            >
                                <TextInput
                                    type="password"
                                    error={errors.password}
                                    value={data.password}
                                    onChange={(e) =>
                                        setData('password', e.target.value)
                                    }
                                />
                            </FieldGroup>

                            <FieldGroup>
                                <CheckboxInput
                                    label="Remember Me"
                                    name="remember"
                                    id="remember"
                                    checked={data.remember}
                                    onChange={(e) =>
                                        setData('remember', e.target.checked)
                                    }
                                />
                            </FieldGroup>
                        </div>
                    </div>
                    <div className="flex items-center justify-between border-t border-gray-200 bg-gray-100 px-10 py-4">
                        <a
                            className="hover:underline"
                            tabIndex={-1}
                            href="#reset-password"
                        >
                            Forgot password?
                        </a>
                        <LoadingButton
                            type="submit"
                            loading={processing}
                            className="btn-indigo"
                        >
                            Login
                        </LoadingButton>
                    </div>
                </form>
            </div>
        </div>
    );
}
