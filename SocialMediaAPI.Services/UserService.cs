using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    Name = model.Name,
                    Email = model.Email

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserProfiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserProfiles
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new UserListItem
                            {
                                Name = e.Name,
                                Email = e.Email
                            }
                            );
                return query.ToArray();
            }
        }

        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserProfiles
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new UserDetail
                    {
                        Name = entity.Name,
                        Email = entity.Email
                    };
            }
        }
    }
}
