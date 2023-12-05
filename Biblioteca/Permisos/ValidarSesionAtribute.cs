using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Permisos
{
    public class ValidarSesionAtribute : ActionFilterAttribute
    {
        [ValidarSesionAtribute]
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {

                filterContext.Result = new RedirectResult("~/Acesso/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}


