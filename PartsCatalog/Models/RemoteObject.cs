using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using PartsCatalog.Utilities;

namespace PartsCatalog.Models {
	/// <summary>
	/// Abstracts objects that are available remotely via API endpoints.
	/// </summary>
	public abstract class RemoteObject<T> where T : RemoteObject<T>, new() {
		/// <summary>
		/// Base URL where the PartsCatalog web service is located at.
		/// </summary>
		protected const string BaseURL = "http://blueberry.farm.lan:8080/PartsCatalog";
		private string _endpoint;
		private int _id = -1;
		private PersistenceStatus _persistent = PersistenceStatus.Creating;

		/// <summary>
		/// Identifies the status of the persistent object.
		/// </summary>
		public enum PersistenceStatus {
			Creating = 0,
			NotLoaded = 1,
			Loading = 2,
			Loaded = 3
		}

		/// <summary>
		/// Populates the specified list with all of the available objects of its type.
		/// </summary>
		/// <param name="list">List to be populated with objects from the remote server.</param>
		public void List(IList<T> list) {
			// Build the query URL.
			URL url = new URL(BaseURL, Endpoint);
			url.Parameters.Add("format", "xml");

			// Request the items from the server.
			WebRequest request = WebRequest.Create(url.ToString());
			XmlDocument doc = GetRemoteXML(request);

			// Populate the object.
			foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
				T obj = new T();
				obj.ID = int.Parse(node.Attributes["id"].InnerText);

				list.Add(obj);
			}
		}

		/// <summary>
		/// Gets a list with all of the available objects of its type.
		/// </summary>
		/// <returns>List populated with objects from the remote server.</returns>
		public List<T> List() {
			List<T> list = new List<T>();
			List(list);
			return list;
		}

		/// <summary>
		/// Gets the XML document from the remote server.
		/// </summary>
		/// <param name="request">Prepared web request so that we only need to parse the output.</param>
		/// <returns>XML document from the remote server response.</returns>
		protected XmlDocument GetRemoteXML(WebRequest request) {
			try {
				// Request the item from the server.
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				if (response.StatusCode != HttpStatusCode.OK) {
					response.Close();
					Invalidate();

					throw new Exception("An error occurred while trying to fetch data " +
						"from the server. HTTP status: " + response.StatusCode + " " +
						response.StatusDescription);
				}

				// Get the server response and load it into the XML parser.
				XmlDocument doc = new XmlDocument();
				Stream stream = response.GetResponseStream();
				doc.Load(stream);
				stream.Close();
				response.Close();

				return doc;
			} catch (WebException ex) {
				Invalidate();

				// Get the response body and append it to the exception to be rethrown.
				Stream stream = ex.Response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);
				WebException wex = new WebException(ex.Message + 
					"Server response: " + reader.ReadToEnd(), ex);
				throw wex;
			}
		}

		/// <summary>
		/// Populates the object with data from the remote server when the ID property
		/// has previously been set.
		/// </summary>
		public abstract void Retrieve();

		/// <summary>
		/// Populates the object with data from the remote server by its ID.
		/// </summary>
		/// <param name="id">Object's ID in the database.</param>
		public void Retrieve(int id) {
			ID = id;
			Retrieve();
		}

		/// <summary>
		/// Commits any local changes to the class to the database.
		/// </summary>
		public abstract void Save();

		/// <summary>
		/// Deletes the entry from the remote database without affecting our local copy.
		/// </summary>
		public abstract void Delete();

		/// <summary>
		/// 
		/// </summary>
		protected void LazyLoad() {
			if (Persistent > PersistenceStatus.NotLoaded)
				return;

			// Populate the object.
			Retrieve();
		}

		/// <summary>
		/// Invalidates this object to flag that it's no longer persistent.
		/// </summary>
		public void Invalidate() {
			ID = -1;
			Persistent = PersistenceStatus.Creating;
		}

		/// <summary>
		/// Checks if the object has been fully loaded and is persistent.
		/// </summary>
		/// <returns>True if the object has been fully loaded.</returns>
		public Boolean IsPersistent() {
			return Persistent == PersistenceStatus.Loaded;
		}

		/// <summary>
		/// Endpoint at which the API is located. Excluding the base URL.
		/// </summary>
		protected string Endpoint {
			get { return _endpoint; }
			set { _endpoint = value; }
		}

		/// <summary>
		/// ID of the remote object in the database.
		/// </summary>
		public int ID {
			get { return _id; }
			set {
				if (value >= 0)
					Persistent = PersistenceStatus.NotLoaded;

				_id = value;
			}
		}

		/// <summary>
		/// Object and database persistence relationship.
		/// </summary>
		public PersistenceStatus Persistent {
			get { return _persistent; }
			set { _persistent = value; }
		}
	}
}
