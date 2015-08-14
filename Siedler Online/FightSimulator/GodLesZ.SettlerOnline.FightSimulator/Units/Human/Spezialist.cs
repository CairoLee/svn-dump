using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class Spezialist : Einheit
    {
        public Spezialist(): base(900,null
                                , "Spezialist"                //Name
                                , 25                        //playerLevel
                                , 5                        //hitDamage
                                , 1                        //missDamage
                                , 80                        //hitPercentage
                                , 1                        //hitPoints
                                , 0                        //xpForDefeat
                                , false                      //produceable
                                , 0                      //productionTimeSeconds
                                , Rohstoffkosten()
                                , Fähigkeit()) { }

        private static Skills Fähigkeit()
        {
            Skills s = new Skills();
            s.Skill8 = true;
            return s;
        }

        private static Rohstoffe Rohstoffkosten()
        {
            Rohstoffe r = new Rohstoffe();
            return r;
        }
    }
}
