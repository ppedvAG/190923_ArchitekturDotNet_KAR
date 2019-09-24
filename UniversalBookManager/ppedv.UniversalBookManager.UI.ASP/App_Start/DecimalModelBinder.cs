using System;
using System.Collections.Generic;
using System.Globalization;
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

            // Version 2: Komma UND Punkt
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            // Wert als String holen und Convert.ToDecmial bzw Decimal.Parse mit CultureInvariant aufrufen

            if (valueProviderResult != null)
            {
                // Hack
                // var attemptedValue = result.AttemptedValue.Replace(',', '.');

                var parsedNumber = decimal.Parse(result.AttemptedValue, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
                return parsedNumber;
            }
            else
                return null; 
        }
    }
}