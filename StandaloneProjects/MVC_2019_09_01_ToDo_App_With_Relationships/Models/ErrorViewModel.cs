using System;

namespace MVC_2019_09_01_ToDo_App_With_Relationships.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}