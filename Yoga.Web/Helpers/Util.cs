using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yoga.Web.Helpers
{
    public class Util
    {
        public static string GetModelStateErrors(ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values
                                         .SelectMany(x => x.Errors)
                                         .Select(x => x.ErrorMessage));
        }
    }
}