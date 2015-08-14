using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class BB4_Chuck : Einheit
    {
        public BB4_Chuck() : base(12                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Chuck    //Bild
                                , "Chuck"                //Name
                                , 0                        //playerLevel
                                , 2500                        //hitDamage
                                , 2000                        //missDamage
                                , 50                        //hitPercentage
                                , 9000                        //hitPoints
                                , 250                         //xpForDefeat 
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
