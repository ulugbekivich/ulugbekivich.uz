using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.DataAccess.DbContexts;
using Ulugbekivich.DataAccess.Interfaces;
using Ulugbekivich.DataAccess.Interfaces.Admins;
using Ulugbekivich.DataAccess.Interfaces.Projects;
using Ulugbekivich.DataAccess.Repositories.Admins;
using Ulugbekivich.DataAccess.Repositories.Projects;

namespace Ulugbekivich.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public IProjectRepository Projects { get; }
        public IAdminRepository Admins { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
            Projects = new ProjectRepository(appDbContext);
            Admins = new AdminRepository(appDbContext);
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return dbContext.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
