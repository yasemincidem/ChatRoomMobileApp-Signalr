using ChatRoomApi.Context;
using ChatRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatRoomApi.Controllers
{
    public class HubController : Controller
    {
		private UserContext db = new UserContext();
		User user = new User()
		{
			UserName = "yasemin"
		};

		public ActionResult Index()
		{
			db.Users.Add(user);
			return View(db.Users.ToList());
		}
	}
}