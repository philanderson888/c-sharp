using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2019_09_19_API_Core_From_Scratch.Models
{
    public class ToDo
    {
        public long ToDoId { get; set; }
        public string ToDoItem { get; set; }
        public bool ToDoDone { get; set; }
    }
}
