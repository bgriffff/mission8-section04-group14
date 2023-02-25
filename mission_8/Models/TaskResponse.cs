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
        public string Quadrant { get; set; }


        public bool Completed { get; set; }

        //Foreign Key
        public int CategoryId { get; set; }

        //This creates the relationship from this table to the Category table
        public Category Category { get; set; }
    }
}