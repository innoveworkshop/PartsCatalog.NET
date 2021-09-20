using System;
using System.Collections.Generic;
using System.Text;

namespace PartsCatalog.Models {
	/// <summary>
	/// Abstracts objects that are available remotely via API endpoints.
	/// </summary>
	public abstract class RemoteObject {
		/// <summary>
		/// Base URL where the PartsCatalog web service is located at.
		/// </summary>
		protected const string BaseURL = "http://blueberry.farm.lan:8080/PartsCatalog";
		private string _endpoint;
		private int _id;
		private bool _persistent = false;

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
		/// <returns>True if the operation was successful.</returns>
		public abstract bool Save();

		/// <summary>
		/// Deletes the entry from the remote database without affecting our local copy.
		/// </summary>
		/// <returns>True if the operation was successful.</returns>
		public abstract bool Delete();

		/// <summary>
		/// 
		/// </summary>
		protected void LazyLoad() {
			if (Persistent)
				return;

			// Populate the object.
			Retrieve();
		}

		/// <summary>
		/// Checks if this object has been populated with database data.
		/// </summary>
		/// <returns>True if the object is persistent.</returns>
		public bool IsPersistent() {
			return Persistent;
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
			set { _id = value; }
		}

		/// <summary>
		/// Object and database persistence relationship.
		/// </summary>
		public bool Persistent {
			get { return _persistent; }
			set { _persistent = value; }
		}
	}
}
