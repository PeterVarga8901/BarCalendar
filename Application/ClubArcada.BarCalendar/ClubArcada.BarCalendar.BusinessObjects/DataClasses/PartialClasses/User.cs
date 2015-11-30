using System;

namespace ClubArcada.BarCalendar.BusinessObjects.DataClasses
{
    [Serializable]
    public partial class User
    {
        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
            private set
            {
            }
        }

        public void Update(User user)
        {
            this.ColorHex = user.ColorHex;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.AvatarData = user.AvatarData;
        }
    }
}