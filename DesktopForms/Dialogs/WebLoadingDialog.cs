using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PartsCatalog.DesktopForms.Dialogs {
	/// <summary>
	/// A simple loading dialog to show the user that we are grabbing something
	/// from the web service.
	/// </summary>
	public partial class WebLoadingDialog : Form {
		protected const string fetchingMessageFormat = "Fetching {0} from the PartsCatalog web service...";
		protected const string sendingMessageFormat = "Sending {0} data to the PartsCatalog web service...";

		/// <summary>
		/// Initializes the loading dialog.
		/// </summary>
		public WebLoadingDialog() {
			InitializeComponent();

			// Set the default message.
			SetFetchMessage("data");
		}

		/// <summary>
		/// Pops up the dialog with a nice fetch message set.
		/// </summary>
		/// <param name="parent">Parent window to this dialog.</param>
		/// <param name="itemName">Item name to be shown in the default message.</param>
		public void ShowFetching(Form parent, string itemName) {
			SetFetchMessage(itemName);

			if (!Visible)
				Show(parent);
			CenterToParent();
		}

		/// <summary>
		/// Pops up the dialog with a nice send message set.
		/// </summary>
		/// <param name="parent">Parent window to this dialog.</param>
		/// <param name="itemName">Item name to be shown in the default message.</param>
		public void ShowSending(Form parent, string itemName) {
			SetSendMessage(itemName);

			if (!Visible)
				Show(parent);
			CenterToParent();
		}

		/// <summary>
		/// Sets a standard "Fetching <paramref name="item"/> from the
		/// PartsCatalog web service" message.
		/// </summary>
		/// <param name="item">Item name to be shown in the message</param>
		public void SetFetchMessage(string item) {
			lblMessage.Text = String.Format(fetchingMessageFormat, item);
		}

		/// <summary>
		/// Sets a standard "Sending <paramref name="item"/> data to the
		/// PartsCatalog web service" message.
		/// </summary>
		/// <param name="item">Item name to be shown in the message</param>
		public void SetSendMessage(string item) {
			lblMessage.Text = String.Format(sendingMessageFormat, item);
		}

		/// <summary>
		/// Message that is displayed to the user.
		/// </summary>
		public string Message {
			get { return lblMessage.Text; }
			set { lblMessage.Text = value; }
		}
	}
}