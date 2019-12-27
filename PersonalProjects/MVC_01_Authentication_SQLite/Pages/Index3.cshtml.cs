using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC_01_Authentication_SQLite.Pages
{
    public class Index3Model : PageModel
    {
        private readonly ILogger<Index3Model> _logger;

        public Index3Model(ILogger<Index3Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
