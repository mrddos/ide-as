using System;
using Gtk;
namespace ideas.common
{
	public static class util
	{
	
		/// <summary>
		/// Shows a regular message dialog with custom text
		/// </summary>
		/// <param name="textString">
		/// A <see cref="System.String"/>
		/// </param>
		public static void ShowErrorMessageDialog(string textString)
		{
			MessageDialog msgDialog = 
					new MessageDialog(
					    null, 
						DialogFlags.Modal,
						MessageType.Error,
						ButtonsType.Ok,
						textString);
				
				msgDialog.Run();
				msgDialog.Destroy();		
		}
	}
}

