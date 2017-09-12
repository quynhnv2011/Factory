using System;
using System.IO;
using System.Web.Mvc;
using Core.Web.Helper;
using Core.DataAccess.DTO;
using Core.DataAccess.Object;
using System.Linq;
using Common.Utils;

namespace Core.Web.Controllers
{  
    public partial class BaseController : System.Web.Mvc.Controller
    {
        protected string Provider = "ado.net";
        private ActionReponsitory _respAction;
        public BaseController()
        {
            _respAction = new ActionReponsitory();
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //if (!requestContext.HttpContext.Request.IsAuthenticated)
            //{
            //    requestContext.HttpContext.Response.Redirect(GetLoginUrl(requestContext));
            //}
            //var controller = requestContext.RouteData.Values["controller"].ToString().Trim().ToUpper();
            //var action = requestContext.RouteData.Values["action"].ToString().Trim().ToUpper();
            //var currentAcc = Libs.Global.CurrentAccount;
            //if (currentAcc != null)
            //{
            //    //var actionOfCurrentUser = _respAction.GetAllActionOfUser(currentAcc.AccountID);
            //    //var isOk = actionOfCurrentUser.Any(t => t.ActionName.Trim().ToUpper() == action && t.ControllerName.Trim().ToUpper() == controller)
            //    //    || Libs.Config.PublicControllerList.Contains(controller);
            //    var isHasPermision = CheckPermisionController(currentAcc.Id, controller, action);
            //    if (!isHasPermision)
            //    {
            //        requestContext.HttpContext.Response.Clear();
            //        requestContext.HttpContext.Response.Redirect("/AccessDenied/Index");
            //        requestContext.HttpContext.Response.End();
            //    }
            //}
            //else if (controller != "AUTHENTICATION" && action != "LOGIN")
            //{
            //    requestContext.HttpContext.Response.Redirect(GetLoginUrl(requestContext));
            //}
            //base.Initialize(requestContext); 
        }

        private string GetLoginUrl(System.Web.Routing.RequestContext requestContext)
        {
            var redirectUrl = requestContext.HttpContext.Server.UrlEncode(requestContext.HttpContext.Request.Url.PathAndQuery);
            return string.Format("/Authentication/Login?RedirectUrl={0}", redirectUrl);
        }

        protected internal virtual CustomJsonResult CustomJson(object json = null, bool allowGet = true)
        {
            return new CustomJsonResult(json)
            {
                JsonRequestBehavior = allowGet
                    ? JsonRequestBehavior.AllowGet
                    : JsonRequestBehavior.DenyGet
            };
        }

        /// <summary>
        /// Render with signle view
        /// </summary>
        /// <param name="partialViewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected virtual string RenderPartialView(string partialViewName, object model)
        {
            if (ControllerContext == null)
                return string.Empty;

            if (model == null)
                throw new ArgumentNullException("model");

            if (string.IsNullOrEmpty(partialViewName))
                throw new ArgumentNullException("partialViewName");

            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, partialViewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

        public virtual object GetBaseObjectResult(bool isSuccess = true, string msg = "")
        {
            return new
            {
                IsSuccess = isSuccess,
                Message = msg
            };
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            //Log Exception e
            OutputLog.WriteOutputLog(filterContext.Exception);
        }
        private bool CheckPermisionController(int userId,string controllerName,string actionName)
        {
            if (controllerName.ToUpper() == "JAVASCRIPT") return true;
            if (controllerName.ToUpper() == "MENU" && actionName.ToUpper() == "LOADMENU") return true;
            if (controllerName.ToUpper() == "ACTION") return true;
            return _respAction.CheckPermisionAction(userId, controllerName, actionName) || Libs.Config.PublicControllerList.Contains(controllerName.ToUpper());
        }
    }
}
