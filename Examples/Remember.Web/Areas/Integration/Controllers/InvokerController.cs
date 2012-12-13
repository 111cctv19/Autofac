﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Remember.Web.Areas.Integration.Models;

namespace Remember.Web.Areas.Integration.Controllers
{
    /// <summary>
    /// Simple integration tests for the <see cref="Autofac.Integration.Mvc.ExtensibleActionInvoker"/>
    /// </summary>
    public class InvokerController : Controller
    {
        public ActionResult Index()
        {
            this.ViewData["InjectionEnabled"] = GlobalApplication.IsControllerActionParameterInjectionEnabled() ? "enabled" : "disabled";
            return View();
        }

        public ActionResult ParameterInjection(string value, int id, IInvokerDependency resolved)
        {
            this.ViewData["Value"] = value;
            this.ViewData["Id"] = id;
            if (resolved == null)
            {
                if (GlobalApplication.IsControllerActionParameterInjectionEnabled())
                {
                    this.ViewData["Resolved"] = "was not resolved but should have been";
                }
                else
                {
                    this.ViewData["Resolved"] = "was [correctly] null because parameter injection isn't enabled";
                }
            }
            else
            {
                this.ViewData["Resolved"] = "was resolved by the action invoker";
            }
            return View();
        }
    }
}