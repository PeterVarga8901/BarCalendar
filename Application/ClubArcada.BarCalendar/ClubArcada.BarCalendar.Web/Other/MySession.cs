using System;
using System.Collections.Generic;
using System.Web;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;

namespace ClubArcada.BarCalendar.Web
{
    [Serializable]
    public class MySession
    {
        public MySession()
        {
        }

        public static MySession Current
        {
            get
            {
                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];
                if (HttpContext.Current.Session == null || session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        public User User { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                return User != null;
            }
        }

        public List<User> UserList { get; set; }
    }
}