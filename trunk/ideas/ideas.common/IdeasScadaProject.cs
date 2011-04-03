using System;
using System.Xml;
using System.IO;
using ideas.common;
using System.Collections.Generic;

namespace ideas.common
{
	public class IdeasScadaProject
	{
		private string name;
		private string filePath;
		
		List<IdeasScadaScreen> screens = new List<IdeasScadaScreen>();
		
		IdeasScadaTagsDataBase tagsDatabase;
		IdeasScadaTagsWebService tagsWebService;
		
		/// <summary>
		/// Constructs the class from the Xml Scada file
		/// </summary>
		public IdeasScadaProject ()
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
		
		public List<IdeasScadaScreen> Screens 
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
		
		public IdeasScadaTagsDataBase TagsDatabase 
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

		public IdeasScadaTagsWebService TagsWebService 
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

