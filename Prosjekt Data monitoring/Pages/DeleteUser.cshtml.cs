using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prosjekt_Data_monitoring.Models;

namespace Prosjekt_Data_monitoring.Pages
{
    public class DeleteUserModel : PageModel
    {
        SqlQuery sqlQuery;
        public DeleteUserModel(IConfiguration configuration)
        {
            sqlQuery = new SqlQuery(configuration);
        }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            int userId = Convert.ToInt32(Request.Form["inputUserId"]);
            sqlQuery.DeleteUser(userId);
        }
    }

}
