using System.Windows.Forms;

namespace GrfEditor.Library.Controls {

	public interface IPreviewPanelHost {
		Panel GetPreviewHost();
		void OnPreviewReady();
	}

}
