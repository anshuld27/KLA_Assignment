using currency_speller_api.Filters;
using currency_speller_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace currency_speller_api.Controllers
{
    /// <summary>
    /// The ConvertCurrencyController class handles HTTP requests for converting currency amounts to its word representation.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertCurrencyController : ControllerBase
    {
        private readonly IConvertCurrency _convertCurrency;

        /// <summary>
        /// Initializes a new instance of the ConvertCurrencyController class.
        /// </summary>
        public ConvertCurrencyController(IConvertCurrency convertCurrency) =>
            _convertCurrency = convertCurrency;

        /// <summary>
        /// Handles GET requests to convert a currency amount to its word representation.
        /// </summary>
        /// <param name="amount">The currency amount to convert, as a string.</param>
        /// <returns>An IActionResult containing the word representation of the currency amount or an error message if invalid.</returns>
        [HttpGet("{amount}")]
        [CurrencyValidationFilter("amount")]
        public IActionResult Get(string amount)
        {
            string result = _convertCurrency.Convert(double.Parse(amount));
            return Ok(result);
        }
    }
}
