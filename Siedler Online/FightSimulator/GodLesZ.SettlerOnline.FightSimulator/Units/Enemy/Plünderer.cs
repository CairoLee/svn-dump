using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Plünderer : Einheit
    {
        public Plünderer() : base(14                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Pluenderer    //Bild
                                , "Plünderer"                //Name
                                , 12                        //playerLevel
                                , 30                        //hitDamage
                                , 15                        //missDamage
                                , 60                        //hitPercentage
                                , 40                        //hitPoints
                                , 2                         //xpForDefeat 
                                , false                      //produceable
                                , 180                       //productionTimeSeconds
                                , Rohstoffkosten()
                                , Fähigkeit()) { }

        private static Skills Fähigkeit()
        {
            Skills s = new Skills();
            return s;
        }

        private static Rohstoffe Rohstoffkosten()
        {
            Rohstoffe r = new Rohstoffe(); 
            return r;
        }
    }
}
