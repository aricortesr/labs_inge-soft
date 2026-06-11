<template>
    <div class="container mt-4">
        <h2>Lista de Países</h2>

        <div class="row justify-content-end mb-3">
            <div class="col-2">
                <a href="/country">
                    <router-link to="/country">
                        <button class="btn btn-outline-secondary">
                            Agregar país
                        </button>
                    </router-link>
                </a>
            </div>
        </div>

        <table class="table">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="c in countries" :key="c.id">
                    <td>{{ c.name }}</td>
                    <td>{{ c.continent }}</td>
                    <td>{{ c.language }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>import axios from "axios";

export default {
    data() {
        return {
            countries: [],
        };
    },
    methods: {
        getCountries() {
            axios
                .get("http://localhost:5000/api/country")
                .then((response) => {
                    this.countries = response.data;
                })
                .catch((error) => {
                    console.error("Error capturado en la petición:", error);
                });
        },
    },
    mounted() {
        this.getCountries();
    },
};</script>