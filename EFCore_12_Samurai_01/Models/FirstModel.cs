using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_12_Samurai_01.Models
{
    public class FirstModel
    {
        public int FirstModelId { get; set; }
        public string FirstModelName { get; set; }
        public List<FirstModelSecondModelJoiningTable> JoiningTable { get; set; }
    }
}
