using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Component item abstraction.
	/// </summary>
	public class Component : RemoteObject {
		private string _name;
		private int _quantity;
		private string _description;
		private Category _category;
		private SubCategory _subcategory;
		private Package _package;
		private List<Property> _properties;

		/// <summary>
		/// Creates an empty component object.
		/// </summary>
		public Component() {
			Endpoint = "/component";
			Invalidate();
			Category = new Category();
			SubCategory = new SubCategory();
			Package = new Package();
			Properties = new List<Property>();
		}

		/// <summary>
		/// Creates a component object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Component(int id) : this() {
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
			Quantity = int.Parse(doc.DocumentElement["quantity"].InnerText);
			Description = doc.DocumentElement["description"].InnerText;
			Category.ID = int.Parse(doc.DocumentElement["category"].GetAttribute("id"));
			SubCategory.ID = int.Parse(doc.DocumentElement["subcategory"].GetAttribute("id"));
			Package.ID = int.Parse(doc.DocumentElement["package"].GetAttribute("id"));
			Properties.Clear();
			foreach (XmlNode node in doc.DocumentElement["properties"].ChildNodes) {
				Properties.Add(new Property(int.Parse(node.Attributes["id"].InnerText)));
			}

			Persistent = PersistenceStatus.Loaded;
		}

		public override void Save() {
			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("format", "xml");
			if (IsPersistent())
				url.Parameters.Add("id", ID);

			// Check for the validity of the category.
			if (!Category.IsPersistent()) {
				try {
					Category.Retrieve();
					if (!Category.IsPersistent())
						throw new Exception("Component category still in creation");
				} catch (Exception ex) {
					throw new Exception("Component category isn't persistent (" +
						ex.Message + ")");
				}
			}

			// Check for the validity of the sub-category.
			if (!SubCategory.IsPersistent()) {
				try {
					SubCategory.Retrieve();
					if (!SubCategory.IsPersistent())
						throw new Exception("Component sub-category still in creation");
				} catch (Exception ex) {
					throw new Exception("Component sub-category isn't persistent (" +
						ex.Message + ")");
				}
			}

			// Check for the validity of the sub-category.
			if (!Package.IsPersistent()) {
				try {
					Package.Retrieve();
					if (!Package.IsPersistent())
						throw new Exception("Component package still in creation");
				} catch (Exception ex) {
					throw new Exception("Component package isn't persistent (" +
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
			body.Parameters.Add("quantity", Quantity);
			body.Parameters.Add("description", Description);
			body.Parameters.Add("category", Category.ID);
			body.Parameters.Add("subcategory", SubCategory.ID);
			body.Parameters.Add("package", Package.ID);
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
			Properties.Clear();

			Invalidate();
		}

		public override string ToString() {
			return Name;
		}

		/// <summary>
		/// Component name.
		/// </summary>
		public string Name {
			get { LazyLoad(); return _name; }
			set { LazyLoad(); _name = value; }
		}

		/// <summary>
		/// Component quantity
		/// </summary>
		public int Quantity {
			get { LazyLoad(); return _quantity; }
			set { LazyLoad(); _quantity = value; }
		}

		/// <summary>
		/// Component description.
		/// </summary>
		public string Description {
			get { LazyLoad(); return _description; }
			set { LazyLoad(); _description = value; }
		}

		/// <summary>
		/// Component category.
		/// </summary>
		public Category Category {
			get { LazyLoad(); return _category; }
			set { LazyLoad(); _category = value; }
		}

		/// <summary>
		/// Component sub-category.
		/// </summary>
		public SubCategory SubCategory {
			get { LazyLoad(); return _subcategory; }
			set { LazyLoad(); _subcategory = value; }
		}

		/// <summary>
		/// Component package.
		/// </summary>
		public Package Package {
			get { LazyLoad(); return _package; }
			set { LazyLoad(); _package = value; }
		}

		/// <summary>
		/// Component properties list.
		/// </summary>
		public List<Property> Properties {
			get { LazyLoad(); return _properties; }
			set { LazyLoad(); _properties = value; }
		}
	}
}
