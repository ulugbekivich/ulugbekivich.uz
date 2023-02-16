using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Domain.Entities;
using Ulugbekivich.Service.Common.Attributes;
using Ulugbekivich.Service.Common.Helpers;

namespace Ulugbekivich.Service.Dtos.Projects
{
    public class CreateProjectDto
    {
        [Required, MaxLength(60), MinLength(2)]
        public string ProjectName { get; set; } = string.Empty;
        [Required]
        public string ProjectDescription { get; set; } = string.Empty;

        [Required, MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required]
        public string ProjectLink { get; set; } = string.Empty;

        public static implicit operator Project(CreateProjectDto dto)
        {
            return new Project()
            {
                Name = dto.ProjectName,
                Description = dto.ProjectDescription,
                Link= dto.ProjectLink,
                CreatedAt = TimeHelper.GetCurrentServerTime()
            };
        }
    }
}
