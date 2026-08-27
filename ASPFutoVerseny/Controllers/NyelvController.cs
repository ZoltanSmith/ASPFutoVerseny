using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ASPFutoVerseny.Controllers;

public class NyelvController(CultureInfo[] supportedCultures, IStringLocalizer<NyelvController> localizer) : Controller
{
    [HttpPost]
    public IActionResult Valaszt(String valasztottNyelv, String visszaTeres)
    {
        //valasztottNyelv = "ar";
        if (!supportedCultures.Any(c => c.TwoLetterISOLanguageName == valasztottNyelv))
            return BadRequest(localizer["unsupported_lang"].Value); //kell a Value, mert LocalizedString object!
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName, //ezt fogja elvárni!
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(valasztottNyelv)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(10),
                IsEssential = true,
                SameSite = SameSiteMode.Strict
            }
        );
        return LocalRedirect(visszaTeres);
    }
}
