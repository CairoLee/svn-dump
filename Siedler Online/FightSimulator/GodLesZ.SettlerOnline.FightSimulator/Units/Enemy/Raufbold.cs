using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Raufbold : Einheit
    {
        public Raufbold() : base(17                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Raufbold    //Bild
                                , "Raufbolde"                //Name
                                , 25                        //playerLevel
                                , 40                        //hitDamage
                                , 20                        //missDamage
                                , 60                        //hitPercentage
                                , 90                        //hitPoints
                                , 4                         //xpForDefeat 
                                , false                      //produceable
                                , 960                       //productionTimeSeconds
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
