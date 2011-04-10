using System;
using System.IO;
using Mono.GetOptions;

namespace Ideas.Server.Manager
{
	public class Configuration : Mono.GetOptions.Options
	{
		[Option ("SCADA Application File to open", 'f')]
		public string file;
		
		public Configuration ()
		{
			base.ParsingMode = OptionsParsingMode.Both;
		}
	}
}

