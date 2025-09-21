export interface User {
    id: number;
    first_name: string;
    last_name: string;
    email: string;
    owner: boolean;
    account: {
        id: number;
        name: string;
    };
}

export interface Auth {
    user: User | null;
}

export type InertiaSharedProps<T = Record<string, unknown>> = T & {
    auth: Auth;
    flash?: { error?: string; success?: string };
    [key: string]: unknown;
};
