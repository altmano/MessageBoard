using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Models
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _appDbContext;

        public TopicRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Topic topic)
        {
            _appDbContext.Topics.Add(topic);    
        }

        public void AddMessage(int topicId, Message message)
        {
           _appDbContext.Topics.FirstOrDefault(t => t.Id == topicId).messages.Add(message);
           _appDbContext.Topics.Update(_appDbContext.Topics.FirstOrDefault(t => t.Id == topicId));
           _appDbContext.SaveChanges();
        }

        public IEnumerable<Topic> GetAll()
        {
            return _appDbContext.Topics;
        }

        public IEnumerable<Topic> GetByCategoryId(int categoryId)
        {
            return _appDbContext.Topics.Where(t => t.CategoryId == categoryId);
        }

        public Topic GetById(int id)
        {
            return _appDbContext.Topics.FirstOrDefault(t => t.Id == id);
        }


    }
}
