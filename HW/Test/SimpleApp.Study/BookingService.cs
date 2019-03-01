using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.Study
{
    public class BookingService : IBookingService
    {
        GroupService groupService = new GroupService();

        List<Hotel> hotels = new List<Hotel>();

        public BookingService(List<Hotel> hotels)
        {
            this.hotels = hotels;
        }

        private bool IsRoomAvailable (List<Room> rooms, Group group)
        {
            double count = 0;
            foreach (var g in group.Guests)
            {
                if (g.Age > 6)
                {
                    count += 1;
                }
                else
                {
                    count += 0.5;
                }
            }

            int countOfGuest = Convert.ToInt32(Math.Floor(count));

            var resultList = (from room in rooms
                              where room.BookedBy == null
                              && room.Capacity == countOfGuest
                              select room).ToList();

            if(resultList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsAllowPets(Hotel hotel, Group group)
        {
            if(!group.HasPets) // если нету питомцев
            {
                return true;   // может селиться где хочет
            }
            else               // если есть
            {
                if(hotel.AllowPets) // отель позволяет
                {
                    return true;    // может
                }
                else
                {
                    return false;   // нет
                }
            }
        }

        // одна группа = одна бронь
        private bool IsGroupAlreadyHaveBooking(Group group)
        {
            var allRooms = from hotel in hotels
                           select hotel.Rooms;

            foreach (var v in allRooms)
            {
                foreach (var room in v)
                {
                    if (room.BookedBy == group)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public List<string> GetSuitableHotelNames(Group group)
        {
            // проверяем валидная ли группа
            if (!groupService.IsValid(group) || group == null)
            {
                throw new Exception("Group is not valid");
            }
            else
            {
                List<string> namesSuitableHotel = new List<string>();

                foreach (var hotel in hotels)
                {
                    if (IsRoomAvailable(hotel.Rooms, group)
                        && IsAllowPets(hotel, group))
                    {
                        namesSuitableHotel.Add(hotel.Name);
                    }
                }

                if (namesSuitableHotel.Count == 0)
                {
                    // выброшено исключение
                    throw new Exception("No suitable hotel found");
                }
                else
                {
                    return namesSuitableHotel;
                }
            }

        }

        
        public List<Room> Book(string hotelName, Group group)
        {
            if (!(groupService.IsValid(group)) || (group == null) || (hotelName == null))
            {
                throw new Exception("Group or hotel name is not valid");
            }
            else if(IsGroupAlreadyHaveBooking(group))
            {
                throw new Exception("Group already have booking");
            }
            else
            {
                Hotel hotel = (from h in hotels
                               where h.Name == hotelName
                               select h).Single();

                // животные + комнаты с таким capacity
                if (!(IsAllowPets(hotel, group)
                    && IsRoomAvailable(hotel.Rooms, group)))
                {
                    throw new Exception("No suitable rooms found");
                }
                else
                {
                    return hotel.Rooms;
                }
            }
        }
    }
}
