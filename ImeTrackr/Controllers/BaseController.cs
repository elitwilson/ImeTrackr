using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImeTrackr.Controllers
{
    [Authorize(Roles = "Users")]
    public class BaseController : Controller
    {
    }
}
