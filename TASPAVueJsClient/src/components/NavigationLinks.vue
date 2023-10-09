<template>
    <label>available links</label>
    <p>{{navLinks}}</p>
    <!--<div v-for="(link, index) in data.navLinks" :key="index">
        <router-link :to="link.linkAction">{{link.linkText
        }}</router-link>
        </div>-->
        <router-view></router-view>
</template>

<script>
    import apiService from '../apiService'; // Import the API service
    import { useRouter } from 'vue-router';
    import { ref } from 'vue';
    import HelloWorldVue from './HelloWorld.vue';

    export default {
        setup() {
            var router = useRouter();
            let navigationLinks = [];

            apiService.get('/TaspaApi/getVueJsNavigationLinks')
                .then(response => {
                    navigationLinks = response.data;

                    navigationLinks.forEach((item) => {
                        router.addRoute({
                            path: item.linkAction,
                            component: item.linkText, 
                        });
                    });

                    // TODO - how do set this as available to use in creating the links in the template section?
                    return (navigationLinks );
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        },
        //data() {
        //    return {
        //        navigationLinks: [], // Store navigation links
        //    }
        //},

        methods: {
            //handleLinkClick(event) {
            //    alert('Intercept each link here and update w/appropriate target for Tapsa Vue.js client or update api call two send two different result sets');
            //    // Prevent the default behavior of the link (navigating to the href)
            //    event.preventDefault();

            //    // You can perform custom actions here
            //    // For example, you can update a variable or perform a redirection
            //    // For demonstration, we'll set a variable to indicate the link was clicked
            //    this.linkClicked = true;
            //}
        },

        mounted() {
            //apiService.get('/TaspaApi/getVueJsNavigationLinks')
            //    .then(response => {
            //        this.navigationLinks = response.data; 

            //        const router = useRouter();
            //        router.push('/about'); // Example: Navigate to the '/about' route
            //    })
            //    .catch(error => {
            //        console.error('Error:', error);
            //    });
        },
    }
</script>

<style>
#app {
/*  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;*/
}
</style>
