using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class BB2_Einäugiger_Bert : Einheit
    {
        public BB2_Einäugiger_Bert() : base(21                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Bert    //Bild
                                , "Einäugiger Bert"                //Name
                                , 0                        //playerLevel
                                , 500                        //hitDamage
                                , 300                        //missDamage
                                , 50                        //hitPercentage
                                , 6000                        //hitPoints
                                , 100                         //xpForDefeat 
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
