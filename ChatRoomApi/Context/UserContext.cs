using ChatRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApi.Context
{
	public class UserContext : DbContext
	{
		public UserContext() : base("UserContext")
		{
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Connection> Connections { get; set; }
		public virtual DbSet<ConservationRoom> Rooms { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	
	}
}
