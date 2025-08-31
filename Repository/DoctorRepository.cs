using Microsoft.EntityFrameworkCore;
using HospitalSysAPI.Data;
using HospitalSysAPI.Models;
using HospitalSysAPI.Repository.IRepository;

namespace HospitalSysAPI.Repository
{
    public class DoctorRepository : Repository<Doctor>,IDoctorRepository
    {
        private readonly ApplicationDbContext dbcontext;
        public DoctorRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}