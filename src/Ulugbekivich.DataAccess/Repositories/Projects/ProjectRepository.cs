using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.DataAccess.DbContexts;
using Ulugbekivich.DataAccess.Interfaces.Projects;
using Ulugbekivich.Domain.Entities;

namespace Ulugbekivich.DataAccess.Repositories.Projects
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
