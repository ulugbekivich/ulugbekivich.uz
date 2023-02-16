using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Domain.Common;

namespace Ulugbekivich.Domain.Entities
{
    public class Admin : Auditable
    {
        public string FullName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
    }
}
