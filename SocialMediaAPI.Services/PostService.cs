﻿using SocialMediaAPI.Data;
using SocialMediaAPI.Models;
using System;
using System.Collections.Generic;
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
                new Post()
                {
                    UserId = _userId,
                    Id = model.Id,
                    Title = model.Title,
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.User.UserId == _userId)
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
    }
}