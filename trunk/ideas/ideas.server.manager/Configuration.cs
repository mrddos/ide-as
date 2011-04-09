using System;
using System.IO;
using Mono.GetOptions;

namespace ideas.server.manager
{
	public class Configuration : Mono.GetOptions.Options
	{
		[Option ("SCADA Application to open", 'f')]
		public string file;
		
		public Configuration ()
		{
			base.ParsingMode = OptionsParsingMode.Both;
		}
	}
}

