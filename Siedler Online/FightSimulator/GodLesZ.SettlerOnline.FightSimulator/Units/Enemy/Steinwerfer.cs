using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Steinwerfer : Einheit
    {
        public Steinwerfer(): base(18                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Steinwerfer    //Bild
                                , "Steinwerfer"                //Name
                                , 16                        //playerLevel
                                , 40                        //hitDamage
                                , 20                        //missDamage
                                , 60                        //hitPercentage
                                , 10                        //hitPoints
                                , 3                         //xpForDefeat 
                                , false                      //produceable
                                , 240                       //productionTimeSeconds
                                , Rohstoffkosten()
                                , Fähigkeit()) { }

        private static Skills Fähigkeit()
        {
            Skills s = new Skills();
            s.Skill4 = true; //Bonus Tower Armor
            return s;
        }

        private static Rohstoffe Rohstoffkosten()
        {
            Rohstoffe r = new Rohstoffe();          
            return r;
        }
    }
}
