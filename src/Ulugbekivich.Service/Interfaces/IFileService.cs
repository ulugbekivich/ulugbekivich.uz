using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulugbekivich.Service.Interfaces
{
    public interface IFileService
    {
        public Task<string> SaveImageAsync(IFormFile image);
    }
}
