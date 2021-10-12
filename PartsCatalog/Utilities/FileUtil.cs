using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace PartsCatalog.Utilities {
	/// <summary>
	/// A collection of file utility methods.
	/// </summary>
	public static class FileUtil {
		private const int DownloadFileBlockSize = 4096;

		/// <summary>
		/// Strips invalid file name caracthers from a string.
		/// </summary>
		/// <param name="buffer">String to be sanitized.</param>
		/// <returns>Sanitized string.</returns>
		public static string GetFileNameSafeString(string buffer) {
			string tmp = buffer;

			// Go through the invalid characters and strip them from the buffer.
			foreach (char c in Path.GetInvalidFileNameChars()) {
				tmp = tmp.Replace(c.ToString(), string.Empty);
			}

			return tmp;
		}

		/// <summary>
		/// Downloads a file from a URL to a defined location.
		/// </summary>
		/// <param name="url">URL of the file to be downloaded.</param>
		/// <param name="filePath">Path to the file to be written to.</param>
		/// <returns>Number of bytes downloaded.</returns>
		public static uint DownloadFile(string url, string filePath) {
			uint bytesProcessed = 0;

			try {
				// Request the item from the server.
				WebRequest request = WebRequest.Create(url);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				if (response.StatusCode != HttpStatusCode.OK) {
					response.Close();
					throw new Exception("An error occurred while trying to fetch the " +
						"file from the server. HTTP status: " + response.StatusCode +
						" " + response.StatusDescription);
				}

				// Get the server response.
				Stream stream = response.GetResponseStream();
				FileStream fileStream = File.OpenWrite(filePath);
				
				// Pipe the response into the file.
				byte[] buffer = new byte[DownloadFileBlockSize];
				int bytesRead;
				while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {
					fileStream.Write(buffer, 0, bytesRead);
					bytesProcessed += (uint)bytesRead;
				}

				// Clean up.
				fileStream.Flush();
				fileStream.Close();
				stream.Close();
				response.Close();
			} catch (WebException ex) {
				// Get the response body and append it to the exception to be rethrown.
				Stream stream = ex.Response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);
				WebException wex = new WebException(ex.Message +
					"Server response: " + reader.ReadToEnd(), ex);
				throw wex;
			}

			return bytesProcessed;
		}

		/// <summary>
		/// Checks if a specific path points to a regular file as defined
		/// by <see cref="FileAttributes.Normal"/>.
		/// </summary>
		/// <param name="filePath">Path to the file to be tested.</param>
		/// <returns>True if the path points to a regular file.</returns>
		public static bool IsFile(string filePath) {
			FileAttributes attr = File.GetAttributes(filePath);
			return (attr & FileAttributes.Normal) == FileAttributes.Normal;
		}
	}
}
