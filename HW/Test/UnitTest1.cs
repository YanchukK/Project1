using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleApp.Study;

namespace UnitTestProject1
{
    [TestClass]
    public class BookingService
    {
        private IGroupService groupService;

        //[TestInitialize]
        //public void SetUp()
        //{
        //    this.groupService = new RealGroupService;
        //}



        public void SetUp()
        {
            groupService = new GroupService();
        }

        [TestMethod]
        public void IsValid_ValidGroup_Returns_True()
        {
            // заполнить группу
            // Arrange
            var group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };
            

            // Act
            var result = this.groupService.IsValid(group);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
