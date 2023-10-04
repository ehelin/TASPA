<template>
    <label>available links</label>
    <div v-for="(link, index) in navigationLinks" :key="index">
        <a :href="link.linkAction" @click="handleLinkClick">{{link.linkText}}</a>
    </div>
</template>

<script>
    import apiService from '../apiService'; // Import the API service

    export default {
        data() {
            return {
                navigationLinks: [], // Store navigation links
            }
        },

        methods: {
            handleLinkClick(event) {
                alert('Intercept each link here and update w/appropriate target for Tapsa Vue.js client or update api call two send two different result sets');
                // Prevent the default behavior of the link (navigating to the href)
                event.preventDefault();

                // You can perform custom actions here
                // For example, you can update a variable or perform a redirection
                // For demonstration, we'll set a variable to indicate the link was clicked
                this.linkClicked = true;
            }
        },

        mounted() {
            apiService.get('/TaspaApi/getVueJsNavigationLinks')
                .then(response => {
                    this.navigationLinks = response.data; 
                })
                .catch(error => {
                    console.error('Error:', error);
                });
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
