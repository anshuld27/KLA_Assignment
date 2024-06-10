using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Text.RegularExpressions;

namespace currency_speller_api.Filters
{
    /// <summary>
    /// The CurrencyValidationFilter class validates that a string parameter can be converted to a decimal 
    /// and ensures it is less than or equal to 999 999 999,99 with the format "dollars,cents".
    /// </summary>
    public class CurrencyValidationFilter : ActionFilterAttribute
    {
        private readonly string _parameterName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValidationFilter"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to validate.</param>
        public CurrencyValidationFilter(string parameterName)
        {
            _parameterName = parameterName;
        }

        /// <summary>
        /// Called before the action method is executed to validate the parameter.
        /// </summary>
        /// <param name="context">The context of the action executing.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey(_parameterName) &&
                context.ActionArguments[_parameterName] is string stringValue)
            {
                //Remove white spces from parameter.
                stringValue = Regex.Replace(stringValue, @"\s+", "");

                //Replace ,(comma) with .(decimal)
                stringValue = Regex.Replace(stringValue, @",", ".");

                double amount;
                if (!double.TryParse(stringValue, out amount))
                {
                    context.Result = new BadRequestObjectResult($"{_parameterName} is not a valid input.");
                    return;
                }

                //check if value after decimal is upto 2 places.
                string[] centPart = stringValue.Split('.');
                if (centPart.Length > 1 && centPart[1].Length > 2)
                {
                    context.Result = new BadRequestObjectResult($"{_parameterName} is not a valid input.");
                    return;
                }

                // Check if the value is within the allowed range
                const double maxValue = 999999999.99;

                if (amount > maxValue)
                {
                    context.Result = new BadRequestObjectResult($"{_parameterName} must be less than or equal to 999 999 999,99.");
                    return;
                }

                // Optionally, replace the string value with the decimal value in the action arguments
                context.ActionArguments[_parameterName] = amount.ToString();
            }
            else
            {
                context.Result = new BadRequestObjectResult($"Parameter {_parameterName} is missing or invalid.");
            }

            base.OnActionExecuting(context);
        }
    }
}
