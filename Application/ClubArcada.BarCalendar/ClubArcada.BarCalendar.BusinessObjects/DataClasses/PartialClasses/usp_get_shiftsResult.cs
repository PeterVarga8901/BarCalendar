using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.BarCalendar.BusinessObjects.DataClasses
{
    [Serializable]
    public partial class usp_get_shiftsResult
    {
        public string ImageData
        {
            get
            {
                if (this.AvatarData != null)
                    return Convert.ToBase64String(this.AvatarData.ToArray());
                else
                    return string.Empty;
            }
            private set { }
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
