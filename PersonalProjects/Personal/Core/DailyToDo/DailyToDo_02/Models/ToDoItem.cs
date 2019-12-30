using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyToDo_02.Models
{
    public class ToDoItem
    {
        public int ToDoItemId { get; set; }
        public string ItemDescription { get; set; }

        public int ItemPoints { get; set; }
    }
}
