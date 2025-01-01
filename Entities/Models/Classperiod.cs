using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    //الحصة الاولى - التانية - وهكذا .......
    public class Classperiod
    {
        [Key]
        public int ClassperiodId { get; set; }
        public string ClassperiodName { get; set; }
    }
}
