using System;
using System.Xml;
using System.IO;
using ideas.common;
using System.Collections.Generic;

namespace ideas.common
{
	public class IdeasScadaTagsDataBase
	{
		private string name;
		private string filePath;
		
		/// <summary>
		/// Constructs the class
		/// </summary>	
		public IdeasScadaTagsDataBase ()
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
				this.name = value;
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
				this.filePath = value;
			}
		}
		
		
		
		#endregion PROPERTIES
	}
	
	enum IdeasScadaTagsDataBaseSourceType
	{
		CSV
	}
	
}

