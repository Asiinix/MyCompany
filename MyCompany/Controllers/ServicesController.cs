using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using ReflectionIT.Mvc.Paging;

namespace MyCompany.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager dataManager;
        private static string SortValue;
        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id, string Sort, int Page = 1)
        {
            if (id != default)
            {
                return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
            }
            if (Sort == "сортировать по имени")
            {
                SortValue = "сортировать по имени";
            }
            if (Sort == "сортировать по дате добавления")
            {
                SortValue = "сортировать по дате добавления";
            }

            if (SortValue == "сортировать по имени")
            {
                var query = dataManager.ServiceItems.GetServiceItems();
                List<Domain.Entities.ServiceItem> services = new List<Domain.Entities.ServiceItem>();
                foreach (Domain.Entities.ServiceItem i in query)
                {
                    services.Add(i);
                }
                var sortedList = services.OrderBy(si => si.Title);
                var model = PagingList.Create(sortedList, 3, Page);
                return View(model);
            }
            if (SortValue == "сортировать по дате добавления")
            {
                var query = dataManager.ServiceItems.GetServiceItems();
                List<Domain.Entities.ServiceItem> services = new List<Domain.Entities.ServiceItem>();
                foreach (Domain.Entities.ServiceItem i in query)
                {
                    services.Add(i);
                }
                var sortedList = services.OrderBy(si => si.DateAdded);
                var model = PagingList.Create(sortedList, 3, Page);
                return View(model);
            }
            else
            {
                var model = PagingList.Create(dataManager.ServiceItems.GetServiceItems(), 3, Page);
                return View(model);
            }

        }

        [HttpPost]
        public IActionResult Index(string Service, int Page = 1, int j = 1)
        {
            if (Service != null)
            {
                var query = dataManager.ServiceItems.GetServiceItems();
                List<Domain.Entities.ServiceItem> foundItems = new List<Domain.Entities.ServiceItem>();
                foreach (Domain.Entities.ServiceItem i in query)
                {
                    if (i.Title == Service)
                    {
                        foundItems.Add(i);
                    }
                }
                var model = PagingList.Create(foundItems, 3, Page);
                return View(model);
            }
            else
            {
                var model = PagingList.Create(dataManager.ServiceItems.GetServiceItems(), 3, Page);
                return View(model);
            }

        }
    }
}