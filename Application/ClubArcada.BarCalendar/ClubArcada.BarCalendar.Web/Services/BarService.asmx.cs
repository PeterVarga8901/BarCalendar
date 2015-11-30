using System;
using System.Collections.Generic;
using System.Web.Services;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;

namespace ClubArcada.BarCalendar.Web.Services
{
    /// <summary>
    /// Summary description for BarService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class BarService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<usp_get_shiftsResult> GetShifts(int year, int month, int day)
        {
            var validDateTime = new DateTime(year, month, day);
            return BusinessObjects.Data.ShiftData.GetList(validDateTime);
        }

        [WebMethod]
        public List<usp_get_shiftsResult> Create(string userid, int type, int hours, int year, int month, int day)
        {
            var validDateTime = new DateTime(year, month, day);

            var shift = new Shift()
            {
                BusinessUnitId = Guid.NewGuid(),
                CreatedByUserId = Guid.NewGuid(),
                Date = validDateTime,
                Duration = hours,
                ShiftType = type,
                WorkerId = new Guid(userid)
            };

            BusinessObjects.Data.ShiftData.Create(shift);

            return BusinessObjects.Data.ShiftData.GetList(validDateTime);
        }

        [WebMethod]
        public void DeleteShift(string shiftId)
        {
            var id = new Guid(shiftId);

            BusinessObjects.Data.ShiftData.Delete(id);
        }
    }
}