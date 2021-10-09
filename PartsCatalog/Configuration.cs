using System;
using System.Collections.Generic;
using System.Text;

namespace PartsCatalog {
	public class Configuration {
#if DEBUG
		public const string Domain = "blueberry.farm.lan";
#else
		public const string Domain = "mulberry.farm.lan";
#endif
		public const string BaseURL = "http://" + Domain + ":8080/PartsCatalog";
	}
}
