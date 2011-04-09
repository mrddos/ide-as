using System;
using Gtk;
using System.Collections.Generic;
using ideas.common;
using ideas.server.manager;

public partial class MainWindow : Gtk.Window
{
	static IdeasScadaApplication scadaApplication;
	
	/// <summary>
	/// Default constructor
	/// </summary>
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();

		scadaApplication = null;

	}
	
	/// <summary>
	/// Constructor from a Configuration setup
	/// </summary>
	/// <param name="config">
	/// A <see cref="Configuration"/>
	/// </param>
	public MainWindow (Configuration config) : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		if(config == null)
		{
			scadaApplication = null;
		}
		else
		{
			scadaApplication = new IdeasScadaApplication(config.file);
			UpdateScadaApplicationsListTree ();
		}
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
		// Check if a scada app was already loaded
		if(scadaApplication == null)
		{
			return;
		}
		
		TreeViewColumn artistColumn = new TreeViewColumn ();
		artistColumn.Title = "Application";
 
		Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText ();
		
		artistColumn.PackStart (artistNameCell, true);
  
		applicationTreeView.AppendColumn (artistColumn);
		
		artistColumn.AddAttribute (artistNameCell, "text", 0);		
		
		
		TreeStore applicationTreeStore = new TreeStore(typeof (string));
		Gtk.TreeIter applicationIter = applicationTreeStore.AppendValues (scadaApplication.Name);	
		
		foreach(IdeasScadaProject project in scadaApplication.Projects)
		{
			Gtk.TreeIter projectIter = applicationTreeStore.AppendValues(applicationIter, project.Name);
			
			Gtk.TreeIter screensIter = applicationTreeStore.AppendValues(projectIter, "Screens");
			
			foreach(IdeasScadaScreen screen in project.Screens)
			{
				applicationTreeStore.AppendValues(screensIter, screen.Name);
			}
			
			Gtk.TreeIter tagsDatabaseIter = applicationTreeStore.AppendValues(projectIter, "Tags Database");
			applicationTreeStore.AppendValues(tagsDatabaseIter, project.TagsDatabase.Name);
			
			Gtk.TreeIter tagsWebserviceIter = applicationTreeStore.AppendValues(projectIter, "Tags WebService");
			applicationTreeStore.AppendValues(tagsWebserviceIter, project.TagsWebService.Name);
		}
		
		applicationTreeView.Model = applicationTreeStore;
		
		applicationTreeView.ExpandAll();
			
		this.ShowAll();
	}

	protected virtual void aboutAction_Click (object sender, System.EventArgs e)
	{
		About aboutDialog = new About();
		
		aboutDialog.Show();
	}
	
	protected virtual void btnStart_Click (object sender, System.EventArgs e)
	{
		foreach(IdeasScadaProject project in scadaApplication.Projects)
		{
			project.TagsWebService.Start();
		}
		
		(sender as Gtk.Button).Sensitive = false;
	}
	
	protected virtual void btnStop_Click (object sender, System.EventArgs e)
	{
		foreach(IdeasScadaProject project in scadaApplication.Projects)
		{
			project.TagsWebService.Stop();
		}
	}
	
	
	
}
