<template>
    <navigationLinks  />
    <br />
    <!--<HelloWorldVue />-->
</template>

<script>
    import navigationLinks from './components/NavigationLinks.vue'
    import HelloWorldVue from './components/HelloWorld.vue';

    export default {
        // Register components here
        components: {     
            navigationLinks,
            HelloWorldVue
        },

        data() {
            //return {
            //    count: 0//,
            //    apiData: '', // Store the API response data
            //}
        },

        methods: {
            //sayHello() {
            //    alert('say hello there!')
            //}
        },

        // Lifecycle hooks are called at different stages
        mounted() {
            console.log(`Lifecycle hooks are called at different stages - Mounted() has been called`)
        }
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
