using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MenuComponentDto:IDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Index { get; set; }
        public string Icon { get; set; }
    }
}
