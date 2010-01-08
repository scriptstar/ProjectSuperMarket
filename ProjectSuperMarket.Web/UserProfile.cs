using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Profile;

namespace ProjectSuperMarket.Web
{
    public class UserProfile : ProfileBase
    {
        public static UserProfile GetUserProfile(string username)
        {
            return Create(username) as UserProfile;
        }

        public static UserProfile GetUserProfile()
        {
            return Create(Membership.GetUser().UserName) as UserProfile;
        }


        [SettingsAllowAnonymous(false)]
        public string Country
        {
            get { return base["Country"] as string; }
            set { base["Country"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string Gender
        {
            get { return base["Gender"] as string; }
            set { base["Gender"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public int Age
        {
            get { return (int)(base["Age"]); }
            set { base["Age"] = value; }
        }
    }
}