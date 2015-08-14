using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Schläger : Einheit
    {
        public Schläger() : base( 15                           //sequencePrio
                                ,GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Schlaeger    //Bild
                                , "Schläger"                //Name
                                , 12                        //playerLevel
                                , 40                        //hitDamage
                                , 20                        //missDamage
                                , 60                        //hitPercentage
                                , 60                        //hitPoints
                                , 2                         //xpForDefeat 
                                , false                      //produceable
                                , 480                       //productionTimeSeconds
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
            r.Population = 1;
            r.BronzeSword = 10;
            r.Beer = 5;
            return r;
        }
    }
}
