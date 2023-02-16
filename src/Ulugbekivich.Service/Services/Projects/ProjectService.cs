using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.DataAccess.Interfaces;
using Ulugbekivich.DataAccess.Repositories;
using Ulugbekivich.Domain.Entities;
using Ulugbekivich.Service.Common.Exceptions;
using Ulugbekivich.Service.Dtos.Projects;
using Ulugbekivich.Service.Exceptions;
using Ulugbekivich.Service.Interfaces;
using Ulugbekivich.Service.Interfaces.Projects;

namespace Ulugbekivich.Service.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ProjectService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }
        public async Task<bool> CreateProjectAsync(CreateProjectDto dto)
        {
            var res = await _unitOfWork.Projects.FirstOrDefaultAsync(x => x.Name == dto.ProjectName);
            if (res is not null)
                throw new ModelErrorException(nameof(dto.ProjectName), "Project is already exist");

            Project project = (Project)dto;

            if(dto.Image is not null)
            {
                project.ImagePath = await _fileService.SaveImageAsync(dto.Image);
            }

            _unitOfWork.Projects.Add(project);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
