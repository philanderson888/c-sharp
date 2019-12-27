using System;

namespace MVC_FamilyApp_2019_11_02_Core_SQL.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}