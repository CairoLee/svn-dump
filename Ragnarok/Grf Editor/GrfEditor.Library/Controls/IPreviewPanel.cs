
namespace GrfEditor.Library.Controls {

	public interface IPreviewPanel {
		void SetData(byte[] data, string filename);
		bool IsSupported(string extension);
		bool BlockListView();
	}

}
