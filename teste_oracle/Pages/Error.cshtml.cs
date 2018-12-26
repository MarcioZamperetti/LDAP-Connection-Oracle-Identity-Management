using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace teste_oracle.Pages
{
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public static string error { get; set; }
        public string logerro { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            logerro = error;
        }
    }
}
