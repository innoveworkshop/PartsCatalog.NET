using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Component category abstraction.
	/// </summary>
	public class Category : RemoteObject<Category> {
		private string _name;
		private List<SubCategory> _subCategories;

		/// <summary>
		/// Creates an empty category object.
		/// </summary>
		public Category() {
			Endpoint = "/category";
			Invalidate();
			SubCategories = new List<SubCategory>();
		}

		/// <summary>
		/// Creates a category object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Category(int id) : this() {
			ID = id;
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].Value);
			Name = node["name"].InnerText;
			SubCategories.Clear();

			// Do we have a partial object?
			if (node["subcategories"] == null) {
				Persistent = PersistenceStatus.PartiallyLoaded;
				return;
			}

			// Load up our sub-categories.
			foreach (XmlNode subNode in node["subcategories"].ChildNodes) {
				SubCategory subCategory = new SubCategory();
				subCategory.LoadFromXML(subNode);

				SubCategories.Add(subCategory);
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
			// Delete this category's childs.
			foreach (SubCategory subCategory in SubCategories) {
				subCategory.Delete();
			}

			// Actually delete this.
			base.Delete();
		}

		public override string ToString() {
			return Name;
		}

		/// <summary>
		/// Category name.
		/// </summary>
		public string Name {
			get { LazyLoad(); return _name; }
			set { LazyLoad(); _name = value; }
		}

		/// <summary>
		/// Child sub-categories.
		/// </summary>
		public List<SubCategory> SubCategories {
			get {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				return _subCategories;
			}

			set {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				_subCategories = value;
			}
		}
	}
}
