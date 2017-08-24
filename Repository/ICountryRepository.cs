using Model;
using Repository.Common;

namespace Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }
}
