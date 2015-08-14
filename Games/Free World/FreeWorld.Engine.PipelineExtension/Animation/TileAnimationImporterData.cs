namespace FreeWorld.Engine.PipelineExtension.Animation {

	/// <summary>
	/// Data returned from the Importer
	/// </summary>
	public class TileAnimationImporterData {
		
		public byte[] Data {
			get;
			protected set;
		}


		public TileAnimationImporterData(byte[] buf) {
			Data = buf;
		}
	}

}