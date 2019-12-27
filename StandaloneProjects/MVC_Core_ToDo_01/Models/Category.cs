using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_ToDo_01.Models
{
    public class Category
    {
        public Category()
        {
            Tasks = new HashSet<Models.Task>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Models.Task> Tasks { get; set; }

    }
}
