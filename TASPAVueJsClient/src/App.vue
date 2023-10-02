<template>
      <!--<img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>-->
    <button @click="sayHello">Click to say hello!</button>
</template>

<script>
    export default {
        // Properties returned from data() become reactive state
        // and will be exposed on `this`.
        data() {
            return {
                count: 0
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
