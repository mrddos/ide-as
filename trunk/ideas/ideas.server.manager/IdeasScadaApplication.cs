using System;
using System.Xml;
using System.IO;
using ideas.common;

namespace ideas.server.manager
{
	public class IdeasScadaApplication
	{
		string pathRoot;
		string pathScadaFile;
		
		
		/// <summary>
		/// Constructs the class from the xml Scada file
		/// </summary>
		/// <param name="scadafile">
		/// A <see cref="System.String"/>
		/// </param>
		public IdeasScadaApplication (string scadafile)
		{
			try
			{
				XmlTextReader reader = new XmlTextReader(scadafile);
				
				while(reader.Read())
				{
					switch(reader.NodeType)
					{
						case XmlNodeType.Element:
							//reader.HasAttributes
							break;
						case XmlNodeType.Attribute:
							break;
						
					}
				}
				
				// Saves the path to the Scada file
				pathRoot = scadafile;
				
				// Saves the root path
				pathScadaFile = Path.GetDirectoryName(scadafile);
				
			}
			catch(Exception e)
			{
				util.ShowErrorMessageDialog("The configuration file is invalid or corrupted. " + e.Message);
			}
			
		}
		
		#region PROPERTIES
		
		public string PathRoot 
		{
			get 
			{
				return this.pathRoot;
			}
		}

		public string PathScadaFile 
		{
			get 
			{
				return this.pathScadaFile;
			}
		}
		
		#endregion PROPERTIES
	}
}

