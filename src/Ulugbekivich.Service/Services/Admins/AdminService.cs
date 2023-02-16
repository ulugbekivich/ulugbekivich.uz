using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.DataAccess.Interfaces;
using Ulugbekivich.DataAccess.Repositories;
using Ulugbekivich.Service.Common.Exceptions;
using Ulugbekivich.Service.Dtos.Admins;
using Ulugbekivich.Service.Exceptions;
using Ulugbekivich.Service.Interfaces;
using Ulugbekivich.Service.Interfaces.Admins;
using Ulugbekivich.Service.Security;

namespace Ulugbekivich.Service.Services.Admins
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;

        public AdminService(IUnitOfWork unitOfWork, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _authManager = authManager;
        }
        public async Task<string> AdminLoginAsync(AdminLoginDto adminLoginDto)
        {
            var res = await _unitOfWork.Admins.FirstOrDefaultAsync(x => x.Email == adminLoginDto.Email);
            if (res == null) { throw new ModelErrorException(nameof(adminLoginDto.Email), "Admin not found, Email is incorrect!"); }

            if (PasswordHasher.Verify(adminLoginDto.Password, res.Salt, res.PasswordHash))
                return _authManager.GenerateToken(res);

            throw new ModelErrorException(nameof(adminLoginDto.Password), "Password is wrong");
        }
    }
}
