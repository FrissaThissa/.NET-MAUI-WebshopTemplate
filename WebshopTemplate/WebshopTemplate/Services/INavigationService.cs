using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface INavigationService
    {
        public Task NavigateToProductIndex(Category category);
    }
}
