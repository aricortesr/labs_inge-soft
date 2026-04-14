<template>
    <div class="container mt-4">
        <h2>Lista de Países</h2>

        <div class="row justify-content-end mb-3">
            <div class="col-2">
                <a href="/country">
                    <button class="btn btn-outline-secondary">
                        Agregar país
                    </button>
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
                    <td>{{ c.Name }}</td>
                    <td>{{ c.Continent }}</td>
                    <td>{{ c.Language }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios";

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
                    });
            },
        },
        created() {
            this.getCountries();
        },
    };
</script>