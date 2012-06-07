using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImeTrackr.Models;

namespace ImeTrackr.Controllers
{
    [BaseAuthorize(Roles = "Users")]
    public class BaseController : Controller
    {
    }
}
