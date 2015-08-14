using System.IO;

namespace GodLesZ.Library.Ragnarok {

	public interface IFileFormat {

		bool Read();
		bool Read(string filepath);
		bool Read(Stream stream);
		bool Write(string filepath, bool oerwrite);
		void Flush();

	}

}
