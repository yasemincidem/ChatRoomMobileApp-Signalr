using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApi.Models
{
	public class User
	{
		[Key]
		public string UserName { get; set; }
		public virtual ICollection<ConservationRoom> Rooms { get; set; }
		public virtual ICollection<Connection> Connections { get; set; }
	}
}
