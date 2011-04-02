using System;
using System.Xml;
using System.IO;
using ideas.common;
using System.Collections.Generic;

namespace ideas.common
{
	public class IdeasScadaTagsWebService
	{
		private string name;
		private string filePath;
		private int serverPort;
		private string serverAddress;
		
		/// <summary>
		/// Constructs the class
		/// </summary>	
		public IdeasScadaTagsWebService ()
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
		
		public int ServerPort 
		{
			get 
			{
				return this.serverPort;
			}
			set
			{
				this.serverPort = value;
			}
		}

		public string ServerAddress
		{
			get 
			{
				return this.serverAddress;
			}
			set
			{
				this.serverAddress = value;
			}
		}
		
		#endregion PROPERTIES
	}
	
}

