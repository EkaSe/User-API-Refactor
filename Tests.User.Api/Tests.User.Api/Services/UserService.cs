namespace Tests.User.Api.Services
{
    public class UserService: IUserService
    {
        public Models.User GetUserById(int id)
        {
            using var context = new DatabaseContext();
            return context.Users.SingleOrDefault(u => u.Id == id);
        }

        public void CreateUser(Models.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            using var context = new DatabaseContext();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(Models.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            using var context = new DatabaseContext();
            context.Users.Update(user);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            using var context = new DatabaseContext();
            var user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}