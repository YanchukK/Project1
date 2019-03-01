using System.Linq;

namespace SimpleApp.Study
{
    public class GroupService : IGroupService
    {
        // пустые значения
        // что еще?

        public bool IsValid(Group group)
        {
            if (group != null)
            {
                var guests = group.Guests;
                var countOfAdults = (from guest in guests
                                     where guest.Age > 6
                                     select guest).Count();

                var ageLessThanZero = (from guest in guests
                                       where guest.Age < 0
                                       select guest).Count();

                if (countOfAdults > 0 && ageLessThanZero == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
