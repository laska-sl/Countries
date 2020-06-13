using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Countries.Data.Models;

namespace Countries.Data.Repository
{
    public interface ICountriesRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAllAsync(CancellationToken cancellationToken);

        Task<Country> GetCountryAsync(string name, CancellationToken cancellationToken);

        Task<Country> GetCountryByCodeAsync(string code, CancellationToken cancellationToken);

        Task<Region> GetRegionAsync(string name, CancellationToken cancellationToken);

        Task<City> GetCityAsync(string name, CancellationToken cancellationToken);

        Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken);
    }
}
