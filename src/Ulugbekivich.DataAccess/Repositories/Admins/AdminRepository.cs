using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.DataAccess.DbContexts;
using Ulugbekivich.DataAccess.Interfaces.Admins;
using Ulugbekivich.DataAccess.Interfaces.Projects;
using Ulugbekivich.Domain.Entities;

namespace Ulugbekivich.DataAccess.Repositories.Admins
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
