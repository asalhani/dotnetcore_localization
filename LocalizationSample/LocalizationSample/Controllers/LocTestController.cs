using System;
using System.Collections.Generic;
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
        private readonly IStringLocalizer<LocTestController> _localizer;

        public LocTestController(IStringLocalizer<LocTestController> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public string Get()
        {
            return _localizer["MyString01Res"];
        }

    }
}