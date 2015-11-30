using System.ComponentModel;

namespace ClubArcada.BarCalendar.BusinessObjects
{
    public enum eBusinessUnit
    {
        NotSet = 0,

        [Description("1E5CCBD5-4C41-4915-B634-F748BABFEAEB")]
        Arcada = 1,

        [Description("1E5CCBD5-4C41-4915-B634-F748BAB56987")]
        Synot = 2
    }

    public enum eShiftType
    {
        NotSet = 0,
        Day = 1,
        Night = 2,
        Help = 3
    }
}