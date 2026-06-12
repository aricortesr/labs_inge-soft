using backend_lab.Models;
using backend_lab.Repositories;

namespace backend_lab.Services
{
    public class CountryService
    {
        private readonly CountryRepository countryRepository;

        public CountryService(string connectionString)
        {
            countryRepository = new CountryRepository(connectionString);
        }

        public List<CountryModel> GetCountries()
        {
            return countryRepository.GetCountries();
        }

        public string CreateCountry(CountryModel country)
        {
            var result = string.Empty;

            try
            {
                var isCreated = countryRepository.CreateCountry(country);

                if (!isCreated)
                {
                    result = "Error al crear el país";
                }
            }
            catch (Exception)
            {
                result = "Error creando país";
            }

            return result;
        }

        public string DeleteCountry(int id)
        {
            var result = string.Empty;

            try
            {
                var isDeleted = countryRepository.DeleteCountry(id);

                if (!isDeleted)
                {
                    result = "Error al eliminar el país de la base de datos";
                }
            }
            catch (Exception)
            {
                result = "Ocurrió un error inesperado al intentar eliminar el país";
            }

            return result;
        }
    }
}