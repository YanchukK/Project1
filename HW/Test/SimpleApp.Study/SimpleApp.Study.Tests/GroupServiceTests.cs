using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleApp.Study.Tests
{
    [TestClass]
    public class GroupServiceTests
    {
        private IGroupService groupService;

        [TestInitialize]
        public void SetUp()
        {
            this.groupService = new GroupService();
        }


        [TestMethod]
        public void IsValid_ValidGroup_ReturnsTrue()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            //bool expected = true;

            // Act
            bool actual = this.groupService.IsValid(group);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsValid_GroupOfChildren_ReturnsFalse()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 4, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            // Act
            bool actual = this.groupService.IsValid(group);

            // Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_GroupWithNotValidAge_ReturnsFalse()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = -5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            // Act
            bool actual = this.groupService.IsValid(group);

            // Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsValid_Null_ReturnsFalse()
        {
            // Act
            bool actual = this.groupService.IsValid(null);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
