using System;
using Gtk;
using System.Collections.Generic;
using ideas.common;
using ideas.server.manager;

public partial class MainWindow : Gtk.Window
{
	static IdeasScadaApplication scadaApplication;
	
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		scadaApplication = null;
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
		
		string fileName = fileChooserDialog.Filename;
		
		// Destroy the dialog
		fileChooserDialog.Destroy();
		
		// Handle the dialog's exit value
		// read the file name from Fcd.Filename
		if (RetVal == ResponseType.Ok) 
		{			
			// Load application's configuration file
			LoadScadaFile(fileName);
		} 	
	}
	
	
	
	/// <summary>
	/// Loads the SCADA configuration file. Converts XML to a ScadaApplication class
	/// </summary>
	/// <param name="scadafile">
	/// A <see cref="System.String"/>
	/// </param>
	public void LoadScadaFile(string scadafile)
	{
		scadaApplication = new IdeasScadaApplication(scadafile);
		
		// Updates the list tree/expander
		UpdateScadaApplicationsListTree();
	}
	
	protected void UpdateScadaApplicationsListTree ()
	{
		if(scadaApplication == null)
		{
			return;
		}
		
		foreach(IdeasScadaProject project in scadaApplication.Projects)
		{
			expApplicationExpander.Add(new Label("teste"));
			//expApplicationExpander.Add(;
			
		}
		
		
	}
	
	/// <summary>
	/// Shows a regular message dialog with custom text
	/// </summary>
	/// <param name="textString">
	/// A <see cref="System.String"/>
	/// </param>
	public static void ShowErrorMessageDialog(string textString)
	{
		MessageDialog msgDialog = 
				new MessageDialog(
				    null, 
					DialogFlags.Modal,
					MessageType.Error,
					ButtonsType.Ok,
					textString);
			
			msgDialog.Run();
			msgDialog.Destroy();		
	}

}
