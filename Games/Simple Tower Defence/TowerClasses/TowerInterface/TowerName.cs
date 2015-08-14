using System;

namespace TowerInterface
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class TowerKey : Attribute
    {
        public TowerKey(string key, string name, bool isTower)
        {
            Key = key;
            Name = name;
            IsTower = isTower;
        }

        public TowerKey()
        {
            IsTower = false;
            Key = "";
        }

        public string Key { get; set; }
        public bool IsTower { get; set; }
        public string Name { get; set; }
    }
}