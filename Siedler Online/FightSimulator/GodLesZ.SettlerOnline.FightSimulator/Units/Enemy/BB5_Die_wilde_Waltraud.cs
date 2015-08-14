using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class BB5_Die_wilde_Waltraud : Einheit
    {
        public BB5_Die_wilde_Waltraud() : base(11                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.DwW    //Bild
                                , "Die wilde Waltraud"                //Name
                                , 0                        //playerLevel
                                , 800                        //hitDamage
                                , 740                        //missDamage
                                , 50                        //hitPercentage
                                , 60000                        //hitPoints
                                , 430                         //xpForDefeat 
                                , false                      //produceable
                                , 0                       //productionTimeSeconds
                                , Rohstoffkosten()
                                , Fähigkeit()) { }

        private static Skills Fähigkeit()
        {
            Skills s = new Skills();
            s.Skill5 = true; //First Strike
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
