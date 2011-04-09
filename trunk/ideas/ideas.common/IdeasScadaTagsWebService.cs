using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using Mono.WebServer;
using ideas.common;
using System.Net;


namespace ideas.common
{
	public class IdeasScadaTagsWebService
	{
		private string name;
		private int serverPort;
		private string serverAddress;
		private string serverRootPath;
		private ApplicationServer webAppServer;	
		
		/// <summary>
		/// Constructs the class
		/// </summary>	
		public IdeasScadaTagsWebService ()
		{
			
		}
		
		#region PUBLIC METHODS
		
		public void Start()
		{		
			XSPWebSource websource = new XSPWebSource(IPAddress.Any, this.ServerPort);
			    
			webAppServer = new ApplicationServer(websource);
			
			//"[[hostname:]port:]VPath:realpath"
			string cmdLine = this.ServerPort + ":/:" + serverRootPath;
			webAppServer.AddApplicationsFromCommandLine(cmdLine);
			webAppServer.Start(true);
		}
		
		public void Stop()
		{
			webAppServer.Stop();
		}
		
		#endregion
		
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
		
		public string ServerRootPath 
		{
			get 
			{
				return this.serverRootPath;
			}
			set
			{
				serverRootPath = value;
			}
		}
		
		#endregion PROPERTIES
	}
	
}

