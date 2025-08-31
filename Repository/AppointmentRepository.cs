using Microsoft.EntityFrameworkCore;
using HospitalSysAPI.Data;
using HospitalSysAPI.Repository.IRepository;
using HospitalSysAPI.Models;

namespace HospitalSysAPI.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext dbcontext;
        public AppointmentRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
