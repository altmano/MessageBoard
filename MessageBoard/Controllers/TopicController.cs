using MessageBoard.Models;
using MessageBoard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessageBoard.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;
        private readonly ICategoryRepository _categoryRepository;   

        public TopicController(ITopicRepository topicRepository, ICategoryRepository categoryRepository)
        {
            _topicRepository = topicRepository;
            _categoryRepository = categoryRepository;
        }


        public ViewResult List(int? categoryId)
        {
            IEnumerable<Topic> topicList;
            if(categoryId == null)
            {
                topicList = _topicRepository.GetAll();
                return View(new TopicViewModel
                {
                    Topics = topicList

                });
            }
            else
            {
                
                topicList = _topicRepository.GetByCategoryId((int)categoryId);
                return View(new TopicViewModel
                {
                    Topics = topicList,
                    currentCategory = _categoryRepository.GetCategoryById((int)categoryId)

                });
            }
            
        }
    }
}
