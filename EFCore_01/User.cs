using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_10
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
