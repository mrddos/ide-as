using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void mnuFileExit_Click (object sender, System.EventArgs e)
	{
		this.Dispose();
		Application.Quit();
	}
	
	
}

