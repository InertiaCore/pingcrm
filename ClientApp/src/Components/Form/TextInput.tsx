import { ComponentProps } from 'react';

interface TextInputProps extends ComponentProps<'input'> {
    error?: string;
}

export default function TextInput({
    name,
    className,
    error,
    ...props
}: TextInputProps) {
    return (
        <input
            id={name}
            name={name}
            {...props}
            className={`form-input w-full rounded border-gray-300 focus:border-indigo-400 focus:ring-1 focus:ring-indigo-400 focus:outline-none ${
                error
                    ? 'border-red-400 focus:border-red-400 focus:ring-red-400'
                    : ''
            } ${className}`}
        />
    );
}
