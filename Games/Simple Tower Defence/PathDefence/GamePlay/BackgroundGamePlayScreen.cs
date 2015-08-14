using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using XNASimpleTemplates;

namespace PathDefence.GamePlay
{
    public class BackgroundGamePlayScreen : GameComponentBase<PathDefenceGame>
    {
        private readonly string MapFile;

        public BackgroundGamePlayScreen(Game game, string mapName) : base(game)
        {
            MapFile = mapName;
        }

        public override void Initialize()
        {
            string tmpPath = "Content/Map/" + MapFile + ".xml";
	        var xml = XDocument.Load(tmpPath);
            var levelNode = xml.Root.Element("Level");

			string mapName = levelNode.Attribute("Texture").Value;
            TextureDirectory = "Map/";
            TextureName = mapName;
            Position = Vector2.Zero;
            Size = new Vector2(CurrGame.CreepFieldWidth, CurrGame.CreepFieldHeight);
            SpriteBatch = CurrGame.SpriteBatch;
            OriginType = OriginType.TopLeft;

            base.Initialize();
        }
    }
}