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
	public class Component : RemoteObject<Component> {
		private string _name;
		private int _quantity;
		private string _description;
		private Category _category;
		private SubCategory _subcategory;
		private Package _package;
		private List<Property> _properties;
		private Image _image;
		private Datasheet _datasheet;

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
			Picture = new Image();
			Datasheet = new Datasheet();
		}

		/// <summary>
		/// Creates a component object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Component(int id) : this() {
			ID = id;
		}

		/// <summary>
		/// Creates a component object with the name.
		/// </summary>
		/// <param name="name">Possible ID of the object in the database.</param>
		public Component(string name) : this() {
			Name = name;
			StageLoad();
		}

		/// <summary>
		/// Populates the specified list with all of the available components that belong
		/// to a given container given by <paramref name="criteria"/>.
		/// </summary>
		/// <typeparam name="T">Type of the container object. (e.g. <see cref="Category"/>)</typeparam>
		/// <param name="list">List to be populated with components from the remote server.</param>
		/// <param name="queryParam">URL parameter query name.</param>
		/// <param name="criteria">Container that will be used as filtering criteria</param>
		public void List<T>(IList<Component> list, string queryParam,
				RemoteObject<T> criteria) where T : RemoteObject<T>, new() {
			// Start with a blank slate.
			list.Clear();

			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("format", "xml");
			url.Parameters.Add(queryParam, criteria.ID);

			// Request the items from the server.
			WebRequest request = WebRequest.Create(url.ToString());
			XmlDocument doc = GetRemoteXML(request);

			// Populate the object.
			foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
				Component component = new Component();
				component.LoadFromXML(node);

				list.Add(component);
			}
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].InnerText);
			Name = node["name"].InnerText;
			Quantity = int.Parse(node["quantity"].InnerText);
			Description = node["description"].InnerText;
			Category.LoadFromXML(node["category"]);
			SubCategory.LoadFromXML(node["subcategory"]);
			Package.LoadFromXML(node["package"]);
			if (node["image"] != null)
				Picture.LoadFromXML(node["image"]);
			if (node["datasheet"] != null)
				Datasheet.LoadFromXML(node["datasheet"]);
			Properties.Clear();

			// Do we have a partial object?
			if (node["properties"] == null) {
				Persistent = PersistenceStatus.PartiallyLoaded;
				return;
			}

			// Finish loading up our properties.
			foreach (XmlNode subNode in node["properties"].ChildNodes) {
				Property property = new Property();
				property.LoadFromXML(subNode);

				Properties.Add(property);
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
			if (ID >= 0) {
				url.Parameters.Add("id", ID);
			} else if (Name.Length > 0) {
				url.Parameters.Add("name", Name);
			} else {
				throw new Exception("We need at least an ID or a name to " +
					"retrieve a component");
			}
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
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _properties; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _properties = value; }
		}

		/// <summary>
		/// Component image.
		/// </summary>
		public Image Picture {
			get { LazyLoad(); return _image; }
			set { LazyLoad(); _image = value; }
		}

		/// <summary>
		/// Component datasheet.
		/// </summary>
		public Datasheet Datasheet {
			get { LazyLoad(); return _datasheet; }
			set { LazyLoad(); _datasheet = value; }
		}
	}
}
