<template>
    <label>available links</label>
    <!--<div v-for="(link, index) in navigationLinks" :key="index">-->
        <!--<a :href="link.linkAction" @click="handleLinkClick">{{link.linkText}}</a>-->

        <!--<router-link :to="link.linkAction">{{link.linkText}}</router-link>
    </div>-->
    
    <router-link to="/components/HelloWorld">HelloWorldVue2</router-link>
    <router-view></router-view>
</template>

<script>
    import apiService from '../apiService'; // Import the API service
    import { useRouter } from 'vue-router';
    import { ref } from 'vue';
    import HelloWorldVue from './HelloWorld.vue';

    export default {  
        data() {
            return {
                navigationLinks: [], // Store navigation links
            }
        },
        mounted() {
            var router = useRouter();
            var test = 1;

            apiService.get('/TaspaApi/getVueJsNavigationLinks')
                .then(response => {
                    this.navigationLinks = response.data; 

                    var val1 = this.navigationLinks[0].linkAction;
                    var val2 = this.navigationLinks[0].linkText;

                    // TODO - using a string (not variable) is the only way (apparently) to set the component...figure out how to
                    //        dynamically do this.
                    if (val2 === 'HelloWorld') {
                        router.addRoute({
                            path: val1,
                            //component: () => import(val2),
                            component: () => import('./HelloWorld.vue')
                        });
                    }

                    //// TODO - ChatGPT example...works as long as the dynamicComponentName is a constant
                    //const dynamicComponentName = 'MyDynamicComponent'; // Replace with the actual component name as a string
                    //const dynamicRoute = {
                    //    path: '/dynamic-route',
                    //    name: 'DynamicRoute',
                    //    component: () => import(`./components/${dynamicComponentName}.vue`),
                    //};
                    //router.addRoute(dynamicRoute);

                    // should work
                    //const val3 = './HelloWorld.vue';
                    //router.addRoute({
                    //    path: val1,
                    //    //component: () => import(val2),
                    //    //component: () => import('./HelloWorld.vue')
                    //    component: () => import(val3)
                    //});

                    //works, but is hard coded
                    //router.addRoute({
                    //    path: '/components/HelloWorld',
                    //    component: () => import('./HelloWorld.vue')
                    //});

                })
                .catch(error => {
                    console.error('Error:', error);
                });
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
