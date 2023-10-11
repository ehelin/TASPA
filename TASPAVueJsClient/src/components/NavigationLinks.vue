<template>
    <label>available links</label>
    <div v-for="(link, index) in navigationLinks" :key="index">
        <router-link :to="link.linkAction">{{link.linkText}}</router-link>
    </div>
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
        methods: {
            getComponent(component) {
                if (component === 'HelloWorld')
                {
                    const component = 'HelloWorld';
                    return component;
                }
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

                    const dynamicComponentName = this.getComponent(val2); // Replace with the actual component name as a string
                    const dynamicRoute = {
                        path: val1,
                        name: val2,
                        component: () => import(`./${dynamicComponentName}.vue`),
                    };
                    router.addRoute(dynamicRoute);

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
