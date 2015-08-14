namespace FreeWorld.Engine.PipelineExtension.Map {

	/// <summary>
	/// Data returned from the Importer
	/// </summary>
	public class TileMapImporterData {
		
		public byte[] Data {
			get;
			protected set;
		}


		public TileMapImporterData(byte[] buf) {
			Data = buf;
		}

	}

}