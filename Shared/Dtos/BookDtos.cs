using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class BookDto
    {
        public long BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuther { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookFilePath { get; set; }
        public int AcademicYearID { get; set; }
        public int TermID { get; set; }
    }

    public class BookForCreationDto
    {
        [Required]
        public IFormFile BookFile { get; set; } 
        [Required]
        public string BookName { get; set; }
        public string BookAuther { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int AcademicYearID { get; set; }
        [Required]
        public int TermID { get; set; }
    }
}
