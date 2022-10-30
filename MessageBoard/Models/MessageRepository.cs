using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Models
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public MessageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Message message)
        {
            _appDbContext.Messages.Add(message); 
        }

        public bool Delete(int id)
        {
            Message message = _appDbContext.Messages.Find(id);
            if(message != null)
            {
                _appDbContext.Messages.Remove(message);
                Update();
                return true;
            }
            else
            {
                return false;
            }
         
        }

        public void Edit(Message message)
        {
            _appDbContext.Messages.Update(message);
            Update();

        }

        public Message GetById(int id)
        {
            return _appDbContext.Messages.Find(id); 
        }

        public IEnumerable<Message> GetByTopicId(int topicId)
        {
           
            var messages = _appDbContext.Messages.Where(m => m.TopicId == topicId);
            return messages;
        }

        public IEnumerable<Message> GetMessages()
        {
            return _appDbContext.Messages;
        }

        public bool Update()
        {
            int changed = _appDbContext.SaveChanges();
            if(changed > 0)
            {
                return true;
            }else
            {
                return false;
            }


        }
    }
}
