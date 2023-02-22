using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission_8.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        
        [Required]
        public string Task { get; set; }
        public string DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public bool Completed { get; set; }
    }
}