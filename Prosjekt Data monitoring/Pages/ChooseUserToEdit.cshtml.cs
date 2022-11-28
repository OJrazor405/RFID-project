using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prosjekt_Data_monitoring.Models;
using Azure;

namespace Prosjekt_Data_monitoring.Pages
{
    public class ChooseUserToEditModel : PageModel
    {

        public void OnGet()
        {
        }
        public string UserId { get; set; }

        public IActionResult OnPost()
        {
            UserId = Convert.ToString(Request.Form["inputUserId"]);
            return LocalRedirect("/EditUser?UserId=" + UserId);
        }
    }
}
