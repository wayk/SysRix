using System.Collections.Generic;

namespace SysRix.Models
{
	public class Server
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Type { get; set; }
		public string TransportType { get; set; }
		public int Port { get; set; }
	}

	public class IceServer
	{
		public string Credential;
		public string Username;
		public string Url;
	}
}