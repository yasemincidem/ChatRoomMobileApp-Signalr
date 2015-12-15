using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ChatRoomWebApi.Models;
using System.Threading.Tasks;

namespace ChatRoomWebApi
{
	public class ChatHub : Hub
	{
		private ChatRoomEntities db = new ChatRoomEntities();

		public async Task TellGroup(string roomName)
		{
			var count = db.Users.Where(r => r.roomName == roomName).Count();
			await Clients.Group(roomName).TellToGroup(count);
		}

		public async Task SendMessage(string roomName, string message)
		{
			var user = db.Users.Where(r => r.roomName == roomName).FirstOrDefault();
			await Clients.OthersInGroup(roomName).SendMessageToGroup(message);
		}

		public override Task OnConnected()
		{
			var user = db.Users.Where(r => r.userName == Context.QueryString["UserName"]).FirstOrDefault();
			if (user == null)
			{
				user = new User()
				{
					userName = Context.User.Identity.Name
				};
				db.Users.Add(user);
				db.SaveChanges();
			}

			else
			{
				foreach (var item in user.Rooms)
				{
					Groups.Add(Context.ConnectionId, item.roomName);
				}
			}
			return base.OnConnected();
		}
		public async Task AddToRoom(string roomName)
		{
			var room = await db.Rooms.FindAsync(roomName);
			if (room != null)
			{
				var user = new User()
				{
					ConnectionId = Context.ConnectionId,
					userName = "yasemin",
					roomName = roomName,
				};
				room.Users.Add(user);
				await db.SaveChangesAsync();
				await Groups.Add(Context.ConnectionId, roomName);
				await this.TellGroup(roomName);
			}
		}
		public async Task RemoveToRoom(string roomName)
		{
			var room = await db.Rooms.FindAsync(roomName);
			if (room != null)
			{
				var user = new User()
				{
					ConnectionId=Context.ConnectionId,
					userName = Context.User.Identity.Name
				};
				room.Users.Remove(user);
				await db.SaveChangesAsync();
				await Groups.Remove(Context.ConnectionId, roomName);
				await this.TellGroup(roomName);
			}
		}
		public override Task OnDisconnected(bool stopCalled)
		{
			var user = db.Users.Where(r => r.userName == Context.User.Identity.Name).FirstOrDefault();
			if (user != null)
			{
				db.Users.Remove(user);
			}
			return base.OnDisconnected(stopCalled);
		}
	

	}
}