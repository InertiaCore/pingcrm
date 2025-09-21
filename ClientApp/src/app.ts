import { resolvePageComponent } from '@inertiacore/vite-plugin/inertia-helpers';
import { createInertiaApp } from '@inertiajs/vue3';
import { createApp, DefineComponent, h } from 'vue';
import './css/app.css';

createInertiaApp({
    resolve: (name) =>
        resolvePageComponent(
            `./Pages/${name}.vue`,
            import.meta.glob<DefineComponent>('./Pages/**/*.vue'),
        ),
    title: (title) => (title ? `${title} - Ping CRM` : 'Ping CRM'),
    setup({ el, App, props, plugin }) {
        const app = createApp({
            render: () => h(App, props),
        });
        app.config.globalProperties.window = window;
        app.use(plugin).mount(el);
    },
});
