using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using Ideas.Common.Tags;


namespace Ideas.Common
{
	public class Project
	{
		private string name;
		private string filePath;
		
		List<Screen> screens = new List<Screen>();
		
		DataBase tagsDatabase;
		WebService tagsWebService;
		
		/// <summary>
		/// Constructs the class from the Xml Scada file
		/// </summary>
		public Project ()
		{
			
		}
				
		#region PROPERTIES
		
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

		public string FilePath 
		{
			get 
			{
				return this.filePath;
			}
			set
			{
				filePath = value;
			}
		}
		
		public List<Screen> Screens 
		{
			get 
			{
				return this.screens;
			}
			set 
			{
				screens = value;
			}
		}
		
		public DataBase TagsDatabase 
		{
			get 
			{
				return this.tagsDatabase;
			}
			set 
			{
				tagsDatabase = value;
			}
		}

		public WebService TagsWebService 
		{
			get 
			{
				return this.tagsWebService;
			}
			set 
			{
				tagsWebService = value;
			}
		}
		
		#endregion PROPERTIES
	}
}

