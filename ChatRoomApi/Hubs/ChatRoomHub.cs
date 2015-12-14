using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ChatRoomApi.Hubs
{
	public class ChatRoomHub : Hub
	{
		public async Task JoinRoom(string roomName)
		{
			await Groups.Add(Context.ConnectionId, roomName);
			var group=Clients.Group(roomName);
			group.addChatMessage(Context.User.Identity.Name + "joined");
		}
		public async Task LeaveRoom(string roomName)
		{
			await Groups.Remove(Context.ConnectionId, roomName);
		}
	}
}