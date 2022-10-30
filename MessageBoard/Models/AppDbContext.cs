using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MessageBoard.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(new Category { Id = 1, Name = "General" });
            builder.Entity<Category>().HasData(new Category { Id = 2, Name = "Politics" });
            builder.Entity<Category>().HasData(new Category { Id = 3, Name = "Animals" });

            builder.Entity<Topic>().HasData(new Topic { Id = 1, CategoryId = 1, topicName = "FAQ", topicDescription = "Frequently asked questions", messages = new List<Message>()});
            builder.Entity<Topic>().HasData(new Topic { Id = 2, CategoryId = 1, topicName = "Rules", topicDescription = "Forum rules", messages = new List<Message>() });
            builder.Entity<Topic>().HasData(new Topic { Id = 3, CategoryId = 2, topicName = "Geopolitcs", topicDescription = "The big picture", messages = new List<Message>() });
            builder.Entity<Topic>().HasData(new Topic { Id = 4, CategoryId = 3, topicName = "Cats", topicDescription = "Discussion about cats", messages = new List<Message>() });
            builder.Entity<Topic>().HasData(new Topic { Id = 5, CategoryId = 3, topicName = "Dogs", topicDescription = "Discussion about dogs", messages = new List<Message>() });
            builder.Entity<Topic>().HasData(new Topic { Id = 6, CategoryId = 3, topicName = "Rats", topicDescription = "Discussion about rats", messages = new List<Message>() });

            builder.Entity<Message>().HasData(new Message { Id = 1, Text = "Message about cats", TopicId = 4 });

        }
    }
}
