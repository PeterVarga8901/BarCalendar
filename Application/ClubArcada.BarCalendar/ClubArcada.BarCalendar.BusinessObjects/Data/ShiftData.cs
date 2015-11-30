using System;
using System.Collections.Generic;
using System.Linq;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;

namespace ClubArcada.BarCalendar.BusinessObjects.Data
{
    public class ShiftData
    {
        public static Shift Create(Shift shift)
        {
            if (shift.WorkerId == Guid.Empty)
                throw new NullReferenceException("WorkerId");

            if (shift.ShiftTypeEnum.In(eShiftType.NotSet))
                throw new NullReferenceException("ShiftType");

            if (shift.Date == null)
                throw new NullReferenceException("Date");

            using (var appDC = BARDBDataContext.Ready())
            {
                shift.DateCreated = DateTime.Now;
                shift.ShiftId = Guid.NewGuid();
                shift.ShiftType = (int)shift.ShiftTypeEnum;

                appDC.Shifts.InsertOnSubmit(shift);
                appDC.SubmitChanges();
                return shift;
            }
        }

        public static bool IsExist(DateTime date, eShiftType shiftType, Guid businessUnitId)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                return appDC.Shifts.SingleOrDefault(s => s.Date.Date == date.Date && s.ShiftType == (int)shiftType && s.BusinessUnitId == businessUnitId) != null;
            }
        }

        public static Shift Get(DateTime date, eShiftType shiftType, Guid businessUnitId)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                return appDC.Shifts.FirstOrDefault(s => s.Date.Date == date.Date && s.ShiftType == (int)shiftType && s.BusinessUnitId == businessUnitId);
            }
        }

        public static List<usp_get_shiftsResult> GetList(DateTime dateTime)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                return appDC.usp_get_shifts(dateTime).OrderBy(s => s.ShiftType).ToList();
            }
        }

        public static void Delete(DateTime date, eShiftType shiftType, Guid businessUnitId)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                var toDelete = appDC.Shifts.FirstOrDefault(s => s.Date.Date == date.Date && s.ShiftType == (int)shiftType && s.BusinessUnitId == businessUnitId);

                if (toDelete != null)
                {
                    appDC.Shifts.DeleteOnSubmit(toDelete);
                    appDC.SubmitChanges();
                }
            }
        }

        public static void Delete(Guid id)
        {
            using (var appDC = BARDBDataContext.Ready())
            {
                var toDelete = appDC.Shifts.SingleOrDefault(s => s.ShiftId == id);

                if (toDelete != null)
                {
                    appDC.Shifts.DeleteOnSubmit(toDelete);
                    appDC.SubmitChanges();
                }
            }
        }
    }
}