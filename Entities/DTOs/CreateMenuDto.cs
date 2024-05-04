using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CreateMenuDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ViewIndex { get; set; }
        public string icon { get; set; }
    }
}
