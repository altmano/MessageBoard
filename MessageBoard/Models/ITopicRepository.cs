using System.Collections.Generic;

namespace MessageBoard.Models
{
    public interface ITopicRepository
    {
        IEnumerable<Topic> GetAll();
        IEnumerable<Topic> GetByCategoryId(int categoryId);
        public Topic GetById(int id);
        public void Add(Topic topic);

        public void AddMessage(int topicId, Message message);
    }
}
