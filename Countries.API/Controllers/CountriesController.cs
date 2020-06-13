using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Countries.Data.DTOs;
using Countries.Data.Models;
using Countries.Data.Repository;

using Microsoft.AspNetCore.Mvc;

namespace Countries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository countriesRepository;

        private readonly IMapper mapper;

        public CountriesController(ICountriesRepository countriesRepository, IMapper mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
        {
            var countries = await this.countriesRepository.GetCountriesAsync(cancellationToken);

            var countriesDTO = this.mapper.Map<IEnumerable<CountryDTO>>(countries);

            return this.Ok(countriesDTO);
        }

        [HttpGet("{Name}", Name = "GetCountry")]
        public async Task<IActionResult> GetCountry(string name, CancellationToken cancellationToken)
        {
            var country = await this.countriesRepository.GetCountryAsync(name, cancellationToken);

            var countryDTO = this.mapper.Map<CountryDTO>(country);

            return this.Ok(countryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody]CountryDTO countryDTO, CancellationToken cancellationToken)
        {
            var capital = await this.countriesRepository.GetCityAsync(countryDTO.CapitalName, cancellationToken);

            if (capital == null)
            {
                capital = new City {Name = countryDTO.CapitalName};
                this.countriesRepository.Add(capital);
            }

            var region = await this.countriesRepository.GetRegionAsync(countryDTO.RegionName, cancellationToken);

            if (region == null)
            {
                region = new Region {Name = countryDTO.RegionName};
                this.countriesRepository.Add(region);
            }

            var country = await this.countriesRepository.GetCountryByCodeAsync(countryDTO.Code, cancellationToken);

            if (country != null)
            {
                country = this.mapper.Map<Country>(countryDTO);

                country.Capital = capital;
                country.Region = region;
            }
            else
            {
                country = this.mapper.Map<Country>(countryDTO);

                country.Capital = capital;
                country.Region = region;

                this.countriesRepository.Add(country);
            }

            if (await this.countriesRepository.SaveAllAsync(cancellationToken))
            {
                return this.NoContent();
            }

            return this.BadRequest("Could not add the country");
        }
    }
}
