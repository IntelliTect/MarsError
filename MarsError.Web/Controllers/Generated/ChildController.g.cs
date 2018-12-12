using IntelliTect.Coalesce.Knockout.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace MarsError.Web.Controllers
{
    [Authorize]
    public partial class ChildController : BaseViewController<MarsError.Data.Models.Child>
    {
        [Authorize]
        public ActionResult Cards()
        {
            return IndexImplementation(false, @"~/Views/Generated/Child/Cards.cshtml");
        }

        [Authorize]
        public ActionResult Table()
        {
            return IndexImplementation(false, @"~/Views/Generated/Child/Table.cshtml");
        }


        [Authorize]
        public ActionResult TableEdit()
        {
            return IndexImplementation(true, @"~/Views/Generated/Child/Table.cshtml");
        }

        [Authorize]
        public ActionResult CreateEdit()
        {
            return CreateEditImplementation(@"~/Views/Generated/Child/CreateEdit.cshtml");
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
