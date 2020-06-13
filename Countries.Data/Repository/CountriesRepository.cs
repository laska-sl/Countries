using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Countries.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Countries.Data.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly DataContext dataContext;

        public CountriesRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Add<T>(T entity) where T : class
        {
            this.dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.dataContext.Remove(entity);
        }

        public async Task<bool> SaveAllAsync(CancellationToken cancellationToken)
        {
            return await this.dataContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Country> GetCountryAsync(string name, CancellationToken cancellationToken)
        {
            return await this.dataContext.Countries
                .Include(country => country.Capital)
                .Include(country => country.Region)
                .FirstOrDefaultAsync(country => country.Name == name, cancellationToken);
        }

        public async Task<Country> GetCountryByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return await this.dataContext.Countries.FirstOrDefaultAsync(country => country.Code == code, cancellationToken);
        }

        public async Task<Region> GetRegionAsync(string name, CancellationToken cancellationToken)
        {
            return await this.dataContext.Regions.FirstOrDefaultAsync(region => region.Name == name, cancellationToken);
        }

        public async Task<City> GetCityAsync(string name, CancellationToken cancellationToken)
        {
            return await this.dataContext.Cities.FirstOrDefaultAsync(city => city.Name == name, cancellationToken);
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken)
        {
            return await this.dataContext.Countries
                .Include(country => country.Capital)
                .Include(country => country.Region)
                .ToListAsync(cancellationToken);
        }
    }
}
