using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleApp.Study.IntegrationTests
{
    [TestClass]
    public class GroupServiceIntegrationTests
    {
        private IBookingService bookingService;
        //private IGroupService groupService;


        // идеальный сценарий
        [TestMethod]
        public void GetSuitableHotelNamesBook_ValidGroup_ReturnsHotelsRooms()
        {
            // Arrange

            // Создаем группу с ребенком и без животных

            // Создаем два отеля: подходящие по комнатам, комнаты не забронированы,
            // один с животными, другой без

            var group = new Group()
            {
                Guests = new List<Guest>()
                {
                    new Guest(){ Age = 21, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 20, FirstName = "FirstName", LastName = "LastName"},
                    new Guest(){ Age = 5, FirstName = "FirstName", LastName = "FirstName"}
                },
                HasPets = false
            };

            var hotelWithPets = new Hotel()
            {
                Name = "HotelWithPets",
                Rooms = new List<Room>()
                    {
                        new Room(){ BookedBy = null, Capacity = 2 },
                    },
                AllowPets = true
            };

            var hotelWithoutPets = new Hotel()
            {
                Name = "HotelWithoutPets",
                Rooms = new List<Room>()
                    {
                        new Room() {BookedBy = null, Capacity = 6},
                        new Room(){ BookedBy = null, Capacity = 2 }
                    },
                AllowPets = false
            };

            List<Hotel> hotels = new List<Hotel>();
            hotels.Add(hotelWithPets);
            hotels.Add(hotelWithoutPets);

            this.bookingService = new BookingService(hotels);

            // Act

            var hotelsNames = bookingService.GetSuitableHotelNames(group);
            var actualHotelsNames = new List<string>()
            { hotelWithPets.Name, hotelWithoutPets.Name };

            // если вернулся один отель, то его и передаем в бук,
            // если несколько - первый

            // список доступных комнат
            var roomList = bookingService.Book(hotelsNames[0], group);
            var actualRoomList = new List<Room>()
            { new Room(){ BookedBy = null, Capacity = 2 } };

            // Assert

            // Проверяем, что список отелей не пустой и равен тому,
            //чему должен быть равен
            CollectionAssert.AreEqual(hotelsNames, actualHotelsNames);

            // Проверяем список комнат
            CollectionAssert.Equals(roomList, actualRoomList);
        }



        // не идеальный сценарий
        [TestMethod]
        public void GetSuitableHotelNames_ValidGroup_ReturnsHotels()
        {

        }
    }
}
