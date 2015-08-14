using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen
{
    class KampfSimulatorAuswertung
    {
        ArrayList simulationen;
        string bericht;
        ArrayList a;
        ArrayList atode;
        ArrayList d;
        ArrayList dtode;

        public string Bericht
        {
            get { return bericht; }
        }

        public KampfSimulatorAuswertung(ArrayList Kampfsimulationen)
        {
            simulationen = Kampfsimulationen;           
            
            a = new ArrayList();
            atode = new ArrayList();
            d = new ArrayList();
            dtode = new ArrayList();

            foreach (ArrayList sim in simulationen)
            {
                zähleEinheiten((ArrayList)sim[0], a);
                zähleEinheiten((ArrayList)sim[1], d);
                zähleEinheiten((ArrayList)sim[2], atode);
                zähleEinheiten((ArrayList)sim[3], dtode);
            }
            Auswertung();          
        }

        private void Auswertung()
        {
            bericht += "<div id=container1>";
            bericht += "<h1>Simulationen: " + simulationen.Count.ToString() + "</h1>";

            bericht += "<div id=container2>";
            //Angreifer - Überlebende
            bericht += "<div class=\"left\" style=\"width:399px\">";
            bericht += "<h2>Überlebende des Angreifer</h2>";
            if (a.Count > 0)            
                foreach (EinheitenZähler item in a) bericht += "<p>" + (Convert.ToDouble(item.Counter) / Convert.ToDouble(simulationen.Count)).ToString("0.00") + " " + item.Einheit.Typ + "</p>";                
            else bericht += "<p>&nbsp;</p>";
            bericht += "</div>";

            //Angreifer - Tode
            bericht += "<div class=\"right\" style=\"width:399px\">";
            bericht += "<h2>Tode des Angreifer</h2>";
            if (atode.Count > 0)
                foreach (EinheitenZähler item in atode)
                    bericht += "<p>" + (Convert.ToDouble(item.Counter) / Convert.ToDouble(simulationen.Count)).ToString("0.00") + " " + item.Einheit.Typ + "</p>";
            else bericht += "<p>&nbsp;</p>";
            bericht += "</div>";
            bericht += "<div style=\"clear:both\">&nbsp;</div>";
            bericht += "</div>";

            bericht += "<div id=container2>";
            //Verteidiger - Überlebende
            bericht += "<div class=\"left\" style=\"width:399px\">";
            bericht += "<h2>Überlebende Verteidiger</h2>";
            if (d.Count > 0)
                foreach (EinheitenZähler item in d)
                    bericht += "<p>" + (item.Counter / simulationen.Count).ToString("0.00") + " " + item.Einheit.Typ + "</p>";
            else bericht += "<p>&nbsp;</p>";    
            bericht += "</div>";

            //Verteidiger - Tode
            bericht += "<div class=\"right\" style=\"width:399px\">";
            bericht += "<h2>Tode des Verteidiger</h2>";
            if (dtode.Count > 0)
                foreach (EinheitenZähler item in dtode)
                    bericht += "<p>" + (item.Counter / simulationen.Count).ToString("0.00") + " " + item.Einheit.Typ + "</p>";
            else bericht += "<p>&nbsp;</p>";    
            bericht += "</div>";
            bericht += "<div style=\"clear:both\">&nbsp;</div>";
            bericht += "</div>";

            bericht += "</div>";
        }

        private void zähleEinheiten(ArrayList arrayList, ArrayList a)
        {          
            EinheitenZähler cnt;
            
            foreach (Einheit e in arrayList)
            {
                if (a.Count > 0)
                {
                    bool found = false;
                    foreach (EinheitenZähler item in a)
                    {
                        if (item.Einheit.Typ == e.Typ)
                        {
                            item.Counter++;
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        cnt = new EinheitenZähler();
                        cnt.Counter = 1;
                        cnt.Einheit = e;
                        a.Add(cnt);
                    }
                }
                else
                {
                    cnt = new EinheitenZähler();
                    cnt.Counter = 1;
                    cnt.Einheit = e;
                    a.Add(cnt);
                }
            }
        }

      
    }

    class EinheitenZähler
    {
        int counter;
        Einheit e;

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public Einheit Einheit
        {
            get { return e; }
            set { e = value; }
        }

        public EinheitenZähler()
        {
            counter = 0;
        }
    }
}
