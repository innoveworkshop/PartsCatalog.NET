using System;
using System.Collections.Generic;
using System.Text;

namespace PartsCatalog.Utilities {
	/// <summary>
	/// Abstraction to represent a file that will be uploaded by
	/// <see cref="HttpRequestBody"/>.
	/// </summary>
	public class UploadFile {
		private string _fileName;
		private byte[] _contents;

		/// <summary>
		/// Create an empty file upload object to be populated.
		/// </summary>
		public UploadFile() {
			FileName = "";
			FileContents = null;
		}

		/// <summary>
		/// Create an upload file object fully populated.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="contents"></param>
		public UploadFile(string fileName, byte[] contents) : this() {
			FileName = fileName;
			FileContents = contents;
		}

		/// <summary>
		/// File name.
		/// </summary>
		public string FileName {
			get { return _fileName; }
			set { _fileName = value; }
		}

		/// <summary>
		/// File contents data.
		/// </summary>
		public byte[] FileContents {
			get { return _contents; }
			set { _contents = value; }
		}
	}
}
