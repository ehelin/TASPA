<template>
    <!--<img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>-->
    <button @click="sayHello">Click to say hello!</button>
    <br />
    <label>API Test Call</label>
    <br />
    <p>{{this.apiData}}</p>
</template>

<script>
    import apiService from './apiService'; // Import the API service

    export default {
        // Properties returned from data() become reactive state
        // and will be exposed on `this`.
        data() {
            return {
                //count: 0//,
                apiData: '', // Store the API response data
            }
        },

        // Methods are functions that mutate state and trigger updates.
        // They can be bound as event handlers in templates.
        methods: {
            sayHello() {
                alert('say hello there!')
            }
        },

        // Lifecycle hooks are called at different stages
        // of a component's lifecycle.
        // This function will be called when the component is mounted.
        mounted() {
            console.log(`Mounted() has been called`)

            //// Make a GET request to your .NET 6 API
            apiService.get('/TaspaApi/getLastVerbListUsed') // Replace with your API's endpoint
                .then(response => {
                    this.apiData = response.data; // Store the API response data in your component's data
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
