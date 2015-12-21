using ChatRoomWebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoomWebApi.Controllers
{
    public class ValuesController : ApiController
    {
		private ChatRoomEntities db = new ChatRoomEntities();
		// GET api/values
		[HttpGet]
		public IEnumerable<Room> GetRoomList()
        {
		    return db.Rooms.Where(r=>r.RoomName !=null).ToList();
        }

        
    }
}
