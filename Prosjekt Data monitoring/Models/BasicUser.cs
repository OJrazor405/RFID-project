namespace Prosjekt_Data_monitoring.Models
{
    public class BasicUser : User
    {
        public BasicUser(int userId)
        {
            UserId = userId;
            AccessLevel = 1;
        }
    }
}
