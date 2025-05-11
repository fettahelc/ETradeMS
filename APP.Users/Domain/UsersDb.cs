using Microsoft.EntityFrameworkCore;

namespace APP.Users.Domain
{
    /// <summary>
    /// Represents the database context for managing users, roles, skills, and user skills.
    /// </summary>
    public class UsersDb : DbContext
    {
        /// <summary>
        /// Gets or sets the Users table.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the Roles table.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the Skills table.
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the UserSkills table, which represents the many-to-many relationship between users and skills.
        /// </summary>
        public DbSet<UserSkill> UserSkills { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDb"/> class using the provided database options.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public UsersDb(DbContextOptions options) : base(options)
        {
        }
    }
}
