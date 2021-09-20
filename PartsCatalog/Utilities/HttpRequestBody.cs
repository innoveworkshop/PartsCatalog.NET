using System;
using System.Collections.Generic;
using System.Text;

namespace PartsCatalog.Utilities {
	/// <summary>
	/// A simple class to help us build request bodies more easily.
	/// </summary>
	public class HttpRequestBody {
		private Dictionary<string, Object> parameters;

		/// <summary>
		/// Creates a new request body object.
		/// </summary>
		public HttpRequestBody() {
			Parameters = new Dictionary<string, object>();
		}

		/// <summary>
		/// Gets the formatted request body as a byte array.
		/// </summary>
		/// <returns>Formatted request body as a byte array.</returns>
		public byte[] GetBytes() {
			return Encoding.UTF8.GetBytes(ToString());
		}

		/// <summary>
		/// Formatted request body as a plain string.
		/// </summary>
		/// <returns>Properly formatted request body.</returns>
		public override string ToString() {
			string body = "";

			// Append the parameters.
			if (Parameters.Count > 0) {
				foreach (KeyValuePair<string, object> parameter in Parameters) {
					body += parameter.Key + "=" +
						Uri.EscapeUriString(parameter.Value.ToString()) + "&";
				}

				// Remote the trailling & from the string.
				body = body.Remove(body.Length - 1);
			}

			return body;
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
