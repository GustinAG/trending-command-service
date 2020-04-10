using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Trending.Command.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var assembly = GetType().Assembly;
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            var name = versionInfo.ProductName;
            var version = assembly.GetName().Version.ToString();
            var copyright = versionInfo.LegalCopyright;

            return $"{name} v{version} - {copyright}";
        }
    }
}