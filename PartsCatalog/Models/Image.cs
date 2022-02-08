using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Drawing;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Component or package image abstraction.
	/// </summary>
	public class Image : RemoteObject<Image> {
		private Component _component;
		private Package _package;
		private byte[] _image;

		/// <summary>
		/// Creates an empty image object.
		/// </summary>
		public Image() {
			Endpoint = "/image";
			Invalidate();
			AssociatedComponent = null;
			AssociatedPackage = null;
		}

		/// <summary>
		/// Creates an image object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Image(int id) : this() {
			ID = id;
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].Value);
			if (node["component"] != null) {
				AssociatedComponent = new Component();
				AssociatedComponent.LoadFromXML(node["component"]);
			}
			if (node["package"] != null) {
				AssociatedPackage = new Package();
				AssociatedPackage.LoadFromXML(node["package"]);
			}

			// Check if we are only loading a partial object.
			if (node["file"] == null) {
				Persistent = PersistenceStatus.PartiallyLoaded;
				return;
			}

			// Load the file in.
			FileContent = Convert.FromBase64String(node["file"].InnerText);
			Persistent = PersistenceStatus.Loaded;

			// Make sure we at least got something to tie this image to.
			if ((node["component"] == null) && (node["package"] == null))
				Persistent = PersistenceStatus.PartiallyLoaded;
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

			// Check if the associated component is valid.
			if (AssociatedComponent != null) {
				if (!AssociatedComponent.IsPersistent()) {
					try {
						AssociatedComponent.Retrieve();
						if (!AssociatedComponent.IsPersistent())
							throw new Exception("Associated component still in creation");
					} catch (Exception ex) {
						throw new Exception("Associated component isn't persistent (" +
							ex.Message + ")");
					}
				}
			}

			// Check if the associated package is valid.
			if (AssociatedPackage != null) {
				if (!AssociatedPackage.IsPersistent()) {
					try {
						AssociatedPackage.Retrieve();
						if (!AssociatedPackage.IsPersistent())
							throw new Exception("Associated package still in creation");
					} catch (Exception ex) {
						throw new Exception("Associated package isn't persistent (" +
							ex.Message + ")");
					}
				}
			}

			// Build request body.
			HttpRequestBody body = new HttpRequestBody();
			body.Encoding = HttpRequestBody.FormEncodingType.Multipart;
			if (AssociatedComponent != null)
				body.Parameters.Add("component", AssociatedComponent.ID);
			if (AssociatedPackage != null)
				body.Parameters.Add("package", AssociatedPackage.ID);
			body.Files.Add("file", new UploadFile("image.jpg", FileContent));

			// Prepare the request.
			WebRequest request = WebRequest.Create(url.ToString());
			request.Method = "POST";
			request.ContentType = body.ContentType;

			// Send the request and get the response from the server.
			Stream stream = request.GetRequestStream();
			body.WriteBodyMultipart(stream);
			stream.Close();
			XmlDocument doc = GetRemoteXML(request);

			ID = int.Parse(doc.DocumentElement.GetAttribute("id"));
			Persistent = PersistenceStatus.Loaded;
		}

		/// <summary>
		/// Checks if we actually have an image associated with this object.
		/// </summary>
		/// <returns>True if we have an image associated.</returns>
		public bool HasImage() {
			return IsValid();
		}

		public override string ToString() {
			// Check if we actually have an image.
			if (IsValid())
				return "Image #" + ID;

			return "No Image";
		}

		/// <summary>
		/// Associated to a component?
		/// </summary>
		public Component AssociatedComponent {
			get {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				return _component;
			}
			set {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				_component = value;
			}
		}

		/// <summary>
		/// Associated to a package?
		/// </summary>
		public Package AssociatedPackage {
			get {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				return _package;
			}
			set {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				_package = value;
			}
		}

		/// <summary>
		/// Image as a byte array.
		/// </summary>
		public byte[] FileContent {
			get { LazyLoad(PersistenceStatus.PartiallyLoaded); return _image; }
			set { LazyLoad(PersistenceStatus.PartiallyLoaded); _image = value; }
		}

		/// <summary>
		/// Image as a bitmap.
		/// </summary>
		public Bitmap FileBitmap {
			get {
				MemoryStream ms = new MemoryStream();
				LazyLoad();

				// Check if we actually have an image.
				if (!HasImage())
					return null;

				// Create the bitmap image from the byte array.
				ms.Write(FileContent, 0, Convert.ToInt32(FileContent.Length));
				Bitmap bitmap = new Bitmap(ms, false);
				ms.Dispose();

				return bitmap;
			}
		}
	}
}
