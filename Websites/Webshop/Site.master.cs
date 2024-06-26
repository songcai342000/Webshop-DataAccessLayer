﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // 以下代码可帮助防御 XSRF 攻击
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // 使用 Cookie 中的 Anti-XSRF 令牌
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // 生成新的 Anti-XSRF 令牌并保存到 Cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 设置 Anti-XSRF 令牌
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // 验证 Anti-XSRF 令牌
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Anti-XSRF 令牌验证失败。");
            }
        }
    }
    LinkButton welcomeBtn;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginView lv = (LoginView)FindControl("loginView1");
        // welcomeBtn = (LinkButton)this.FindControl("ctl00$ctl13$accountBtn");
        welcomeBtn = (LinkButton)lv.FindControl("accountBtn");
        if (Session["itemNumber"] != null && Session["itemNumber"].ToString() != "0")
        {
            itemNumber.Text = Session["itemNumber"].ToString();
        }
        if (Request.Cookies["visitor"] != null)
        {
             welcomeBtn.Text = "Welcome, " + Request.Cookies["visitor"].Value;
        }
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }

    protected void accountBtn_Click(object sender, EventArgs e)
    {
        Menu accountMenu = new Menu();
        accountMenu.ForeColor = System.Drawing.Color.White;
        
        MenuItem login = new MenuItem();
        login.NavigateUrl = "/Account/Login.aspx";
        login.Text = "Log In";
        if (welcomeBtn.Text != "Account")
        {
            login.Enabled = false;
        }
        accountMenu.Items.Add(login);
        MenuItem profile = new MenuItem();
        profile.NavigateUrl = "/Registedusers/Myprofile.aspx";
        profile.Text = "Profile";
        accountMenu.Items.Add(profile);
        MenuItem logout = new MenuItem();
        logout.NavigateUrl = "/Registedusers/Logout.aspx";
        logout.Text = "Log Out";
        accountMenu.Items.Add(logout);
        HtmlLink link1 = new HtmlLink();
        LoginView lv = (LoginView)FindControl("loginView1");
        //PlaceHolder accountPH = (PlaceHolder)this.FindControl("ctl00$ctl13$Placeholder1");
        PlaceHolder accountPH = (PlaceHolder)lv.FindControl("Placeholder1");
        accountPH.Controls.Add(accountMenu);
        
    }
}