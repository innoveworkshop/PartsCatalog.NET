using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Component property abstraction.
	/// </summary>
	public class Property : RemoteObject<Property> {
		private string _name;
		private string _value;
		private Component _parent;

		/// <summary>
		/// Creates an empty package object.
		/// </summary>
		public Property() {
			Endpoint = "/property";
			Invalidate();
			Parent = new Component();
		}

		/// <summary>
		/// Creates a property object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Property(int id) : this() {
			ID = id;
		}

		/// <summary>
		/// Creates a new property with its name and value pre-populated.
		/// </summary>
		/// <param name="name">Property name.</param>
		/// <param name="value">Property value.</param>
		public Property(string name, string value) : this() {
			Name = name;
			Value = value;
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
			Value = doc.DocumentElement["value"].InnerText;
			Parent.ID = int.Parse(doc.DocumentElement["component"].GetAttribute("id"));

			Persistent = PersistenceStatus.Loaded;
		}

		public override void Save() {
			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("format", "xml");
			if (IsPersistent())
				url.Parameters.Add("id", ID);

			// Check if the parent is valid.
			if (!Parent.IsPersistent()) {
				try {
					Parent.Retrieve();
					if (!Parent.IsPersistent())
						throw new Exception("Parent component still in creation");
				} catch (Exception ex) {
					throw new Exception("Parent component isn't persistent (" +
						ex.Message + ")");
				}
			}

			// Prepare the request.
			WebRequest request = WebRequest.Create(url.ToString());
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			// Build request body.
			HttpRequestBody body = new HttpRequestBody();
			body.Parameters.Add("name", Name);
			body.Parameters.Add("value", Value);
			body.Parameters.Add("component", Parent.ID);
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

		public override string ToString() {
			return Name + ": " + Value;
		}

		/// <summary>
		/// Property name.
		/// </summary>
		public string Name {
			get { LazyLoad(); return _name; }
			set { LazyLoad(); _name = value; }
		}

		/// <summary>
		/// Property value.
		/// </summary>
		public string Value {
			get { LazyLoad(); return _value; }
			set { LazyLoad(); _value = value; }
		}

		/// <summary>
		/// Parent component.
		/// </summary>
		public Component Parent {
			get { LazyLoad(); return _parent; }
			set { LazyLoad(); _parent = value; }
		}
	}
}
