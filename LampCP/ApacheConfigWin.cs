using System;

namespace LampCP
{
	public partial class ApacheConfigWin : Gtk.Window
	{
		public ApacheConfigWin () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

