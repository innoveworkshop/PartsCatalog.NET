using System;
using System.Collections.Generic;
using System.Text;

namespace PartsCatalog {
	public class Configuration {
#if DEBUG
#if PocketPC
		public const string Domain = "192.168.1.10";
#else
		public const string Domain = "blueberry.farm.lan";
#endif
#else
		public const string Domain = "mulberry.farm.lan";
#endif
		public const string BaseURL = "http://" + Domain + ":8080/PartsCatalog";
	}
}
