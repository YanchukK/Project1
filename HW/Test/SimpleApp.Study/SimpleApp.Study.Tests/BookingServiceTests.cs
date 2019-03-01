using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SimpleApp.Study.Tests
{
    [TestClass()]
    public class BookingServiceTests
    {
        private IBookingService bookingService;

        [TestInitialize]
        public void SetUp()
        {
            Group testgroup = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 21, FirstName = "FirstName", LastName = "LastName"}
                },
                HasPets = false
            };


            List<Hotel> hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Name = "HotelWithPets",
                    Rooms = new List<Room>()
                    {
                        new Room(){ BookedBy = null, Capacity = 2 },
                        new Room(){ BookedBy = testgroup, Capacity = 1}
                    },
                    AllowPets = true
                },
                new Hotel()
                {
                    Name = "HotelWithPets2",
                    Rooms = new List<Room>()
                    {
                        new Room(){ BookedBy = null, Capacity = 6 }
                    },
                    AllowPets = true
                },
                new Hotel ()
                {
                    Name = "HotelWithoutPets",
                    Rooms = new List<Room>()
                    {
                        new Room(){ BookedBy = null, Capacity = 3 }
                    },
                    AllowPets = false
                }
            };

            this.bookingService = new BookingService(hotels);
        }


        [TestMethod]
        public void GetSuitableHotelNames_ValidGroup_ReturnsHotels()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 21, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            var resultHotels = new List<string>() { "HotelWithPets" };

            // Act
            var actual = this.bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(actual, resultHotels);
        }

        [TestMethod]
        public void GetSuitableHotelNames_GroupOf8_ReturnsHotels()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 1, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 2, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 3, FirstName = "FirstName", LastName = "FirstName"},
                    new Guest(){ Age = 4, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 50, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 60, FirstName = "FirstName", LastName = "FirstName"},
                    new Guest(){ Age = 70, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 80, FirstName = "FirstName", LastName = "LastName"},
                },
                HasPets = true
            };

            var resultHotels = new List<string>() { "HotelWithPets2" };

            // Act
            var actual = this.bookingService.GetSuitableHotelNames(group);

            // Assert
            CollectionAssert.AreEqual(actual, resultHotels);
        }


        [ExpectedException(typeof(Exception), "No suitable hotel found")]
        [TestMethod]
        public void GetSuitableHotelNames_GroupHasntSuitableHotel_ReturnsException()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 21, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            // Act
            var actual = this.bookingService.GetSuitableHotelNames(group);
        }

        [ExpectedException(typeof(Exception), "Group is not valid")]
        [TestMethod]
        public void GetSuitableHotelNames_NotValidGroup_ReturnsException()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = -1, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            // Act
            var actual = this.bookingService.GetSuitableHotelNames(group);
        }

        [ExpectedException(typeof(Exception), "Group is not valid")]
        [TestMethod]
        public void GetSuitableHotelNames_GroupOfChildren_ReturnsException()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 4, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 2, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = true
            };

            // Act
            var actual = this.bookingService.GetSuitableHotelNames(group);
        }

        [ExpectedException(typeof(Exception), "Group is not valid")]
        [TestMethod]
        public void GetSuitableHotelNames_Null_ReturnsException()
        {
            // Act
            var actual = this.bookingService.GetSuitableHotelNames(null);
        }

        [ExpectedException(typeof(Exception), "Group or hotel name is not valid")]
        [TestMethod]
        public void Book_GroupAndHotelNull_ReturnsException()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 10, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 30, FirstName = "FirstName", LastName = "FirstName"},
                },
                HasPets = true
            };


            // Act
            var actual = this.bookingService.Book(null, group);
        }



        [ExpectedException(typeof(Exception), "No suitable rooms found")]
        [TestMethod]
        public void Book_GroupWithPetsAndHotelWithout_ReturnsException()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 1, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 2, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 3, FirstName = "FirstName", LastName = "FirstName"},
                },
                HasPets = true
            };

            // Act
            var actual = this.bookingService.Book("HotelWithoutPets", group);
        }


        [TestMethod]
        public void Book_GroupAndHotel_ReturnsRooms()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 10, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 30, FirstName = "FirstName", LastName = "FirstName"},
                },
                HasPets = false
            };

            var rooms = new List<Room>() { new Room(){ BookedBy = null, Capacity = 3 } };

            // Act
            var actual = this.bookingService.Book("HotelWithoutPets", group);

            // Assert
            Assert.ReferenceEquals(actual, rooms);
        }


        [ExpectedException(typeof(Exception), "Group already have booking")]
        [TestMethod]
        public void Book_GroupAlreadyHaveBooking_ReturnsException()
        {
            // Arrange
            Group group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 21, FirstName = "FirstName", LastName = "LastName"}
                },
                HasPets = false
            };

            // Act
            var actual = this.bookingService.Book("HotelWithoutPets", group);
        }
    }
}
