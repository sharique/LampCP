using System;
using System.Configuration;

namespace LampCP
{
	public partial class LampConfigWin : Gtk.Window
	{
		public LampConfigWin () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		
		}

		protected void OnBtnSaveClicked (object sender, EventArgs e)
		{
			if (ConfigurationManager.AppSettings ["docroot"] == null) {
				ConfigurationManager.AppSettings.Add("docroot", "testing");
			}
		}
	}
}

