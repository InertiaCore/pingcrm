import { ComponentProps } from 'react';

interface CheckboxInputProps extends ComponentProps<'input'> {
    label?: string;
}

export function CheckboxInput({ label, name, ...props }: CheckboxInputProps) {
    return (
        <label className="flex items-center select-none" htmlFor={name}>
            <input
                id={name}
                name={name}
                type="checkbox"
                className="form-checkbox mr-2 rounded text-indigo-600 focus:ring-indigo-600"
                {...props}
            />
            <span className="text-sm">{label}</span>
        </label>
    );
}
