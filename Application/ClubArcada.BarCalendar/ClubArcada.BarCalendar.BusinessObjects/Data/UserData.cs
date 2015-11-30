using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;

namespace ClubArcada.BarCalendar.BusinessObjects.Data
{
    public class UserData
    {
        public static User Create(User user)
        {
            user.DateCreated = DateTime.Now;
            user.UserId = Guid.NewGuid();
            user.Password = "0000";

            using (var appDC = BARDBDataContext.Ready())
            {
                appDC.Users.InsertOnSubmit(user);
                appDC.SubmitChanges();
            }

            return user;
        }

        public static User GetById(Guid id)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                return appDC.Users.SingleOrDefault(u => u.UserId == id);
            }
        }

        public static List<User> GetList()
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                return appDC.Users.OrderBy(u => u.FirstName).ToList();
            }
        }

        public static void Update(User user)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                var toUpdate = appDC.Users.SingleOrDefault(u => u.UserId == user.UserId);

                toUpdate.LastName = user.LastName;
                toUpdate.FirstName = user.FirstName;
                toUpdate.ColorHex = user.ColorHex;

                if (user.AvatarData != null)
                {
                    toUpdate.AvatarData = user.AvatarData;
                }

                appDC.SubmitChanges();
            }
        }
    }
}