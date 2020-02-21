using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_12_Samurai_01.Models
{
    public class SecondModel
    {
        public int SecondModelId { get; set; }
        public string SecondModelName { get; set; }

        public List<FirstModelSecondModelJoiningTable> JoiningTable { get; set; }
    }
}
