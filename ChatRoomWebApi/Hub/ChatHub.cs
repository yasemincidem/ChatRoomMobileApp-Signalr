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

		public async Task SendMessage(string username, string message, string groupname)
		{
			await Groups.Add(Context.ConnectionId, groupname);
			Clients.Group(groupname).sendMessage(username, message);
		}
		public async Task UserNotify(string groupname)
		{
			var count = db.Users.Where(r => r.RoomName == groupname).Count();
			await Clients.Group(groupname).userCount(count);
		}
		public async Task Subscribe(string username, string message,string groupname)
		{
			var user = db.Users.Where(r => r.RoomName == groupname && r.UserName==Context.ConnectionId).FirstOrDefault();
			if (user ==null)
			{
				user = new User()
				{
					UserName = Context.ConnectionId,
					RoomName = groupname
				};
				db.Users.Add(user);
				await db.SaveChangesAsync();
				await Groups.Add(Context.ConnectionId, groupname);
				await this.UserNotify(groupname);
				await this.SendMessage(username, message, groupname);

			}
			else
			{
				await Groups.Add(Context.ConnectionId, groupname);
				await this.UserNotify(groupname);
				await this.SendMessage(username, message,groupname);
			}
		}
		public override Task OnConnected()
		{
			return base.OnConnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			var user = db.Users.Where(r => r.UserName == Context.ConnectionId).FirstOrDefault();
			if (user != null)
			{
				db.Users.Remove(user);
			}
			return base.OnDisconnected(stopCalled);
		}


	}
}