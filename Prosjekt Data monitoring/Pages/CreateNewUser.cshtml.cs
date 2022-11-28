using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prosjekt_Data_monitoring.Models;

namespace Prosjekt_Data_monitoring.Pages
{
    public class CreateNewUserModel : PageModel
    {
        SqlQuery sqlQuery;
        public CreateNewUserModel(IConfiguration configuration)
        {
            sqlQuery = new SqlQuery(configuration);
        }

        public int NextUserId;

        public void OnGet()
        {
            NextUserId = sqlQuery.GetNextUserId();
        }

        public void OnPost()
        {
            User user = new User();
            user.AccessLevel = Convert.ToInt32(Request.Form["inputAccessLevel"]);
            user.UserId = Convert.ToInt32(Request.Form["inputUserId"]);
            user.Password = Convert.ToString(Request.Form["inputPassword"]);
            user.CardCode = Convert.ToString(Request.Form["inputCardCode"]);
            user.FirstName = Convert.ToString(Request.Form["inputFirstName"]);
            user.LastName = Convert.ToString(Request.Form["inputLastName"]);
            user.PhoneNumber = Convert.ToInt32(Request.Form["inputPhoneNumber"]);
            user.Address = Convert.ToString(Request.Form["inputAddress"]);
            user.PostalCode = Convert.ToInt32(Request.Form["inputPostalCode"]);

            sqlQuery.CreateNewUser(user);
            NextUserId = sqlQuery.GetNextUserId();
        }
    }
}
