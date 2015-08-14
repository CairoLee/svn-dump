using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class BB1_Stinktier : Einheit
    {
        public BB1_Stinktier() : base( 20                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Stinktier    //Bild
                                , "Stinktier"                //Name
                                , 12                        //playerLevel
                                , 100                        //hitDamage
                                , 1                        //missDamage
                                , 50                        //hitPercentage
                                , 5000                        //hitPoints
                                , 200                         //xpForDefeat 
                                , false                      //produceable
                                , 0                       //productionTimeSeconds
                                , Rohstoffkosten()
                                , Fähigkeit()) { }

        private static Skills Fähigkeit()
        {
            Skills s = new Skills();
            s.Skill6 = true; //Last Strike
            s.Skill3 = true; //Splash Damage
            return s;
        }

        private static Rohstoffe Rohstoffkosten()
        {
            Rohstoffe r = new Rohstoffe();          
            return r;
        }
    }
}
