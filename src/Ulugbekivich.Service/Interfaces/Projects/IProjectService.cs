using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Service.Dtos.Projects;

namespace Ulugbekivich.Service.Interfaces.Projects
{
    public interface IProjectService
    {
        public Task<bool> CreateProjectAsync(CreateProjectDto dto);
    }
}
