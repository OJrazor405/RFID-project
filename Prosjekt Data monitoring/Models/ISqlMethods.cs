namespace Prosjekt_Data_monitoring.Models
{
    public interface ISqlMethods
    {
        public bool CheckAccessAndLog(int userId, string password);
        public int GetAccessLevel(int userId);
        public List<User> GetLog(string view);
        public int GetNextUserId();
        User GetUserData(int userId);
        void CreateNewUser(User user);
        void DeleteUser(int userId);
        void EditUser(User user);
    }
}
