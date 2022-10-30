using MessageBoard.Models;
using System.Collections.Generic;

namespace MessageBoard.ViewModels
{
    public class TopicViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }
        public Category currentCategory { get; set; }

    }
}
