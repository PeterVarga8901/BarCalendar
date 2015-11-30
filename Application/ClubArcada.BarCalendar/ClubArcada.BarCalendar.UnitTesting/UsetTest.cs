using System;
using System.Collections.Generic;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClubArcada.BarCalendar.UnitTesting
{
    [TestClass]
    public class UsetTest
    {
        [TestMethod]
        public void GenerateData()
        {
            var userList = GenerateUsers();
            GenerateShifts(userList);
        }

        private List<User> GenerateUsers()
        {
            var list = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                var user = new User() { FirstName = NameGenerator.GenRandomFirstName(), LastName = NameGenerator.GenRandomLastName(), Password = "" };
                user = BusinessObjects.Data.UserData.Create(user);
                list.Add(user);
            }

            return list;
        }

        private void GenerateShifts(List<User> users)
        {
            var startDay = DateTime.Now.AddDays(-(DateTime.Now.Day + 7));

            var x = 0;

            for (int i = 0; i < 50; i++)
            {
                if(i % 2  == 0)
                {
                    x++;
                }

                var user = new Shift() 
                { 
                    BusinessUnitId = Guid.NewGuid(), 
                    CreatedByUserId = Guid.NewGuid(), 
                    Date = DateTime.Now.AddDays(x), 
                    ShiftTypeEnum = BusinessObjects.eShiftType.Day, 
                    WorkerId = users[new Random().Next(0, users.Count)].UserId
                };
                user = BusinessObjects.Data.ShiftData.Create(user);
            }
        }
    }
}