using SportsStore.Domain.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public PartialViewResult Menu(string category = null)
        {
            IEnumerable<string> categories = repository.Products
                                                       .Select(c => c.Category)
                                                       .Distinct()
                                                       .OrderBy(x => x);
            ViewBag.SelectedCategory = category;
            return PartialView(categories);
        }
    }
}