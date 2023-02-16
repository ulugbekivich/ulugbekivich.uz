using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Service.Dtos.Admins;

namespace Ulugbekivich.Service.Interfaces.Admins
{
    public interface IAdminService
    {
        public Task<string> AdminLoginAsync(AdminLoginDto adminLoginDto);
    }
}
