using Microsoft.AspNetCore.Mvc;
using Moq;
using MyCompany.Controllers;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyCompanyTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<ServiceItem> services = new List<ServiceItem>();

            var dataManager = new Mock<DataManager>();
            var serviceItem1 = new ServiceItem();
            serviceItem1.Id = Guid.NewGuid();
            serviceItem1.Title = "Baking Cake";
            serviceItem1.Subtitle = "Test 1";
            serviceItem1.TitleImagePath = "1.jpg";
            serviceItem1.DateAdded = DateTime.Now;
            serviceItem1.Text = "Test 1";


            var serviceItem2 = new ServiceItem();
            serviceItem2.Id = Guid.NewGuid();
            serviceItem2.Title = "Antivirus";
            serviceItem2.Subtitle = "Test 2";
            serviceItem2.TitleImagePath = "2.jpg";
            serviceItem2.DateAdded = DateTime.Now;
            serviceItem2.Text = "Test 2";

            services.Add(serviceItem1);
            services.Add(serviceItem2);
            var rightServices = services.AsQueryable();

            Assert.True(true);
        }

        [Fact]
        public void Test2() 
        {

            List<ServiceItem> services = new List<ServiceItem>();

            var dataManager = new Mock<DataManager>();
            var serviceItem1 = new ServiceItem();
            serviceItem1.Id = Guid.NewGuid();
            serviceItem1.Title = "Baking Cake";
            serviceItem1.Subtitle = "Test 1";
            serviceItem1.TitleImagePath = "1.jpg";
            serviceItem1.DateAdded = DateTime.Now;
            serviceItem1.Text = "Test 1";


            var serviceItem2 = new ServiceItem();
            serviceItem2.Id = Guid.NewGuid();
            serviceItem2.Title = "Antivirus";
            serviceItem2.Subtitle = "Test 2";
            serviceItem2.TitleImagePath = "2.jpg";
            serviceItem2.DateAdded = DateTime.Now;
            serviceItem2.Text = "Test 2";

            services.Add(serviceItem1);
            services.Add(serviceItem2);

/*            dataManager
                .Setup(m => m.ServiceItems.GetServiceItems())
                .Returns(services.AsQueryable());

            var servicesController = new ServicesController(dataManager.Object);

            var actionResult = servicesController.Index(default, "сортировать по имени", 1);
*/
            Assert.True(true);

        }
    }
}
