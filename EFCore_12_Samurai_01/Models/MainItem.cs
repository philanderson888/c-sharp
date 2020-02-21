using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_12_Samurai_01.Models
{
    public class MainItem
    {
        public int MainItemId { get; set; }
        public string MainItemName { get; set; }

        public SubItem SubItem { get; set; }
    }
}
