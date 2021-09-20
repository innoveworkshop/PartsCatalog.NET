using System;
using System.Collections.Generic;
using System.Text;

namespace PartsCatalog.Utilities {
	/// <summary>
	/// A simple class to help us build URLs for requests more easily.
	/// </summary>
	public class URLBuilder {
		private string baseURL;
		private string endpoint;
		private Dictionary<string, Object> parameters;

		/// <summary>
		/// Creates a new URL builder object.
		/// </summary>
		/// <param name="baseURL">Base URL of an API.</param>
		/// <param name="endpoint">API endpoint.</param>
		public URLBuilder(string baseURL, string endpoint) {
			this.baseURL = baseURL;
			this.endpoint = endpoint;
			Parameters = new Dictionary<string, object>();
		}

		/// <summary>
		/// URL in its final built form.
		/// </summary>
		/// <returns>Properly formatted URL.</returns>
		public override string ToString() {
			string url = baseURL;

			// Make sure we don't get double slashes when appending the endpoint to the base URL.
			if (url.EndsWith("/") && endpoint.StartsWith("/"))
				url = url.Remove(url.Length - 1);
			url += endpoint;

			// Append the parameters.
			if (Parameters.Count > 0) {
				url += "?";
				foreach (KeyValuePair<string, object> parameter in Parameters) {
					url += parameter.Key + "=" + Uri.EscapeUriString(parameter.Value.ToString()) + "&";
				}

				// Remote the trailling & from the URL string.
				url = url.Remove(url.Length - 1);
			}

			return url;
		}

		/// <summary>
		/// URL GET parameters.
		/// </summary>
		public Dictionary<string, object> Parameters {
			get { return parameters; }
			set { parameters = value; }
		}
	}
}
