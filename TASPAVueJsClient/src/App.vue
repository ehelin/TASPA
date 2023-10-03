<template>
    <navigationLinks  />
</template>

<script>
    import navigationLinks from './components/NavigationLinks.vue'

    export default {
        // Register components here
        components: {            
            navigationLinks
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
        // of a component's lifecycle.
        // This function will be called when the component is mounted.
        mounted() {
            //console.log(`Lifecycle hooks are called at different stages - Mounted() has been called`)

            //apiService.get('/TaspaApi/getNavigationLinks')
            //    .then(response => {
            //        this.apiData = response.data; 
            //    })
            //    .catch(error => {
            //        console.error('Error:', error);
            //    });
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
