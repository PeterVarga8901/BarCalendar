using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;

namespace ClubArcada.BarCalendar.Web.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        private DateTime SelectedDate
        {
            get
            {
                if (ViewState["SelectedDate"] != null)
                {
                    return DateTime.Parse(ViewState["SelectedDate"].ToString());
                }
                else
                {
                    return DateTime.Today;
                }
            }

            set
            {
                ViewState["SelectedDate"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MySession.Current.UserList = BusinessObjects.Data.UserData.GetList();

                SelectedDate = DateTime.Today;
                lblDate.Text = SelectedDate.ToString("MMMM");
                BindData();
            }
        }

        private void BindData()
        {
            ddlUser.DataSource = MySession.Current.UserList;
            ddlUser.DataValueField = "UserId";
            ddlUser.DataTextField = "DisplayName";
            ddlUser.DataBind();

            var dateFirstDay = SelectedDate.Date.AddDays(-DateTime.Now.Day);

            hfSelectedDate.Value = dateFirstDay.Month.ToString();

            var dayNum = (int)dateFirstDay.DayOfWeek - 1;
            var calendarStartDay = dateFirstDay.AddDays(-dayNum);

            var list = new List<Day>();

            for (int i = 0; i < 42; i++)
            {
                list.Add(new Day() { Date = calendarStartDay.AddDays(i) });
            }

            rptDays.DataSource = list;
            rptDays.ItemDataBound += rptDays_ItemDataBound;
            rptDays.DataBind();
        }

        private void rptDays_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            var item = e.Item.DataItem as Day;

            ((Label)e.Item.FindControl("lblDate")).Text = item.Date.ToString("dd.");
            ((HtmlInputHidden)e.Item.FindControl("hfDate")).Value = item.Date.ToString("dd-MM-yyyy");
            ((HtmlGenericControl)e.Item.FindControl("liContainer")).Attributes.Add("class", "li_"+ item.Date.ToString("dd_MM_yyyy"));
        }

        public class Day
        {
            public DateTime Date { get; set; }

            public string JsDateTime
            {
                get
                {
                    return this.Date.ToString("dd.MM.yyyy");
                }
                private set
                {
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var shift = new Shift();
            shift.ShiftType = int.Parse(ddlType.SelectedValue);
            shift.WorkerId = new Guid(ddlUser.SelectedValue);
            shift.Date = new DateTime(int.Parse(txtDate.Text.Split('.')[2]), int.Parse(txtDate.Text.Split('.')[1]), int.Parse(txtDate.Text.Split('.')[0]),8,8,8);
            shift.Duration = int.Parse(txtWorkTime.Text);
            shift.BusinessUnitId = Guid.NewGuid();
            shift.CreatedByUserId = Guid.NewGuid();
            BusinessObjects.Data.ShiftData.Create(shift);
        }

        protected void ibtnCalendarPrev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SelectedDate = SelectedDate.AddMonths(-1);
            lblDate.Text = SelectedDate.ToString("MMMM");
            BindData();
        }

        protected void ibtnCalendarNext_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SelectedDate = SelectedDate.AddMonths(1);
            lblDate.Text = SelectedDate.ToString("MMMM");
            BindData();
        }
    }
}