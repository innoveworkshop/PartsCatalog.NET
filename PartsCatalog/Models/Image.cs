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
			FileContent = Convert.FromBase64String(doc.DocumentElement["file"].InnerText);
			if (doc.DocumentElement["component"] != null)
				AssociatedComponent = new Component(
					int.Parse(doc.DocumentElement["component"].GetAttribute("id")));
			if (doc.DocumentElement["package"] != null)
				AssociatedPackage = new Package(
					int.Parse(doc.DocumentElement["package"].GetAttribute("id")));
			ID = int.Parse(doc.DocumentElement.GetAttribute("id"));

			Persistent = PersistenceStatus.Loaded;
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
			return FileContent != null;
		}

		public override string ToString() {
			// Check if we actually have an image.
			if (HasImage())
				return "Image #" + ID;

			return "No Image";
		}

		/// <summary>
		/// Associated to a component?
		/// </summary>
		public Component AssociatedComponent {
			get { LazyLoad(); return _component; }
			set { LazyLoad(); _component = value; }
		}

		/// <summary>
		/// Associated to a package?
		/// </summary>
		public Package AssociatedPackage {
			get { LazyLoad(); return _package; }
			set { LazyLoad(); _package = value; }
		}

		/// <summary>
		/// Image as a byte array.
		/// </summary>
		public byte[] FileContent {
			get { LazyLoad(); return _image; }
			set { LazyLoad(); _image = value; }
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