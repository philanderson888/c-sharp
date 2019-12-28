using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyApp_01.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public string Item { get; set; }
        public int Points { get; set; }

        public string UserId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
