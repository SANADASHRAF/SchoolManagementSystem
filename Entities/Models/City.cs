using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {

        // Relationships
        public virtual ICollection<Student> Student { get; set; }=new List<Student>();
    }
}
