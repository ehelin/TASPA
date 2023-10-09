//import { createApp } from 'vue';
//import VueRouter from 'vue-router';
//import App from './App.vue';
//import HelloWorldVue from './components/HelloWorld.vue';

//const app = createApp(App);

//app.use(VueRouter);

//const router = new VueRouter({
//    routes: [
//        {
//            path: '/',
//            component: HelloWorldVue, // Your Home component
//        },
//        //{
//        //    path: '/about',
//        //    component: About, // Your About component
//        //},
//        // Add more routes as needed
//    ],
//});

////const router = new VueRouter({
////    routes,
////});


////// Use the router
//app.use(router);

////// Mount your app to the root HTML element
//app.mount('#app');

////createApp(App).mount('#app')
import { createApp } from 'vue';
import App from './App.vue'; // Your root Vue component
import { createRouter, createWebHistory, useRouter } from 'vue-router'; 
import HelloWorldVue from './components/HelloWorld.vue';

const routes = [
    //{
    //    path: '/',
    //    component: HelloWorldVue,
    //},
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
