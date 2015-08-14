using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Settings {

	public class TerrainSettings {

		[System.Xml.Serialization.XmlRootAttribute( "terrainsettings", IsNullable = false )]
		public class Variables {

			[System.Xml.Serialization.XmlArray( "terrains" )]
			[System.Xml.Serialization.XmlArrayItem( "terrain", typeof( Terrain ) )]
			public List<Terrain> m_terrains;

		}

		public Variables m_variables = new Variables();

		private Serializer m_Synchronizer = new Serializer();

		public void Load( System.IO.Stream stream ) {
			Type type = m_variables.GetType();
			this.m_variables = (Variables)this.m_Synchronizer.Load( stream, type );
		}

		public void Load( string path ) {
			Type type = m_variables.GetType();
			this.m_variables = (Variables)this.m_Synchronizer.Load( path, type );
		}

		public void Save( System.IO.Stream stream ) {

			this.m_Synchronizer.Save( stream, this.m_variables );
		}

		public void Save( string path ) {

			this.m_Synchronizer.Save( path, this.m_variables );
		}

	}

	[Serializable()]
	public class Terrain {

		[System.Xml.Serialization.XmlAttribute( "id" )]
		public int m_id;

		[System.Xml.Serialization.XmlArray( "layers" )]
		[System.Xml.Serialization.XmlArrayItem( "layer", typeof( Layer ) )]
		public List<Layer> m_layers;

		[System.Xml.Serialization.XmlElement( "skybox" )]
		public SkyBox m_skybox;

		[System.Xml.Serialization.XmlElement( "heightmap" )]
		public HeightMap m_heightmap;

		[System.Xml.Serialization.XmlElement( "sun" )]
		public Sun m_sun;

		[System.Xml.Serialization.XmlElement( "fog" )]
		public Fog m_fog;

	}

	[Serializable()]
	public class Sun {

		[System.Xml.Serialization.XmlElement( "enabled" )]
		public bool m_enabled;

		[System.Xml.Serialization.XmlElement( "color" )]
		public SplitColor m_color;

		[System.Xml.Serialization.XmlElement( "angle" )]
		public double m_angle;

		[System.Xml.Serialization.XmlElement( "elevation" )]
		public double m_elevation;

		[System.Xml.Serialization.XmlElement( "longitudespeed" )]
		public double m_longitudespeed;

		[System.Xml.Serialization.XmlElement( "latitudespeed" )]
		public double m_latitudespeed;

		[System.Xml.Serialization.XmlElement( "intensity" )]
		public double m_intensity;

		[System.Xml.Serialization.XmlElement( "raycollision" )]
		public bool m_raycollision;

	}

	[Serializable()]
	public class Fog {

		[System.Xml.Serialization.XmlElement( "enabled" )]
		public bool m_enabled;

		[System.Xml.Serialization.XmlElement( "color" )]
		public SplitColor m_color;

		[System.Xml.Serialization.XmlElement( "start" )]
		public float m_start;

		[System.Xml.Serialization.XmlElement( "end" )]
		public float m_end;

		[System.Xml.Serialization.XmlElement( "density" )]
		public float m_density;

	}

	[Serializable()]
	public class SplitColor {

		[System.Xml.Serialization.XmlElement( "red" )]
		public float m_red;

		[System.Xml.Serialization.XmlElement( "green" )]
		public float m_green;

		[System.Xml.Serialization.XmlElement( "blue" )]
		public float m_blue;

	}

	[Serializable()]
	public class HeightMap {

		[System.Xml.Serialization.XmlElement( "heightmaptexture" )]
		public string m_heightmaptexture;

		[System.Xml.Serialization.XmlElement( "colormaptexture" )]
		public string m_colormaptexture;

		[System.Xml.Serialization.XmlElement( "cellsize" )]
		public Microsoft.Xna.Framework.Point m_cellsize;

		[System.Xml.Serialization.XmlElement( "maxheight" )]
		public float m_maxheight;

		[System.Xml.Serialization.XmlElement( "smooth" )]
		public bool m_smooth;

		[System.Xml.Serialization.XmlElement( "drawdetail" )]
		public bool m_drawdetail;

		[System.Xml.Serialization.XmlElement( "ambientlight" )]
		public SplitColor m_ambientlight;

	}

	[Serializable()]
	public class SkyBox {

		[System.Xml.Serialization.XmlElement( "enabled" )]
		public bool m_enabled;

		[System.Xml.Serialization.XmlElement( "texture" )]
		public string m_texture;

	}

	[Serializable()]
	public class Layer {

		[System.Xml.Serialization.XmlElement( "texture" )]
		public string m_texture;

		[System.Xml.Serialization.XmlElement( "scale" )]
		public float m_scale;

	}
}