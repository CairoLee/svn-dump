using System.Collections.Generic;

namespace LevelEditor
{
    class Wave
    {
        public List<Creep> Creeps { get; set;}
        public int WaitTime { get; set; }

        public Wave(List<Creep> creeps,int wt)
        {
            Creeps = creeps;
            WaitTime = wt;
        }
    }

    class Creep
    {
        public int Health { get; set; }
        public string Texture { get; set; }
        public float Speed { get; set; }

        public Creep(int health, float speed, string texture)
        {
            Health = health;
            Speed = speed;
            Texture = texture;
        }
    }
}
