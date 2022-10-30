
using System.Collections.Generic;

namespace MessageBoard.Models
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetByTopicId(int topicId);
        IEnumerable<Message> GetMessages();
        public Message GetById(int id); 

        public void Add(Message message);
        public bool Delete(int id);
        public bool Update();

        public void Edit(Message message);

    
     }
}
