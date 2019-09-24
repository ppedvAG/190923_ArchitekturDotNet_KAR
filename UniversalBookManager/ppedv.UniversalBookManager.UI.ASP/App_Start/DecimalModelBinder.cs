using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.UniversalBookManager.UI.ASP.App_Start
{
    // https://stackoverflow.com/questions/14400643/accept-comma-and-dot-as-decimal-separator


    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            return valueProviderResult == null ? base.BindModel(controllerContext, bindingContext) : Convert.ToDecimal(valueProviderResult.AttemptedValue);
            // of course replace with your custom conversion logic
        }
    }
}