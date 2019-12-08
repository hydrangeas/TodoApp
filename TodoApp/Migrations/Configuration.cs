namespace TodoApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoApp.Models.TodoesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TodoApp.Models.TodoesContext";
        }

        protected override void Seed(TodoApp.Models.TodoesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Migration実行後に実行される処理
            // 初期データを入れるのに使われる

            User admin = new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "password",
                Roles = new List<Role>()
            };
            User user = new User()
            {
                Id = 2,
                UserName = "user",
                Password = "password",
                Roles = new List<Role>()
            };
            Role administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrator",
                Users = new List<User>()
            };
            Role users = new Role()
            {
                Id = 2,
                RoleName = "User",
                Users = new List<User>()
            };

            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);
            user.Roles.Add(users);
            users.Users.Add(user);

            context.Users.AddOrUpdate(u => u.Id, new User[] { admin, user });
            context.Roles.AddOrUpdate(r => r.Id, new Role[] { administrators, users });
        }
    }
}
