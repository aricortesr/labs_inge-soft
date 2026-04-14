<template>
  <div class="d-flex justify-content-center align-items-center vh-100">
    <div class="card p-4 shadow" style="max-width: 400px; width: 100%">
      <h3 class="text-center">Formulario de creación de países</h3>

      <form @submit.prevent="saveCountry">
        <div class="form-group">
          <label>Nombre:</label>
          <input v-model="formData.Name" class="form-control" required />
        </div>

        <div class="form-group">
          <label>Continente:</label>
          <select v-model="formData.Continent" class="form-control" required>
            <option value="" disabled>Seleccione un continente</option>
            <option>África</option>
            <option>Asia</option>
            <option>Europa</option>
            <option>América</option>
            <option>Oceanía</option>
            <option>Antártida</option>
          </select>
        </div>

        <div class="form-group">
          <label>Idioma:</label>
          <input v-model="formData.Language" class="form-control" required />
        </div>

        <button class="btn btn-success mt-3 w-100">Guardar</button>
      </form>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      formData: {
        Name: "",
        Continent: "",
        Language: "",
      },
    };
  },
  methods: {
    saveCountry() {
      axios
        .post("http://localhost:5000/api/Country", {
          Name: this.formData.Name,
          Continent: this.formData.Continent,
          Language: this.formData.Language,
        })
        .then(() => {
          window.location.href = "/";
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>