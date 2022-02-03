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
	public class SubCategory : RemoteObject<SubCategory> {
		private string _name;
		private Category _parent;

		/// <summary>
		/// Creates an empty sub-category object.
		/// </summary>
		public SubCategory() {
			Endpoint = "/subcategory";
			Invalidate();
			Parent = new Category();
		}

		/// <summary>
		/// Creates a sub-category object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public SubCategory(int id) : this() {
			ID = id;
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].Value);
			Name = node["name"].InnerText;

			// Check if we have a parent category object.
			if (node["category"] == null) {
				Persistent = PersistenceStatus.PartiallyLoaded;
				return;
			}

			// Load the parent category.
			Parent.LoadFromXML(node["category"]);
			Persistent = PersistenceStatus.Loaded;
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
			LoadFromXML(doc.DocumentElement);
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
						throw new Exception("Parent category still in creation");
				} catch (Exception ex) {
					throw new Exception("Parent category isn't persistent (" +
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
			body.Parameters.Add("category", Parent.ID);
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
			return Name;
		}

		/// <summary>
		/// Sub-category name.
		/// </summary>
		public string Name {
			get { LazyLoad(); return _name; }
			set { LazyLoad(); _name = value; }
		}

		/// <summary>
		/// Parent category.
		/// </summary>
		public Category Parent {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _parent; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _parent = value; }
		}
	}
}
