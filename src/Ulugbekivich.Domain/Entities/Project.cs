using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Domain.Common;

namespace Ulugbekivich.Domain.Entities
{
    public class Project : Auditable
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;
    }
}
