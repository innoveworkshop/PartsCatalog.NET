using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PartsCatalog.Utilities {
	/// <summary>
	/// A simple class to help us build request bodies more easily.
	/// </summary>
	public class HttpRequestBody {
		private const string boundary = "X-PARTSCATALOG-BOUNDARY";
		private FormEncodingType _formEncoding;
		private Dictionary<string, Object> _parameters;
		private Dictionary<string, UploadFile> _files;

		/// <summary>
		/// Form body data encoding type.
		/// </summary>
		public enum FormEncodingType {
			UrlEncoded,
			Multipart
		}

		/// <summary>
		/// Creates a new request body object.
		/// </summary>
		public HttpRequestBody() {
			Parameters = new Dictionary<string, object>();
			Files = new Dictionary<string, UploadFile>();
			Encoding = FormEncodingType.UrlEncoded;
		}

		/// <summary>
		/// Gets the formatted request body as a byte array.
		/// </summary>
		/// <returns>Formatted request body as a byte array.</returns>
		public byte[] GetBytes() {
			return System.Text.Encoding.UTF8.GetBytes(ToString());
		}

		/// <summary>
		/// Gets the body parameters encoded as URL parameters.
		/// </summary>
		/// <returns>Body parameters encoded as URL parameters.</returns>
		private string GetBodyURLEncoded() {
			string body = "";

			// Check if we actually have files to upload and fail.
			if (Files.Count > 0)
				throw new Exception("Can't upload files using URL encoding. Change encoding!");

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
		/// Writes the body parameters encoded in multipart form format to a stream.
		/// </summary>
		/// <param name="stream">Stream to write the form data to.</param>
		public void WriteBodyMultipart(Stream stream) {
			// Check if we have the correct encoding type set.
			if (Encoding != FormEncodingType.Multipart)
				throw new Exception("Can't upload files using an FormEncodingType different than Multipart");

			// Append the parameters.
			if (Parameters.Count > 0) {
				foreach (KeyValuePair<string, object> parameter in Parameters) {
					// Build section string.
					string section = GetMultipartBoundary(false) + "\r\n" +
						GetMultipartDisposition(parameter.Key, null) +
						"\r\n\r\n" + parameter.Value.ToString() + "\r\n";

					// Send the section to the stream.
					WriteStringToStream(stream, section);
				}
			}

			// Append the files.
			if (Files.Count > 0) {
				foreach (KeyValuePair<string, UploadFile> file in Files) {
					// Build section string.
					string section = GetMultipartBoundary(false) + "\r\n" +
						GetMultipartDisposition(file.Key, file.Value.FileName) +
						"\r\n\r\n";

					// Send the section to the stream.
					WriteStringToStream(stream, section);
					stream.Write(file.Value.FileContents, 0,
						file.Value.FileContents.Length);
					WriteStringToStream(stream, "\r\n");
				}
			}

			// Send the last boundary.
			WriteStringToStream(stream, GetMultipartBoundary(true) + "\r\n");
		}

		/// <summary>
		/// Gets the boundary string for multipart form data.
		/// </summary>
		/// <param name="lastOne">Is this the last boundary?</param>
		/// <returns>Boundary multipart form data string.</returns>
		private string GetMultipartBoundary(bool lastOne) {
			if (lastOne)
				return "--" + boundary + "--";

			return "--" + boundary;
		}

		/// <summary>
		/// Gets the multipart form data Content-Disposition header string.
		/// </summary>
		/// <param name="name">Parameter name.</param>
		/// <param name="fileName">Uploaded file name. <c>null</c> if it shouldn't be
		/// included.</param>
		/// <returns>Multipart form data Content-Disposition header string.</returns>
		private string GetMultipartDisposition(string name, string fileName) {
			string buffer = "Content-Disposition: form-data; name=\"" + name + "\"";
			if (fileName != null)
				buffer += "; filename=\"" + fileName + "\"";

			return buffer;
		}

		/// <summary>
		/// Writes a string to a stream.
		/// </summary>
		/// <param name="stream">Stream to be written to.</param>
		/// <param name="buffer">String that will be sent to the stream.</param>
		private void WriteStringToStream(Stream stream, string buffer) {
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(buffer);
			stream.Write(bytes, 0, bytes.Length);
		}

		/// <summary>
		/// Formatted request body as a plain string.
		/// </summary>
		/// <returns>Properly formatted request body.</returns>
		public override string ToString() {
			switch (Encoding) {
			case FormEncodingType.UrlEncoded:
				return GetBodyURLEncoded();
			case FormEncodingType.Multipart:
				throw new Exception("Can't get a string from a multipart encoded form");
			}

			throw new Exception("Invalid encoding");
		}

		/// <summary>
		/// Form simple parameters.
		/// </summary>
		public Dictionary<string, object> Parameters {
			get { return _parameters; }
			set { _parameters = value; }
		}

		/// <summary>
		/// Form files parameters.
		/// </summary>
		public Dictionary<string, UploadFile> Files {
			get { return _files; }
			set { _files = value; }
		}

		/// <summary>
		/// Form body data encoding type.
		/// </summary>
		public FormEncodingType Encoding {
			get { return _formEncoding; }
			set { _formEncoding = value; }
		}

		/// <summary>
		/// Content-Type header string according to the selected encoding type.
		/// </summary>
		public string ContentType {
			get {
				switch (Encoding) {
				case FormEncodingType.UrlEncoded:
					return "application/x-www-form-urlencoded";
				case FormEncodingType.Multipart:
					return "multipart/form-data;boundary=\"" + boundary + "\"";
				}

				throw new Exception("Invalid encoding");
			}
		}
	}
}
