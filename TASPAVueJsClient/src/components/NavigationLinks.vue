<template>
    <label>available links</label>
    <div v-for="(link, index) in navigationLinks" :key="index">
        <router-link :to="link.linkAction">{{link.linkText}}</router-link>
    </div>
    <router-view></router-view>
</template>

<script>
    import apiService from '../apiService'; 
    import { useRouter } from 'vue-router';

    export default {  
        data() {
            return {
                navigationLinks: [], // Store navigation links
            }
        },
        methods: {
            // the 'component' part has to be a constant string (no dynamic variables allowed (apparently))...list and server half to be in sync
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

            apiService.get('/TaspaApi/getVueJsNavigationLinks')
                .then(response => {
                    this.navigationLinks = response.data; 

                    // add route for each link
                    this.navigationLinks.forEach((item) => {
                        // the 'component' part has to be a constant string (no dynamic variables allowed (apparently))...list and server half to be in sync
                        const dynamicComponentName = this.getComponent(item.linkText); 

                        //add route
                        const dynamicRoute = {
                            path: item.linkAction,
                            name: item.linkText,
                            component: () => import(`./${dynamicComponentName}.vue`),
                        };
                        router.addRoute(dynamicRoute);
                    });

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
