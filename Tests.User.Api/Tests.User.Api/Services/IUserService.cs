namespace Tests.User.Api.Services
{
    public interface IUserService
    {
        Models.User GetUserById(int id);
        void CreateUser(Models.User user);
        void UpdateUser(Models.User user);
        void DeleteUser(int id);
    }
}