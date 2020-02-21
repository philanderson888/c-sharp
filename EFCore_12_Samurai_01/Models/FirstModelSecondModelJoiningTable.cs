using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_12_Samurai_01.Models
{
    public class FirstModelSecondModelJoiningTable
    {
        public int FirstModelId { get; set; }

        public FirstModel FirstModel { get; set; }
        public int SecondModelId { get; set; }

        public SecondModel SecondModel { get; set; }
    }
}
