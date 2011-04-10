using System;
using Gtk;


namespace Ideas.Server.Manager
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MainWindow win;
			
			// Inicia a aplicacao
			Application.Init ();
			
			if(args.Length == 0)
			{
				 win = new MainWindow ();
			}
			else
			{				
				
				Configuration config = new Configuration();
				string[] newargs;
				
				// If there is only one arg, it is assumed that that is the file arg.
				if(!args[0].StartsWith("-"))
				{
					newargs = new string[] {"-f", args[0]};
				}
				else
				{
					newargs = args;
				}
				
				config.ProcessArgs(newargs);
				win = new MainWindow(config);
			}
			
			win.Show ();
			Application.Run ();
		}
	}
}

