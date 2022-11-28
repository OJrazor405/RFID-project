namespace Prosjekt_Data_monitoring.Models
{
    public class MasterUser : User
    {
        public MasterUser(int userId)
        {
            UserId = userId;
            AccessLevel = 2;
        }

    }
}
