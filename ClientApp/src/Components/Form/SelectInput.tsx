import { ComponentProps } from 'react';

interface SelectInputProps extends ComponentProps<'select'> {
    error?: string;
    options: { value: string; label: string }[];
}

export default function SelectInput({
    name,
    error,
    options = [],
    ...props
}: SelectInputProps) {
    return (
        <select
            id={name}
            name={name}
            {...props}
            className={`form-select w-full rounded border-gray-300 focus:border-indigo-400 focus:ring-1 focus:ring-indigo-400 focus:outline-none ${
                error
                    ? 'border-red-400 focus:border-red-400 focus:ring-red-400'
                    : ''
            }`}
        >
            {options?.map(({ value, label }, index) => (
                <option key={index} value={value}>
                    {label}
                </option>
            ))}
        </select>
    );
}
