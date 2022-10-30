using MessageBoard.Models;
using System.Collections.Generic;

namespace MessageBoard.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
