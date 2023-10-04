import { createApp } from 'vue';
import VueRouter from 'vue-router';
import App from './App.vue';
import Vue from 'vue';
import { getNavigationLinks } from './ServerCalls';

//var results = getNavigationLinks();

createApp(App).mount('#app')

new Vue({
    el: '#app',
    created() {
        // Create a new XMLHttpRequest object
        const request = new XMLHttpRequest();

        var base_url = window.location.origin;
        var url = base_url + subUrl;
        request.open('GET', url, true);

        // Define the request method, URL, and whether it's asynchronous
        //xhr.open('GET', 'https://jsonplaceholder.typicode.com/posts/1', true);

        // Set up an event listener for when the request is complete
        request.onload = () => {
            if (xhr.status === 200) {
                // The request was successful, handle the response
                const response = JSON.parse(xhr.responseText);
                console.log(response);
            } else {
                // The request failed, handle the error
                console.error('Request failed:', xhr.status, xhr.statusText);
            }
        };

        // Set up an event listener for network errors
        request.onerror = () => {
            console.error('Network error occurred');
        };

        // Send the request
        request.send();
    },
});

//Vue.use(VueRouter);

