using IntelliTect.Coalesce.Knockout.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace MarsError.Web.Controllers
{
    [Authorize]
    public partial class ThingController : BaseViewController<MarsError.Data.Models.Thing>
    {
        [Authorize]
        public ActionResult Cards()
        {
            return IndexImplementation(false, @"~/Views/Generated/Thing/Cards.cshtml");
        }

        [Authorize]
        public ActionResult Table()
        {
            return IndexImplementation(false, @"~/Views/Generated/Thing/Table.cshtml");
        }


        [Authorize]
        public ActionResult TableEdit()
        {
            return IndexImplementation(true, @"~/Views/Generated/Thing/Table.cshtml");
        }

        [Authorize]
        public ActionResult CreateEdit()
        {
            return CreateEditImplementation(@"~/Views/Generated/Thing/CreateEdit.cshtml");
        }

        [Authorize]
        public ActionResult EditorHtml(bool simple = false)
        {
            return EditorHtmlImplementation(simple);
        }

        [Authorize]
        public ActionResult Docs([FromServices] IHostingEnvironment hostingEnvironment)
        {
            return DocsImplementation(hostingEnvironment);
        }
    }
}
