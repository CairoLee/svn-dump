using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class BB3_Metallgebiss : Einheit
    {
        public BB3_Metallgebiss() : base( 13                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.MG    //Bild
                                , "Metallgebiss"                //Name
                                , 12                        //playerLevel
                                , 500                        //hitDamage
                                , 250                        //missDamage
                                , 50                        //hitPercentage
                                , 11000                        //hitPoints
                                , 160                        //xpForDefeat 
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
