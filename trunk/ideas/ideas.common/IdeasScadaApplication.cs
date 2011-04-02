using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace ideas.common
{
	public class IdeasScadaApplication
	{
		string rootPath;
		string filePath;
		List<IdeasScadaProject> projects = new List<IdeasScadaProject>();
		
		/// <summary>
		/// Constructs the class from the xml Scada file
		/// </summary>
		/// <param name="scadafile">
		/// A <see cref="System.String"/>
		/// </param>
		public IdeasScadaApplication (string scadafile)
		{
			LoadFromXML(scadafile);			
		}
		
		public void LoadFromXML(string scadafile)
		{
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(scadafile);
				xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
				
				XmlDocument xmlScadaFile = new XmlDocument();
				
				xmlScadaFile.Load(xmlTextReader);
			
				XmlNodeList nodesList = xmlScadaFile.GetElementsByTagName("Application");
			
				// Verifies if there is only one Application settings for the file
				if(nodesList.Count > 1)
				{
					throw new Exception("This file has more than one Application settings. Please make sure that there is only one Application settings for each file.");
				}
								
				// Loads application settings
				LoadProjectSettings(xmlScadaFile);
				
				// Saves the path to the Scada file
				filePath = scadafile;
				
				// Saves the root path
				rootPath = Path.GetDirectoryName(scadafile);

			}
			catch(Exception e)
			{
				util.ShowErrorMessageDialog("The configuration file is invalid or corrupted. " + e.Message);
			}
		}
		
		private void LoadProjectSettings(XmlDocument xmlScadaFile)
		{
			XmlNodeList nodesList = xmlScadaFile.GetElementsByTagName("Project");
			
			foreach(XmlNode node in nodesList)
			{
				string nodeName = node.Attributes["name"].Value;
				string nodePath = node.Attributes["path"].Value;
				
				IdeasScadaProject projectToAdd = new IdeasScadaProject();
				projectToAdd.Name = nodeName;
				projectToAdd.FilePath = nodePath;
				
				foreach(XmlNode childNode in node.ChildNodes)
				{
					LoadProjectScreen(childNode, projectToAdd);
					LoadProjectTagsDatabase(childNode, projectToAdd);
					LoadProjectTagsWebservice(childNode, projectToAdd);
					
				}
				
				Projects.Add(projectToAdd);
			}
		}
		
		/// <summary>
		/// Load a screen configuration configuration if it is a correspondant Xml node
		/// </summary>
		/// <param name="xmlProjectNode">
		/// A <see cref="XmlNode"/>
		/// </param>
		private void LoadProjectScreen(XmlNode xmlScreenNode, IdeasScadaProject project)
		{
			if(xmlScreenNode.Name.ToLower() == "screen")
			{
				IdeasScadaScreen screenToAdd = new IdeasScadaScreen();		
				
				string nodeName = xmlScreenNode.Attributes["name"].Value;
				string nodePath = screenToAdd.FilePath = xmlScreenNode.Attributes["path"].Value;
				string nodeStringType = screenToAdd.Name = xmlScreenNode.Attributes["type"].Value;
				string nodeStringServerScriptLanguage = screenToAdd.Name = xmlScreenNode.Attributes["serverscriptlanguage"].Value;
				string nodeStringClientScriptLanguage = screenToAdd.Name = xmlScreenNode.Attributes["clientscriptlanguage"].Value;
				
				IdeasScadaScreenType nodeType = IdeasScadaScreen.convertScreenTypeFromString(nodeStringType);
				IdeasScadaScreenServerScriptLanguage nodeServerScriptLanguage = IdeasScadaScreen.convertScreenServerScriptLanguageFromString(nodeStringServerScriptLanguage);
				IdeasScadaScreenClientScriptLanguage nodeClientScriptLanguage = IdeasScadaScreen.convertScreenClientScriptLanguageFromString(nodeStringClientScriptLanguage);
				
				screenToAdd.Name = nodeName;
				screenToAdd.FilePath = nodePath;
				screenToAdd.Type = nodeType;
				screenToAdd.ServerScriptLanguage = nodeServerScriptLanguage;
				screenToAdd.ClientScriptLanguage = nodeClientScriptLanguage;
				
				project.Screens.Add(screenToAdd);
			}
		}
		
		/// <summary>
		/// Load the Tags Database configuration if it is a correspondant Xml node
		/// </summary>
		/// <param name="xmlProjectNode">
		/// A <see cref="XmlNode"/>
		/// </param>
		private void LoadProjectTagsDatabase(XmlNode xmlTagsDatabasetNode, IdeasScadaProject project)
		{
			if(xmlTagsDatabasetNode.Name.ToLower() == "tagsdatabase")
			{
				IdeasScadaTagsDataBase tagsDatabaseToAdd = new IdeasScadaTagsDataBase();
				
				// TODO: tags database creation logic
				
//				string nodeName = xmlScreenNode.Attributes["name"].Value;
//				string nodePath = screenToAdd.FilePath = xmlScreenNode.Attributes["path"].Value;
//				string nodeStringType = screenToAdd.Name = xmlScreenNode.Attributes["type"].Value;
//				string nodeStringServerScriptLanguage = screenToAdd.Name = xmlScreenNode.Attributes["serverscriptlanguage"].Value;
//				string nodeStringClientScriptLanguage = screenToAdd.Name = xmlScreenNode.Attributes["clientscriptlanguage"].Value;
//				
//				IdeasScadaScreenType nodeType = IdeasScadaScreen.convertScreenTypeFromString(nodeStringType);
//				IdeasScadaScreenServerScriptLanguage nodeServerScriptLanguage = IdeasScadaScreen.convertScreenServerScriptLanguageFromString(nodeStringServerScriptLanguage);
//				IdeasScadaScreenClientScriptLanguage nodeClientScriptLanguage = IdeasScadaScreen.convertScreenClientScriptLanguageFromString(nodeStringClientScriptLanguage);
//				
//				tagsDatabaseToAdd.Name = nodeName;
//				tagsDatabaseToAdd.FilePath = nodePath;
//				tagsDatabaseToAdd.Type = nodeType;
//				tagsDatabaseToAdd.ServerScriptLanguage = nodeServerScriptLanguage;
//				tagsDatabaseToAdd.ClientScriptLanguage = nodeClientScriptLanguage;
//				
//				project.Screens.Add(tagsDatabaseToAdd);
			}
		}
		
		/// <summary>
		/// Load the Tags Webservice configuration if it is a correspondant Xml node
		/// </summary>
		/// <param name="xmlProjectNode">
		/// A <see cref="XmlNode"/>
		/// </param>
		private void LoadProjectTagsWebservice(XmlNode xmlTagsWebserviceNode, IdeasScadaProject project)
		{
			if(xmlTagsWebserviceNode.Name.ToLower() == "tagswebservice")
			{
				// TODO: tags webservice creation logic					
			}
		}
			
		
		#region PROPERTIES
		
		public string RootPath 
		{
			get 
			{
				return this.rootPath;
			}
		}

		public string FilePath 
		{
			get 
			{
				return this.filePath;
			}
		}
		
		public List<IdeasScadaProject> Projects 
		{
			get 
			{
				return this.projects;
			}
		}
		
		#endregion PROPERTIES
	}
}

