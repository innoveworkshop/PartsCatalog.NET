using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Project abstraction.
	/// </summary>
	public class Project : RemoteObject<Project> {
		private string _name;
		private string _revision;
		private string _description;
		private List<BOMItem> _bomItems;

		/// <summary>
		/// Creates an empty project object.
		/// </summary>
		public Project() {
			Endpoint = "/project";
			Invalidate();
			BOM = new List<BOMItem>();
		}

		/// <summary>
		/// Creates a project object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Project(int id) : this() {
			ID = id;
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].Value);
			Name = node["name"].InnerText;
			Revision = node["revision"].InnerText;
			Description = node["description"].InnerText;
			BOM.Clear();

			// Check if we are loading in a partial object.
			if (node["bom"] == null) {
				Persistent = PersistenceStatus.PartiallyLoaded;
				return;
			}

			// Load in the BOM items.
			foreach (XmlNode subNode in node["bom"].ChildNodes) {
				BOMItem item = new BOMItem();
				item.LoadFromXML(subNode);

				BOM.Add(item);
			}

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

			// Prepare the request.
			WebRequest request = WebRequest.Create(url.ToString());
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			// Build request body.
			HttpRequestBody body = new HttpRequestBody();
			body.Parameters.Add("name", Name);
			body.Parameters.Add("revision", Revision);
			body.Parameters.Add("description", Description);
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
			return Name + " (Rev " + Revision + ")";
		}

		/// <summary>
		/// Project name.
		/// </summary>
		public string Name {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _name; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _name = value; }
		}

		/// <summary>
		/// Project revision.
		/// </summary>
		public string Revision {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _revision; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _revision = value; }
		}

		/// <summary>
		/// Project description.
		/// </summary>
		public string Description {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _description; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _description = value; }
		}

		/// <summary>
		/// BOM items.
		/// </summary>
		public List<BOMItem> BOM {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _bomItems; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _bomItems = value; }
		}
	}
}
