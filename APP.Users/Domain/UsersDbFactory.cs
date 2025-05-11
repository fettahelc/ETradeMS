using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace APP.Users.Domain
{
    public class UsersDbFactory : IDesignTimeDbContextFactory<UsersDb>
    {
        public UsersDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersDb>();
            optionsBuilder.UseSqlite("data source=UsersDB");
            return new UsersDb(optionsBuilder.Options);
        }

        public void Seed()
        {
            var db = CreateDbContext(null);

            #region Deleting Current Data
            var userSkills = db.UserSkills.ToList();
            db.UserSkills.RemoveRange(userSkills);

            var users = db.Users.ToList();
            db.Users.RemoveRange(users);

            var roles = db.Roles.ToList();
            db.Roles.RemoveRange(roles);
            #endregion

            #region Inserting Initial Data
            db.Roles.Add(new Role()
            {
                Name = "Admin",
                Users = new List<User>()
                {
                    new User()
                    {
                        IsActive = true,
                        Password = "admin",
                        UserName = "admin"
                    }
                }
            });
            db.Roles.Add(new Role()
            {
                Name = "User",
                Users = new List<User>()
                {
                    new User()
                    {
                        IsActive = true,
                        Password = "user",
                        UserName = "user"
                    }
                }
            });
            #endregion

            db.SaveChanges();
        }
    }
}
