using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Project BOM item abstraction.
	/// </summary>
	public class BOMItem : RemoteObject<BOMItem> {
		private bool _populate;
		private int _quantity;
		private string _value;
		private List<string> _refDes;
		private Component _component;
		private Project _parent;

		/// <summary>
		/// Creates an empty project BOM item object.
		/// </summary>
		public BOMItem() {
			Endpoint = "/bom_item";
			Invalidate();
			RefDes = new List<string>();
			Part = new Component();
			Parent = new Project();
		}

		/// <summary>
		/// Creates a project BOM item object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public BOMItem(int id) : this() {
			ID = id;
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].Value);
			Populate = Convert.ToBoolean(node.Attributes["populate"].Value);
			Value = node["value"].InnerText;
			Part.LoadFromXML(node["component"]);
			RefDes.Clear();
			foreach (XmlNode subNode in node["refdesignators"].ChildNodes) {
				RefDes.Add(subNode.InnerText);
			}
			Quantity = int.Parse(node["quantity"].InnerText);

			// Check if we are only loading a partial object.
			if (node["project"] == null) {
				Persistent = PersistenceStatus.PartiallyLoaded;
				return;
			}

			// Load the parent project in.
			Parent.LoadFromXML(node["project"]);

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
						throw new Exception("Parent project still in creation");
				} catch (Exception ex) {
					throw new Exception("Parent project isn't persistent (" +
						ex.Message + ")");
				}
			}

			// Check if the component is valid.
			if (!Part.IsPersistent()) {
				try {
					Part.Retrieve();
					if (!Part.IsPersistent())
						throw new Exception("Component still in creation");
				} catch (Exception ex) {
					throw new Exception("Component isn't persistent (" +
						ex.Message + ")");
				}
			}

			// Make sure we have a valid value.
			if (Value == null)
				Value = "";

			// Prepare the request.
			WebRequest request = WebRequest.Create(url.ToString());
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			// Build request body.
			HttpRequestBody body = new HttpRequestBody();
			body.Parameters.Add("populate", Populate);
			body.Parameters.Add("value", Value);
			body.Parameters.Add("quantity", Quantity);
			body.Parameters.Add("refdes", RefDesString);
			body.Parameters.Add("component", Part.ID);
			body.Parameters.Add("project", Parent.ID);
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
			return Part.Name;
		}

		/// <summary>
		/// BOM item component should be populated?
		/// </summary>
		public bool Populate {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _populate; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _populate = value; }
		}

		/// <summary>
		/// BOM item quantity.
		/// </summary>
		public int Quantity {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _quantity; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _quantity = value; }
		}

		/// <summary>
		/// BOM item component value.
		/// </summary>
		public string Value {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _value; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _value = value; }
		}

		/// <summary>
		/// BOM item reference designators.
		/// </summary>
		public List<string> RefDes {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _refDes; }
			set {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				_refDes = value;
				Quantity = _refDes.Count;
			}
		}

		/// <summary>
		/// BOM item reference designators as a string.
		/// </summary>
		public string RefDesString {
			get {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				return String.Join(" ", _refDes.ToArray());
			}
			set {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				_refDes = new List<string>(value.Split(' '));
				Quantity = _refDes.Count;
			}
		}

		/// <summary>
		/// BOM item component.
		/// </summary>
		public Component Part {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _component; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _component = value; }
		}

		/// <summary>
		/// BOM item parent project.
		/// </summary>
		public Project Parent {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _parent; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _parent = value; }
		}
	}
}
