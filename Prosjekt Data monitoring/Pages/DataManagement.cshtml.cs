using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prosjekt_Data_monitoring.Pages
{
    public class DataManagementModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            
        }

        public IActionResult GetNextUserId()
        {
            return LocalRedirect("/Login");
        }
    }
}
