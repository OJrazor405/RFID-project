using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Prosjekt_Data_monitoring.Models;

namespace Prosjekt_Data_monitoring.Pages
{
    public class LoginModel : PageModel
    {
        SqlQuery sqlQuery;
        User user;
        public bool Access { get; set; }
        public int AccessLevel { get; set; }

        public LoginModel(IConfiguration configuration)
        {
            sqlQuery = new SqlQuery(configuration);
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            int userId;
            string password;
            User userTemp = new User();
            try
            {
                userId = Convert.ToInt32(Request.Form["inputUserId"]);
                password = Convert.ToString(Request.Form["inputPassword"]);
                Access = sqlQuery.CheckAccessAndLog(userId, password);
                if (Access == true)
                {
                    AccessLevel = sqlQuery.GetAccessLevel(userId);
                    user = userTemp.GetUserType(userId, AccessLevel);
                }


            }
            catch (Exception)
            {
                ViewData["loginError"] = "Invalid input";
            }

            return RedirectToPage(user);
        }

        public IActionResult RedirectToPage(User user)
        {
            IActionResult result = LocalRedirect("/Login");
            if (user != null)
            {
                try
                {
                    if (user is BasicUser)
                    {
                        result = LocalRedirect("/DemoUserPage");
                    }
                    else if (user is MasterUser)
                    {
                        result = LocalRedirect("/DemoUserPage");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    ViewData["loginError"] = "Invalid input";
                }
            }

            return result;
        }


    }
}
