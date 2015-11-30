using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClubArcada.BarCalendar.BusinessObjects.DataClasses;

namespace ClubArcada.BarCalendar.Web.Pages
{
    public partial class UserEdit : System.Web.UI.Page
    {
        private Guid SelectedUserId
        {
            get
            {
                if (ViewState["UserId"] != null)
                {
                    return new Guid(ViewState["UserId"].ToString());
                }
                else
                {
                    return Guid.Empty;
                }
            }
            set
            {
                ViewState["UserId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    SelectedUserId = new Guid(Request.QueryString["uid"].ToString());
                }

                BindData();
            }
        }

        private void BindUsers()
        {
            rptUsers.DataSource = MySession.Current.UserList;
            rptUsers.ItemDataBound += rptUsers_ItemDataBound;
            rptUsers.DataBind();
        }

        private void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            var user = e.Item.DataItem as User;

            var hlUser = ((HyperLink)(e.Item.FindControl("hlUser")));

            hlUser.NavigateUrl = string.Format("~/Pages/UserEdit.aspx?uid={0}", user.UserId);
            hlUser.Text = user.DisplayName;

            var container = (HtmlGenericControl)e.Item.FindControl("divUserContainer");
            container.Style.Add("background-color", "#" + user.ColorHex);
        }

        private void BindData()
        {
            BindUsers();

            if (SelectedUserId != Guid.Empty)
            {
                var user = Web.MySession.Current.UserList.SingleOrDefault(u => u.UserId == SelectedUserId);
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtColor.Text = user.ColorHex;

                txtColor.Style.Add("background-color","#" + user.ColorHex);
                txtColor.Style.Add("color", "#FFFFFF");

                txtFullname.Text = user.FirstName + " " + user.LastName;

                

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedUserId == Guid.Empty)
            {
                var newUser = new User();

                if (fuAvatar.HasFile)
                {
                    var image = Functions.ByteArrayToImagebyMemoryStream(fuAvatar.FileBytes);
                    var x = Functions.FixedSize(image, 28, 28);
                    newUser.AvatarData = new System.Data.Linq.Binary(Functions.ImageToByteArraybyMemoryStream(x));
                }

                newUser.FirstName = txtFirstName.Text.Trim();
                newUser.LastName = txtLastName.Text.Trim();
                newUser.ColorHex = txtColor.Text.Trim();

                var savedUser = BusinessObjects.Data.UserData.Create(newUser);

                MySession.Current.UserList.Add(savedUser);
            }
            else
            {
                var user = new User();

                if (fuAvatar.HasFile)
                {
                    var image = Functions.ByteArrayToImagebyMemoryStream(fuAvatar.FileBytes);
                    var x = Functions.FixedSize(image, 28, 28);
                    user.AvatarData = new System.Data.Linq.Binary(Functions.ImageToByteArraybyMemoryStream(x));
                }

                user.UserId = SelectedUserId;
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.ColorHex = txtColor.Text;

                BusinessObjects.Data.UserData.Update(user);

                MySession.Current.UserList.SingleOrDefault(u => u.UserId == user.UserId).Update(user);
            }

            BindUsers();
        }
    }
}