
// This file has been generated by the GUI designer. Do not modify.
namespace Stetic
{
	internal class Gui
	{
		private static bool initialized;

		internal static void Initialize (Gtk.Widget iconRenderer)
		{
			if ((Stetic.Gui.initialized == false)) {
				Stetic.Gui.initialized = true;
				global::Gtk.IconFactory w1 = new global::Gtk.IconFactory ();
				global::Gtk.IconSet w2 = new global::Gtk.IconSet (new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./Resources/Icons/Interface/16/scada.png")));
				w1.Add ("scada", w2);
				global::Gtk.IconSet w3 = new global::Gtk.IconSet (new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./Resources/Icons/Interface/16/webservice.png")));
				w1.Add ("tagswebservice", w3);
				global::Gtk.IconSet w4 = new global::Gtk.IconSet (new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./Resources/Icons/Interface/16/database.png")));
				w1.Add ("tagsdatabase", w4);
				global::Gtk.IconSet w5 = new global::Gtk.IconSet (new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./Resources/Icons/Interface/16/folder.png")));
				w1.Add ("folder", w5);
				global::Gtk.IconSet w6 = new global::Gtk.IconSet (new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./Resources/Icons/Interface/16/screen.png")));
				w1.Add ("screen", w6);
				w1.AddDefault ();
			}
		}
	}

	internal class BinContainer
	{
		private Gtk.Widget child;
		private Gtk.UIManager uimanager;

		public static BinContainer Attach (Gtk.Bin bin)
		{
			BinContainer bc = new BinContainer ();
			bin.SizeRequested += new Gtk.SizeRequestedHandler (bc.OnSizeRequested);
			bin.SizeAllocated += new Gtk.SizeAllocatedHandler (bc.OnSizeAllocated);
			bin.Added += new Gtk.AddedHandler (bc.OnAdded);
			return bc;
		}

		private void OnSizeRequested (object sender, Gtk.SizeRequestedArgs args)
		{
			if ((this.child != null)) {
				args.Requisition = this.child.SizeRequest ();
			}
		}

		private void OnSizeAllocated (object sender, Gtk.SizeAllocatedArgs args)
		{
			if ((this.child != null)) {
				this.child.Allocation = args.Allocation;
			}
		}

		private void OnAdded (object sender, Gtk.AddedArgs args)
		{
			this.child = args.Widget;
		}

		public void SetUiManager (Gtk.UIManager uim)
		{
			this.uimanager = uim;
			this.child.Realized += new System.EventHandler (this.OnRealized);
		}

		private void OnRealized (object sender, System.EventArgs args)
		{
			if ((this.uimanager != null)) {
				Gtk.Widget w;
				w = this.child.Toplevel;
				if (((w != null) 
                            && typeof(Gtk.Window).IsInstanceOfType (w))) {
					((Gtk.Window)(w)).AddAccelGroup (this.uimanager.AccelGroup);
					this.uimanager = null;
				}
			}
		}
	}

	internal class ActionGroups
	{
		public static Gtk.ActionGroup GetActionGroup (System.Type type)
		{
			return Stetic.ActionGroups.GetActionGroup (type.FullName);
		}

		public static Gtk.ActionGroup GetActionGroup (string name)
		{
			return null;
		}
	}
}