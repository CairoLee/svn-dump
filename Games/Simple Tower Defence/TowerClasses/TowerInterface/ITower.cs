using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TowerInterface
{
    //Dieses Interface dient zur Kommunikation zwischen den eigentlichen Tower-Dlls und dem Spiel.
    //Das Spiel darf die BaseTower-Klasse ja nicht kennen, da es sonst zu Referenzierungsproblemen kommen würde.
    //So können beide einfach auf ITower verweisen und gut ist.
    public interface ITower
    {
        float Price { get; }
        float Range { get; }
        float Damage { get; }
        float Interval { get; }
        string Description { get; }
        string Name { get; set; }
        string Key { get; set; }

        Vector2 PathPosition { get; }
        Vector2 Position { get; }

        Vector2 PathSize { get; }
        Vector2 Size { get; }

        Dictionary<string, IUpgrade> PossibleUpgrades { get; }
        Dictionary<string, PropertyChanger.Get> GetProperties { get; }
        List<IShowableProperty> CustomProperties { get; }

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Initialize();
        void Sell();
        bool BuyUpgrade(string name);
    }

    public class PropertyChanger
    {
        public delegate double Get();
        public delegate void Set(double amount);
    }
}