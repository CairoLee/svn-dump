using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

using TRead = FinalSoftware.Games.Defender.Library.DefenderMap;

namespace FinalSoftware.Games.Defender.ContentPipeline {

	public class DefenderMapReader : ContentTypeReader<TRead> {
		protected override TRead Read( ContentReader input, TRead existingInstance ) {
			TRead map;
			XmlSerializer xml = new XmlSerializer( typeof( TRead ) );
			map = (TRead)xml.Deserialize( input.BaseStream );

			return map;
		}
	}

}
