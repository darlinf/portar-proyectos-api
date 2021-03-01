using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portar_proyectos_api.Data.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionNumber { get; set; }
        public int TeacherId { get; set; }
        public List<StudentSection> StudentSections { get; set; }
        //public int StudentId { get; set; }
        //public IList<StudentSection> StudentSections { get; set; }
    }
}
