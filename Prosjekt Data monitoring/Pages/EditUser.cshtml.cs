using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prosjekt_Data_monitoring.Models;
using Azure;
using System.Web;
using System.Security.Policy;

namespace Prosjekt_Data_monitoring.Pages
{
    public class EditUserModel : PageModel
    {
        SqlQuery sqlQuery;
        public EditUserModel(IConfiguration configuration)
        {
            sqlQuery = new SqlQuery(configuration);
        }

        public User user;
        public int UserId { get; set; }
        public void OnGet()
        {
            UserId = Convert.ToInt32(Request.Query["UserId"]);
            user = sqlQuery.GetUserData(UserId);
        }

        public IActionResult OnPost()
        {
            User userToEdit = new User();
            userToEdit.AccessLevel = Convert.ToInt32(Request.Form["inputAccessLevel"]);
            userToEdit.UserId = Convert.ToInt32(Request.Form["inputUserId"]);
            userToEdit.Password = Convert.ToString(Request.Form["inputPassword"]).Trim();
            userToEdit.CardCode = Convert.ToString(Request.Form["inputCardCode"]).Trim();
            userToEdit.FirstName = Convert.ToString(Request.Form["inputFirstName"]).Trim();
            userToEdit.LastName = Convert.ToString(Request.Form["inputLastName"]).Trim();
            userToEdit.PhoneNumber = Convert.ToInt32(Request.Form["inputPhoneNumber"]);
            userToEdit.Address = Convert.ToString(Request.Form["inputAddress"]).Trim();
            userToEdit.PostalCode = Convert.ToInt32(Request.Form["inputPostalCode"]);
            sqlQuery.EditUser(userToEdit);

            return RedirectToPage("/ChooseUserToEdit");
        }
    }
}
