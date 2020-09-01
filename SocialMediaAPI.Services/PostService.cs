using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreatePost(PostCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    Id = model.Id,
                    Title = model.Title,
                    Text = model.Text,
                    Name = model.Name,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new PostListItem
                            {
                                Id = e.Id,
                                Title = e.Title
                            }
                            );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }
    }
}
