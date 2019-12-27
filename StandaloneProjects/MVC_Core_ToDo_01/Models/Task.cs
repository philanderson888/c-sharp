using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Core_ToDo_01.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
