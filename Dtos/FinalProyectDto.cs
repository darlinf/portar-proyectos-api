using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portar_proyectos_api.Dtos
{
    public class FinalProyectDto
    {
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile File { get; set; }
    }
}
