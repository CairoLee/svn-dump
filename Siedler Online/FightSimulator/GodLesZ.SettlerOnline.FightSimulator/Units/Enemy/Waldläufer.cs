using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Waldläufer : Einheit
    {
        public Waldläufer() : base( 19                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Waldleaufer    //Bild
                                , "Waldläufer"                //Name
                                , 12                        //playerLevel
                                , 60                        //hitDamage
                                , 30                        //missDamage
                                , 60                        //hitPercentage
                                , 10                        //hitPoints
                                , 3                         //xpForDefeat 
                                , false                      //produceable
                                , 480                       //productionTimeSeconds
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
