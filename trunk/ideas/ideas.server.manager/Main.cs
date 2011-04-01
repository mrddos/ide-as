using System;
using Gtk;

namespace ideas.server.manager
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Inicia a aplicacao
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}

