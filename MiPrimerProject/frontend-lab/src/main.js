import { createApp } from "vue";
import App from "./App.vue";
import { createRouter, createWebHashHistory } from "vue-router";
import CountriesList from "./components/CountriesList.vue";
import CountryForm from "./components/CountryForm.vue";

const routes = [
    { path: "/", name: "home", component: CountriesList },
    { path: "/country", name: "country", component: CountryForm },
];

const router = createRouter({
    history: createWebHashHistory(),
    routes,
});

createApp(App).use(router).mount("#app");