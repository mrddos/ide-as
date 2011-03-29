using System;
using Gtk;
using System.Collections.Generic;
using ideas.server.manager;

public partial class MainWindow : Gtk.Window
{
	static List<IdeasScadaApplication> scadaApplicationsList;
	
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		scadaApplicationsList = new List<IdeasScadaApplication>();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void mnuFileExit_Click (object sender, System.EventArgs e)
	{
		this.Destroy();
		Application.Quit();
	}
	
	protected virtual void mnuOpenApplication_Click (object sender, System.EventArgs e)
	{
		FileChooserDialog fileChooserDialog = 
			new FileChooserDialog ("Open file", 
			                       null, 
			                       FileChooserAction.Open);
		
		// Add buttons to file dialog
		fileChooserDialog.AddButton(Stock.Cancel, ResponseType.Cancel);
		fileChooserDialog.AddButton(Stock.Open, ResponseType.Ok);
		
		// Select file filters
		fileChooserDialog.Filter = new FileFilter();
		fileChooserDialog.Filter.AddPattern("*.scada");
		
		fileChooserDialog.SelectMultiple = false;
		
		ResponseType RetVal = (ResponseType)fileChooserDialog.Run();
		
		// Handle the dialog's exit value
		// read the file name from Fcd.Filename
		if (RetVal == ResponseType.Ok) 
		{
			// Load application's configuration file
			LoadScadaFile(fileChooserDialog.Filename);
		} 
		
		// Destroy the dialog
		fileChooserDialog.Destroy();
		
	}
	
	
	
	/// <summary>
	/// Loads the SCADA configuration file. Converts XML to a ScadaApplication class
	/// </summary>
	/// <param name="scadafile">
	/// A <see cref="System.String"/>
	/// </param>
	public static void LoadScadaFile(string scadafile)
	{
		IdeasScadaApplication newScadaApp = new IdeasScadaApplication(scadafile);
		scadaApplicationsList.Add(newScadaApp);
		
		// Updates the list tree/expander
		UpdateScadaApplicationsListTree();
	}
	
	static void UpdateScadaApplicationsListTree ()
	{
		throw new System.NotImplementedException ();
	}

}
