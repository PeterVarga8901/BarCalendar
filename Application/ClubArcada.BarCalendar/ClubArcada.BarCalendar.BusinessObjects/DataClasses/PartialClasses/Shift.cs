using System;
namespace ClubArcada.BarCalendar.BusinessObjects.DataClasses
{
    [Serializable]
    public partial class Shift
    {
        public eShiftType ShiftTypeEnum
        {
            get
            {
                return (eShiftType)ShiftType;
            }
            set
            {
                ShiftType = (int)value;
            }
        }

        public string DurationDisplayName
        {
            get
            {
                return string.Format("{0}h", this.Duration);
            }
            set
            {

            }
        }

        
    }
}