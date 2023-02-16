using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.DataAccess.Interfaces.Admins;
using Ulugbekivich.DataAccess.Interfaces.Projects;

namespace Ulugbekivich.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IProjectRepository Projects { get; }

        public IAdminRepository Admins { get; }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync();
    }
}
