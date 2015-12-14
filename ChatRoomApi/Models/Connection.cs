using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApi.Models
{
	public class Connection
	{
		public int ConnectionId { get; set; }
		public string UserAgent { get; set; }
		public bool Connected { get; set; }
	}
}
