using System.Data.Entity;
using System.Linq;
using Model;
using Repository.Common;

namespace Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context)
              : base(context)
        {
        }
        public Country GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
