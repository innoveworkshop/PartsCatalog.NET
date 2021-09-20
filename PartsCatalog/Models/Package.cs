using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Component package abstraction.
	/// </summary>
	public class Package : RemoteObject {
		private string _name;

		/// <summary>
		/// Creates an empty package object.
		/// </summary>
		public Package() {
			Endpoint = "/package";
			Invalidate();
		}

		/// <summary>
		/// Creates a package object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Package(int id) : this() {
			ID = id;
		}

		public override void Retrieve() {
			// Prevent loading when the object is being populated.
			if (Persistent == PersistenceStatus.Creating)
				return;
			Persistent = PersistenceStatus.Loading;

			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("id", ID);
			url.Parameters.Add("format", "xml");

			// Request the item from the server.
			WebRequest request = WebRequest.Create(url.ToString());
			XmlDocument doc = GetRemoteXML(request);

			// Populate the object.
			Name = doc.DocumentElement["name"].InnerText;

			Persistent = PersistenceStatus.Loaded;
		}

		public override void Save() {
			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("format", "xml");
			if (IsPersistent())
				url.Parameters.Add("id", ID);

			// Prepare the request.
			WebRequest request = WebRequest.Create(url.ToString());
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			// Build request body.
			HttpRequestBody body = new HttpRequestBody();
			body.Parameters.Add("name", Name);
			byte[] bodyBytes = body.GetBytes();

			// Send the request and get the response from the server.
			request.ContentLength = bodyBytes.Length;
			Stream stream = request.GetRequestStream();
			stream.Write(bodyBytes, 0, bodyBytes.Length);
			stream.Close();
			XmlDocument doc = GetRemoteXML(request);

			ID = int.Parse(doc.DocumentElement.GetAttribute("id"));
			Persistent = PersistenceStatus.Loaded;
		}

		public override void Delete() {
			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("id", ID);
			url.Parameters.Add("format", "xml");

			// Request the item from the server.
			WebRequest request = WebRequest.Create(url.ToString());
			request.Method = "DELETE";
			GetRemoteXML(request);

			Invalidate();
		}

		public override string ToString() {
			return Name;
		}

		/// <summary>
		/// Package name.
		/// </summary>
		public string Name {
			get { LazyLoad(); return _name; }
			set { LazyLoad(); _name = value; }
		}
	}
}
