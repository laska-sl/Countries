using AutoMapper;

using Countries.Data.DTOs;
using Countries.Data.Models;

namespace Countries.Data.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            this.CreateMap<Country, CountryDTO>()
                .ForMember(countryDTO => countryDTO.CapitalName, 
                    opt => opt.MapFrom(country => country.Capital.Name))
                .ForMember(countryDTO => countryDTO.RegionName,
                    opt => opt.MapFrom(country => country.Region.Name));

            this.CreateMap<CountryDTO, Country>();
        }
    }
}