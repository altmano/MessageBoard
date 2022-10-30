using MessageBoard.Models;
using System.Collections.Generic;

namespace MessageBoard.ViewModels
{
    public class MessageViewModel
    {
        public Topic topic { get; set; }
        public Message Message { get; set; }    
        public IEnumerable<Message> ListOfMessages { get; set; }


    

    }
}
