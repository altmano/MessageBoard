using MessageBoard.Models;
using MessageBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessageBoard.Controllers
{
   


    public class MessageController : Controller
    {
        private readonly ITopicRepository topicRepository;
        private readonly IMessageRepository messageRepository;
        
        private readonly UserManager<IdentityUser> _userManager;

        public MessageController(ITopicRepository topicRepository, UserManager<IdentityUser> userManager, IMessageRepository messageRepository)
        {
            this.topicRepository = topicRepository;
            this._userManager = userManager;
            this.messageRepository = messageRepository;
        }

        public ViewResult List(int topicId)
        {
            Topic topic = topicRepository.GetById(topicId);
            IEnumerable<Message> messages = messageRepository.GetByTopicId(topicId);
            return View(new MessageViewModel
            {
                ListOfMessages = messages,
                topic = topic
            });
        }
        [Authorize][HttpPost]public IActionResult Reply(Message message, int topicId)
        {
            message.AuthorName = _userManager.GetUserName(User);
            message.AuthorId = _userManager.GetUserId(User);
            message.TimePublished = System.DateTime.Now;
            message.TopicId = topicId;

            messageRepository.Add(message);

            messageRepository.Update();


            Topic topic = topicRepository.GetById(topicId);
            IEnumerable<Message> messages = messageRepository.GetByTopicId(topicId);

            return View(new MessageViewModel
            {
                ListOfMessages = messages,
                topic = topic
            });
            
        }

        [Authorize]public IActionResult ConfirmDelete(int messageId)
        {

            Message message = messageRepository.GetById(messageId);
            Topic topic = topicRepository.GetById(message.TopicId); 
            return View(new MessageViewModel
            {
                topic = topic,
                Message = message
            });

        }
        public IActionResult DeleteConfirmed(int messageId)
        {
            Message message = messageRepository.GetById(messageId);
            int topicId = message.TopicId;
            messageRepository.Delete(messageId);
            IEnumerable<Message> messages = messageRepository.GetByTopicId(topicId);
            Topic topic = topicRepository.GetById(topicId);

            return View("List", new MessageViewModel
            {
                ListOfMessages = messages,
                topic = topic
            });
            //return RedirectToAction("Index", "Home" );
        }

        [Authorize]public IActionResult Edit(int messageId)
        {
            Message message = messageRepository.GetById(messageId);

            return View(new MessageViewModel { Message = message});
        }

        public IActionResult ConfirmEdit(Message message, int messageId)
        {
            Message _message  = messageRepository.GetById(messageId);
            _message.Text = message.Text;
            IEnumerable<Message> messages = messageRepository.GetByTopicId(_message.TopicId);
            Topic topic = topicRepository.GetById(_message.TopicId);
            messageRepository.Edit(_message);
            return View("List", new MessageViewModel
            {
                ListOfMessages = messages,
                topic = topic
            });
        }
    }
}
