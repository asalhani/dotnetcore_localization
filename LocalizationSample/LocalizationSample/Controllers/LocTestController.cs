using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocTestController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public LocTestController(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public string Get()
        {
            return $"Current UI: {CultureInfo.CurrentUICulture}" +
                $", Current Culture: {CultureInfo.CurrentCulture}" +
                $", Loc value: {_localizer["MyString01Res"]}";
        }

    }
}