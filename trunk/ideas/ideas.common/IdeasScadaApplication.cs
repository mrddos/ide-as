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
		string name;
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
			
				this.name = nodesList[0].Attributes["name"].Value;
				
				// Saves the path to the Scada file
				this.filePath = scadafile;
				
				// Saves the root path
				this.rootPath = Path.GetDirectoryName(scadafile);
				
				// Verifies if there is only one Application settings for the file
				if(nodesList.Count > 1)
				{
					throw new Exception("This file has more than one Application settings. Please make sure that there is only one Application settings for each file.");
				}
								
				// Loads application settings
				LoadProjectSettings(xmlScadaFile);
							

			}
			catch(Exception e)
			{
				throw new Exception("The configuration file is invalid or corrupted. " + e.Message);
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
				projectToAdd.FilePath = this.RootPath + "/" + nodePath;
				
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
				string nodePath = xmlScreenNode.Attributes["path"].Value;
				string nodeStringType = xmlScreenNode.Attributes["type"].Value;
				string nodeStringServerScriptLanguage = xmlScreenNode.Attributes["serverscriptlanguage"].Value;
				string nodeStringClientScriptLanguage = xmlScreenNode.Attributes["clientscriptlanguage"].Value;
				
				IdeasScadaScreenType nodeType = IdeasScadaScreen.convertScreenTypeFromString(nodeStringType);
				IdeasScadaScreenServerScriptLanguage nodeServerScriptLanguage = IdeasScadaScreen.convertScreenServerScriptLanguageFromString(nodeStringServerScriptLanguage);
				IdeasScadaScreenClientScriptLanguage nodeClientScriptLanguage = IdeasScadaScreen.convertScreenClientScriptLanguageFromString(nodeStringClientScriptLanguage);
				
				screenToAdd.Name = nodeName;
				screenToAdd.FilePath = this.FilePath + nodePath;
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
				// Instantiate a new tag database to be added to the project
				IdeasScadaTagsDataBase tagsDatabaseToAdd = new IdeasScadaTagsDataBase();
				
				string nodeName = xmlTagsDatabasetNode.Attributes["name"].Value;
				string nodePath = xmlTagsDatabasetNode.Attributes["path"].Value;
				string nodeStringSourceType = xmlTagsDatabasetNode.Attributes["type"].Value;
				
				IdeasScadaTagsDataBaseSourceType nodeSourceType = IdeasScadaTagsDataBase.convertSourceTypeFromString(nodeStringSourceType);
				
				tagsDatabaseToAdd.Name = nodeName;
				tagsDatabaseToAdd.FilePath = project.FilePath + nodePath;
				tagsDatabaseToAdd.SourceType = nodeSourceType;
				
				project.TagsDatabase = tagsDatabaseToAdd;
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
				// Instantiate a new tag database to be added to the project
				IdeasScadaTagsWebService tagsWebserviceToAdd = new IdeasScadaTagsWebService();
				
				string nodeName = xmlTagsWebserviceNode.Attributes["name"].Value;
				string nodeServerPort = xmlTagsWebserviceNode.Attributes["port"].Value;
				string nodeServerAddress = xmlTagsWebserviceNode.Attributes["address"].Value;
						
				tagsWebserviceToAdd.Name = nodeName;
				tagsWebserviceToAdd.ServerPort = Convert.ToInt32(nodeServerPort);
				tagsWebserviceToAdd.ServerAddress = nodeServerAddress;
				tagsWebserviceToAdd.ServerRootPath = project.FilePath + "screens/";
				
				project.TagsWebService = tagsWebserviceToAdd;
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
		
		public string Name 
		{
			get 
			{
				return this.name;
			}
			set 
			{
				name = value;
			}
		}
		
		#endregion PROPERTIES
	}
}

