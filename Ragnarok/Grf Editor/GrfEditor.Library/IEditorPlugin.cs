using System.Windows.Forms;

namespace GrfEditor.Library {

	public interface IEditorPlugin {
		string GetPluginName();
		string GetPluginDescription();

		void LoadPlugin(Form form);
		void LoadMenu(ToolStripMenuItem item);
		void UnloadPlugin();
	}

}
