using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApi.Models
{
	public class ConservationRoom
	{
		[Key]
		public string RoomName { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}

