using HospitalSysAPI.Data;
using HospitalSysAPI.Models;
using HospitalSysAPI.Repository.IRepository;

namespace HospitalSysAPI.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext dbcontext;
        public CartRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
