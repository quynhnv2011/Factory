using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.DataAccess.Object;
using Core.Web.Libs;
using Core.Web.Utils;
using System;

namespace Core.Web.Controllers
{
    public class AuthenticationController:Controller
    {
        private readonly DataAccess.Object.AccountReponsitory _repsAccount;        

        public AuthenticationController()
        {
            _repsAccount = new AccountReponsitory();            
        }

        [ValidateInput(false)]
        public ActionResult Login(Models.AccountModel m)
        {
            return Redirect(Server.UrlDecode(m.RedirectUrl));
            //if (string.IsNullOrEmpty(m.Email) || string.IsNullOrEmpty(m.Password))
            //{
            //    m.Password = string.Empty;
            //    m.ErrMess = MessageUtils.Err("Bạn chưa nhập đầy đủ tên đăng nhập và mật khẩu");
            //}
            //else
            //{
            //    var acc = new DataAccess.DTO.Account();
            //    var isOk = _repsAccount.Login(m.Email, m.Password, out acc);
            //    if (isOk)
            //    {
            //        var lstMsg = new List<string>();
            //        if (acc.IsLocked)
            //        {
            //            lstMsg.Add("Tài khoản đang bị khóa");
            //        }

            //        if (!acc.IsActivated)
            //        {
            //            lstMsg.Add("Tài khoản chưa kích hoạt");
            //        }

            //        m.ErrMess = MessageUtils.Err(lstMsg.ToList());
            //        m.Password = string.Empty;

            //        if (string.IsNullOrEmpty(m.ErrMess))
            //        {
            //            acc.Password = string.Empty;
            //            acc.LoginAccountId = acc.Id;

            //            var json = Newtonsoft.Json.JsonConvert.SerializeObject(acc);
            //            FormsAuthentication.SetAuthCookie(json, true);                        

            //            if (string.IsNullOrEmpty(m.RedirectUrl))
            //            {                         

            //                    return RedirectToAction("Index", "Home");                     

            //            }
            //            else
            //            {
            //                return Redirect(Server.UrlDecode(m.RedirectUrl));
            //            }
            //        }
            //    }
            //    else
            //    {
            //        m.Password = string.Empty;
            //        m.ErrMess = MessageUtils.Err("Tên đăng nhập hoặc mật khẩu không chính xác");
            //    }
            //}
            //return View("Login", m);
        }

        public ActionResult DoLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }       

        public bool SwitchUser(int switchToUserId)
        {
            var loginUser = Libs.Global.LoginAccount;//acc đăng nhập hệ thống

            FormsAuthentication.SignOut();

            var accountService = new AccountService();
            var isOk = true;
            var allAccCanSwich = accountService.GetAllAccountCanSwitch(loginUser.Id);
            var hasSwichPermission = allAccCanSwich.Any(t => t.Id == switchToUserId);

            var accSwitch = accountService.GetAccountById(switchToUserId);
            if (accSwitch != null && accSwitch.Id > 0 && loginUser.Id > 0
                && !accSwitch.IsLocked //tài khoản chuyển ko bị khóa
                && accSwitch.IsActivated //tài khoản chuyển đã kích hoạt
                && hasSwichPermission //có quyền chuyển sang acc
                )
            {
                //create cookie
                accSwitch.Password = string.Empty;
                accSwitch.LoginAccountId = loginUser.Id;
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(accSwitch);
                FormsAuthentication.SetAuthCookie(json, true);
            }
            else
            {
                isOk = false;
            }

            return isOk;
        }
        
    }
}