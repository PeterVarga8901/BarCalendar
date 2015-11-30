using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubArcada.BarCalendar.BusinessObjects.DataClasses
{
    [Serializable]
    public partial class BARDBDataContext
    {
        public static BARDBDataContext Ready()
        {
            var val = new BARDBDataContext(Settings.ConnectionString);
            return val;
        }
    }
}
