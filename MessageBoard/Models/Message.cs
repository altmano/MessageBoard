using Microsoft.AspNetCore.Identity;

namespace MessageBoard.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string AuthorName { get; set; }
        public string AuthorId { get; set; }

        public int TopicId { get; set; }

        public System.DateTime TimePublished { get; set; }

    } 
}
