using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Domain.Entities;

namespace Ulugbekivich.Service.Interfaces
{
    public interface IAuthManager
    {
        public string GenerateToken(Admin admin);
    }
}
