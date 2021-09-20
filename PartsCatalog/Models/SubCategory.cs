using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Component sub-category abstraction.
	/// </summary>
	public class SubCategory : RemoteObject {
		private string _name;
		//private Category parent;

		/// <summary>
		/// Creates an empty sub-category object.
		/// </summary>
		public SubCategory() {
			Endpoint = "/subcategory";
		}

		/// <summary>
		/// Creates a sub-category object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public SubCategory(int id) : this() {
			ID = id;
		}

		public override void Retrieve() {
			// Build the query URL.
			URLBuilder url = new URLBuilder(BaseURL, Endpoint);
			url.Parameters.Add("id", ID);
			url.Parameters.Add("format", "xml");

			// Request the item from the server.
			WebRequest request = WebRequest.Create(url.ToString());
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode != HttpStatusCode.OK) {
				response.Close();
				Persistent = false;
				throw new Exception("No remote object with ID '" + ID + "' was found");
			}

			// Get the server response and load it into the XML parser.
			XmlDocument doc = new XmlDocument();
			doc.Load(response.GetResponseStream());
			response.Close();

			// Populate the object.
			Name = doc.DocumentElement["name"].InnerText;
			//Parent.ID = int.Parse(doc.DocumentElement["category"].GetAttribute("id"));

			Persistent = true;
		}

		public override bool Save() {
			throw new Exception("The method or operation is not implemented.");
		}

		public override bool Delete() {
			throw new Exception("The method or operation is not implemented.");
		}

		public override string ToString() {
			return Name;
		}

		/// <summary>
		/// Sub-category name.
		/// </summary>
		public string Name {
			get { LazyLoad(); return _name; }
			set { _name = value; }
		}
	}
}
