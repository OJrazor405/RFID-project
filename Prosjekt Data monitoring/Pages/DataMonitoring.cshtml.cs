using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prosjekt_Data_monitoring.Models;

namespace Prosjekt_Data_monitoring.Pages
{
    public class DataMonitoringModel : PageModel
    {
        public List<User> dataToBeShown = new List<User>();
        SqlQuery sqlQuery;
        string? requestView;
        public DataMonitoringModel(IConfiguration configuration)
        {
            sqlQuery = new SqlQuery(configuration);
        }

        public void OnPost()
        {
            requestView = Convert.ToString(Request.Form["Choice"]);
            dataToBeShown = ShowData(requestView);
        }

        public List<User> ShowData(string requestView)
        {
            string viewFromDb;
            List<User> data = new List<User>();
            if (requestView != null)
            {
                if (requestView == "showUserLogin")
                {
                    viewFromDb = "loginView";
                    data = sqlQuery.GetLog(viewFromDb);
                }
                else if (requestView == "showAccessLog")
                {
                    viewFromDb = "accessView";
                    data = sqlQuery.GetLog(viewFromDb);
                }
            }
            return data;
        }
    }
}
