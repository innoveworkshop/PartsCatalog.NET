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
	/// Component datasheet abstraction.
	/// </summary>
	public class Datasheet : RemoteObject<Datasheet> {
		private Component _component;

		/// <summary>
		/// Creates a empty datasheet object.
		/// </summary>
		public Datasheet() {
			Endpoint = "/datasheet";
			Invalidate();
			AssociatedComponent = null;
		}

		/// <summary>
		/// Creates a datasheet object with the ID pre-populated.
		/// </summary>
		/// <param name="id">Possible ID of the object in the database.</param>
		public Datasheet(int id) : this() {
			ID = id;
		}

		/// <summary>
		/// Opens the component datasheet for viewing.
		/// </summary>
		public void Open() {
			// Make sure we are persistent.
			LazyLoad(PersistenceStatus.PartiallyLoaded);
			if (!IsPersistent())
				throw new Exception("Can't open the datasheet file in a non-persistent object");

			// Download the file and open it with the default viewer.
			Download();
			System.Diagnostics.Process.Start(FilePath);
		}

		/// <summary>
		/// Downloads the datasheet file from the server to a temporary location.
		/// </summary>
		/// <returns>Number of bytes downloaded.</returns>
		public uint Download() {
			// Make sure we are persistent.
			LazyLoad(PersistenceStatus.PartiallyLoaded);
			if (!IsPersistent())
				throw new Exception("Can't download the datasheet file in a non-persistent object");

			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("id", ID);
			url.Parameters.Add("download", "true");

			// Download the file.
			uint bytesDownloaded = FileUtil.DownloadFile(url.ToString(), FilePath);
			if (!HasFile())
				throw new Exception("Can't located the datasheet file that was downloaded");

			return bytesDownloaded;
		}

		/// <summary>
		/// Saves and upload the datasheet file.
		/// </summary>
		/// <param name="filePath">Datasheet file to be uploaded.</param>
		public void Upload(string filePath) {
			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("format", "xml");
			if (IsPersistent())
				url.Parameters.Add("id", ID);

			// Check if the associated component is valid.
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

			// Build request body.
			HttpRequestBody body = new HttpRequestBody();
			body.Encoding = HttpRequestBody.FormEncodingType.Multipart;
			body.Parameters.Add("component", AssociatedComponent.ID);
			body.Files.Add("file", new UploadFile("datasheet.pdf",
				File.ReadAllBytes(filePath)));

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
		/// Downloads a datasheet from the internet and then uploads it to the server.
		/// </summary>
		/// <param name="url">URL of the datasheet to download.</param>
		public void UploadFromURL(string url) {
			// Check if the associated component is valid.
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

			// Get our temporary file.
			string tmpFileName = Path.GetTempPath() + AssociatedComponent.Name +
				"-" + Guid.NewGuid().ToString() + ".pdf";

			// Prepare the request.
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version10;
			request.ServicePoint.ConnectionLimit = 1;
			request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Trident/7.0; rv:11.0) like Gecko";
			request.UseDefaultCredentials = true;

			// Request the file and perform some checks.
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if ((response.StatusCode != HttpStatusCode.OK) &&
					(response.StatusCode != HttpStatusCode.Moved) &&
					(response.StatusCode != HttpStatusCode.Redirect)) {
				throw new Exception("An error occured while trying to request the datasheet");
			}

			// Download the datasheet.
			Stream stream = response.GetResponseStream();
			Stream fileStream = File.OpenWrite(tmpFileName);
			byte[] bytes = new byte[4096];
			int bytesRead = 0;
			do {
				if (stream == null)
					continue;

				// Read the bytes and write them to the file.
				bytesRead = stream.Read(bytes, 0, bytes.Length);
				fileStream.Write(bytes, 0, bytesRead);
			} while (bytesRead != 0);
			stream.Close();
			fileStream.Close();

			// Upload our datasheet.
			Upload(tmpFileName);
		}

		public override void LoadFromXML(XmlNode node) {
			Persistent = PersistenceStatus.Loading;

			// Populate the object.
			ID = int.Parse(node.Attributes["id"].Value);
			if (node["component"] != null) {
				AssociatedComponent = new Component();
				AssociatedComponent.LoadFromXML(node["component"]);

				Persistent = PersistenceStatus.Loaded;
				return;
			}

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
			throw new NotImplementedException("This object requires a file upload, " +
				"so use Upload(string) instead of this.");
		}

		/// <summary>
		/// Checks if a datasheet is actually available to be downloaded.
		/// </summary>
		/// <returns>True if you can get a file from this object.</returns>
		public bool IsAvailable() {
			return Persistent >= PersistenceStatus.NotLoaded;
		}

		/// <summary>
		/// Checks if we actually have a datasheet associated with this object.
		/// </summary>
		/// <returns>True if we have a datasheet associated.</returns>
		public bool HasFile() {
			return File.Exists(FilePath);
		}

		public override string ToString() {
			// Check if we have a valid object.
			if (Persistent >= PersistenceStatus.NotLoaded)
				return "Datasheet #" + ID;

			return "No Datasheet";
		}

		/// <summary>
		/// Associated component.
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
		/// Datasheet temporary file path.
		/// </summary>
		public string FilePath {
			get {
				LazyLoad(PersistenceStatus.PartiallyLoaded);
				return Path.GetTempPath() + ID + "-" +
					FileUtil.GetFileNameSafeString(AssociatedComponent.Name) + ".pdf";
			}
		}
	}
}
