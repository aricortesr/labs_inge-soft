<template>
    <div class="container mt-5">
        <h1 class="display-4 text-center">Lista de países</h1>
        <div class="row justify-content-end">
            <div class="col-2">
                <router-link to="/country">
                    <button type="button" class="btn btn-outline-secondary float-right">
                        Agregar país
                    </button>
                </router-link>
            </div>
        </div>
        <table class="table is-bordered is-striped is-narrow is-hoverable
is-fullwidth">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(country, index) of countries" :key="index">
                    <td>{{ country.name }}</td>
                    <td>{{ country.continent }}</td>
                    <td>{{ country.language }}</td>
                    <td>
                        <button class="btn btn-secondary btn-sm">Editar</button>
                        <button class="btn btn-danger btn-sm" @click="deleteCountry(country.id, country.name)">Eliminar</button>
                    </td>
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
            deleteCountry(id, name) {
                if (confirm(`Confirme que desea eliminar a ${name}?`)) {
                    axios
                        .delete(`http://localhost:5000/api/country/${id}`)
                        .then((response) => {
                            if (response.data === true) {
                                console.log(`País ${name} eliminado con éxito.`);

                                this.countries = this.countries.filter(c => c.id !== id);
                            }
                        })
                        .catch((error) => {
                            console.error("Error al intentar eliminar el país:", error);
                        });
                }
        }
    },
    mounted() {
        this.getCountries();
    }
};
</script>