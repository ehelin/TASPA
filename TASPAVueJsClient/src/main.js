import { createApp } from 'vue';
import App from './App.vue'; // Your root Vue component
import { createRouter, createWebHistory, useRouter } from 'vue-router'; 
import HelloWorldVue from './components/HelloWorld.vue';

const routes = [
    {
        path: '/components/HelloWorld',
        component: () => import('./components/HelloWorld.vue')
    },
    // Add more routes as needed
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

const app = createApp(App);

// Use the router
app.use(router);

// Mount your app to the root HTML element
app.mount('#app');
