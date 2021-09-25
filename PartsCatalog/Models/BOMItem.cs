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
			Populate = Convert.ToBoolean(doc.DocumentElement.GetAttribute("populate"));
			Value = doc.DocumentElement["value"].InnerText;
			Part.ID = int.Parse(doc.DocumentElement["component"].GetAttribute("id"));
			Parent.ID = int.Parse(doc.DocumentElement["project"].GetAttribute("id"));
			RefDes.Clear();
			foreach (XmlNode node in doc.DocumentElement["refdesignators"].ChildNodes) {
				RefDes.Add(node.InnerText);
			}
			Quantity = int.Parse(doc.DocumentElement["quantity"].InnerText);

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
			get { LazyLoad(); return _populate; }
			set { LazyLoad(); _populate = value; }
		}

		/// <summary>
		/// BOM item quantity.
		/// </summary>
		public int Quantity {
			get { LazyLoad(); return _quantity; }
			set { LazyLoad(); _quantity = value; }
		}

		/// <summary>
		/// BOM item component value.
		/// </summary>
		public string Value {
			get { LazyLoad(); return _value; }
			set { LazyLoad(); _value = value; }
		}

		/// <summary>
		/// BOM item reference designators.
		/// </summary>
		public List<string> RefDes {
			get { LazyLoad(); return _refDes; }
			set {
				LazyLoad();
				_refDes = value;
				Quantity = _refDes.Count;
			}
		}

		/// <summary>
		/// BOM item reference designators as a string.
		/// </summary>
		public string RefDesString {
			get { LazyLoad(); return String.Join(" ", _refDes.ToArray()); }
			set {
				LazyLoad();
				_refDes = new List<string>(value.Split(' '));
				Quantity = _refDes.Count;
			}
		}

		/// <summary>
		/// BOM item component.
		/// </summary>
		public Component Part {
			get { LazyLoad(); return _component; }
			set { LazyLoad(); _component = value; }
		}

		/// <summary>
		/// BOM item parent project.
		/// </summary>
		public Project Parent {
			get { LazyLoad(); return _parent; }
			set { LazyLoad(); _parent = value; }
		}
	}
}
