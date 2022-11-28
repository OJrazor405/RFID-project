namespace Prosjekt_Data_monitoring.Models
{
    public class User
    {
        public int UserId { get; set; }
        private string? password;

        public string? Password
        {
            get { return password; }
            set { password = value; }
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int AccessLevel { get; set; }
        public string? CardCode { get; set; }
        public string? Address { get; set; }
        public int PostalCode { get; set; }
        public DateTime TimeStamp { get; set; }

        public User()
        {

        }

        public User? GetUserType(int userId, int accessLevel)
        {
            User? user = null;
            if (accessLevel == 1)
            {
                user = new BasicUser(userId);
            }
            else if (accessLevel == 2)
            {
                user = new MasterUser(userId);
            }
            return user;
        }
    }
}
