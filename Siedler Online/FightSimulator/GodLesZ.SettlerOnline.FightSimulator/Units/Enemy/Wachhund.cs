using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Wachhund : Einheit
    {
        public Wachhund() : base(16                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Wachhund    //Bild
                                , "Wachhunde"                //Name
                                , 20                        //playerLevel
                                , 10                        //hitDamage
                                , 5                        //missDamage
                                , 60                        //hitPercentage
                                , 5                        //hitPoints
                                , 2                         //xpForDefeat 
                                , false                      //produceable
                                , 1800                       //productionTimeSeconds
                                , Rohstoffkosten()
                                , Fähigkeit()) { }

        private static Skills Fähigkeit()
        {
            Skills s = new Skills();
            s.Skill5 = true; //First Strike
            s.Skill2 = true; //Attacks weakest unit first
            return s;
        }

        private static Rohstoffe Rohstoffkosten()
        {
            Rohstoffe r = new Rohstoffe();          
            return r;
        }
    }
}
