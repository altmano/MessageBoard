using System.Collections.Generic;

namespace MessageBoard.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public List<Message> messages { get; set; }

        public string topicDescription { get; set; }
        public string topicName { get; set; }

    }
}
