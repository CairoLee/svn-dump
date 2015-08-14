using System.Collections.Generic;
using TowerInterface;

namespace BaseTower
{
    public class Upgrade:IUpgrade
    {
        public string Name { get; private set; }
        public string Key { get; private set; }
        public string Type { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public float Value { get; private set; }
        public List<string> Requirements { get; private set; }

        public Upgrade(string name, string key, string type, string description, float amount, int price, List<string> requirements)
        {
            Name = name;
            Key = key;
            Type = type;
            Description = description;
            Value = amount;
            Price = price;
            Requirements = requirements;
        }
    }
}
