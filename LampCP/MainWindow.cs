using System;
using Gtk;
using Mono.Unix;
using Mono.Unix.Native;
using System.Diagnostics;
using LampCP;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		CheckStatus ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	void CheckStatus ()
	{
		lblMySql.Text = "Mysql : NA";
		lblApache.Text = "Apache : NA";
		string[] arg= {"apache2 status"};
		//lblApache.Text = Syscall.execv ("/usr/bin/service",arg).ToString();
		Process proc = new System.Diagnostics.Process();
		//proc.StartInfo.FileName = "/bin/bash";
		proc.StartInfo.FileName = "/usr/bin/service";
		proc.StartInfo.Arguments = "apache2 status";
		proc.StartInfo.UseShellExecute = false; 
		proc.StartInfo.RedirectStandardOutput =true;
		proc.Start();
		lblApache.Text =proc.StandardOutput.ReadLine();

		// check mysql status
		proc.StartInfo.Arguments = "mysql status";
		proc.Start();
		lblMySql.Text =proc.StandardOutput.ReadLine();
	}


	protected void OnBtnConfigApacheClicked (object sender, EventArgs e)
	{
		ApacheConfigWin apacheConfig = new ApacheConfigWin();
		apacheConfig.Parent = this;
		apacheConfig.Modal = true;
		apacheConfig.Show ();
	}

	protected void OnBtnConfigMysqlClicked (object sender, EventArgs e)
	{

	}

	protected void OnBtnConfigClicked (object sender, EventArgs e)
	{
		LampConfigWin configWin = new LampConfigWin ();
		configWin.Modal = true;
		configWin.Parent = this;
		configWin.Show ();
	}
}
