using System;
using System.Collections;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen {
	class KampfSimulation {
		string kampbericht;
		string angreifername;
		string verteidigername;
		ArrayList angreifer1;
		ArrayList angreifer2;
		ArrayList angreifer3;
		ArrayList verteidiger;
		ArrayList todeVomAngreiferGesamt;
		ArrayList todeVomVerteidigerrGesamt;

		ArrayList schlachtEnde;

		bool kb;

		int ExpAngreifer;
		int ExpVerteidiger;
		bool turm;
		Random rdm;

		public string Bericht {
			get { return kampbericht; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Angreifer"></param>
		/// <param name="Verteidiger"></param>
		public ArrayList KapmfSimulation(ArrayList Angreifer1, ArrayList Angreifer2, ArrayList Angreifer3, ArrayList Verteidiger, bool Turm, string AngreiferName, string VerteidigerName, bool Kampfbericht) {
			kb = Kampfbericht;
			schlachtEnde = new ArrayList();

			rdm = new Random();
			angreifer1 = Angreifer1;
			angreifer2 = Angreifer2;
			angreifer3 = Angreifer3;
			verteidiger = new ArrayList(Verteidiger);
			turm = Turm;
			angreifername = AngreiferName;
			verteidigername = VerteidigerName;
			ExpAngreifer = 0;
			ExpVerteidiger = 0;
			todeVomAngreiferGesamt = new ArrayList();
			todeVomVerteidigerrGesamt = new ArrayList();

			if (kb) {
				kampbericht = "";
				kampbericht += "\r\n<script type=\"text/javascript\">\r\n" +
								 "function hide(){ \r\n" +
								 "if(document.getElementById(\"details\").style.display != \"none\") {\r\n" +
								 "document.getElementById(\"details\").style.display=\"none\";\r\n" +
								 "document.getElementById(\"btnHide\").value=\"Details einblenden\";}\r\n" +
								 "else { document.getElementById(\"details\").style.display=\"\";\r\n" +
								 "document.getElementById(\"btnHide\").value=\"Details ausblenden\";}}\r\n" +
								 "</script>\r\n";

				kampbericht += "<div id=\"container1\"><div id=\"container2\"><h2>Kampfsimulation zwischen " + angreifername + " vs. " + verteidigername + " vom " + DateTime.Now.ToString() + "</h2></div>\r\n<input type=\"button\" id=\"btnHide\" onclick=\"hide()\" value=\"Details ausblenden\"></div><div id=\"details\">\r\n";

				kampbericht += "<br /><div id=\"container1\"><h1>Angriffswelle 1</h1></div>";
			}
			AngriffsWelle(angreifer1);
			schlachtEnde.Add(angreifer1);
			if (angreifer2.Count > 0) {
				setzteMaxHP();
				if (kb)
					kampbericht += "<br /><div id=\"container1\"><h1>Angriffswelle 2</h1></div>";
				AngriffsWelle(angreifer2);
				schlachtEnde.Clear();
				schlachtEnde.Add(angreifer2);
				if (angreifer3.Count > 0) {
					setzteMaxHP();
					if (kb)
						kampbericht += "<br /><div id=\"container1\"><h1>Angriffswelle 3</h1></div>";
					AngriffsWelle(angreifer3);
					schlachtEnde.Clear();
					schlachtEnde.Add(angreifer3);
				}
			}

			if (kb) {
				kampbericht += "</div>";
				kampbericht += "<br /><div id=\"container1\"><h1>Schlachtausgang</h1>\r\n";
				kampbericht += "<div id=\"container2\">";
				if (verteidiger.Count == 0)
					kampbericht += "<h2>Die Schlacht wurde gewonnen</h2>";
				else {
					kampbericht += "<h2>Die Schlacht wurde verloren</h2>";
					kampbericht += "<div><h3>" + verteidigername + " (" + verteidiger.Count.ToString() + ") (+" + ExpVerteidiger.ToString() + " Erfahrung Summe)";
					if (turm == true)
						kampbericht += " hat Turmbonus</h3>";
					else
						kampbericht += " hat keinen Turmbonus</h3>";
					schreibeArmeeübersicht(verteidiger);
					kampbericht += "</div>";
				}
				kampbericht += "</div>";

				kampbericht += "<div id=\"container2\">";
				kampbericht += "<h2>Gestorbene Einheiten gesamt</h2>";

				kampbericht += "<div style=\"float:left; width:398px\"><h3>" + angreifername + " (" + ExpAngreifer.ToString() + " Erfahrung Summe)</h3>";
				todeVomAngreiferGesamt.Sort((IComparer)new Klassen.Einheit.SortByNameClass());
				schreibeArmeeübersicht(todeVomAngreiferGesamt);
				kampbericht += "</div>";

				kampbericht += "<div style=\"float:right; width:398px\"><h3>" + verteidigername + " (" + ExpVerteidiger.ToString() + " Erfahrung Summe)";
				if (turm == true)
					kampbericht += " hat Turmbonus</h3>";
				else
					kampbericht += " hat keinen Turmbonus</h3>";
				todeVomVerteidigerrGesamt.Sort((IComparer)new Klassen.Einheit.SortByNameClass());
				schreibeArmeeübersicht(todeVomVerteidigerrGesamt);
				kampbericht += "</div>";

				kampbericht += "<div style=\"clear:both\">&nbsp;</div>";
				kampbericht += "</div></div>";


				schreibeVerlustAnRohstoffe();

				kampbericht += "<div id=\"container1\"><p>Erstellt mit dem <a href=\"http://sok.kann-helfen.de/\">Siedler-Online-Kampfsimulator</a> von Karsten Wierschin</p></div>";
				kampbericht += "\r\n<script type=\"text/javascript\">\r\nhide()</script></div>";

			}
			schlachtEnde.Add(verteidiger);
			schlachtEnde.Add(todeVomAngreiferGesamt);
			schlachtEnde.Add(todeVomVerteidigerrGesamt);
			return (schlachtEnde);
		}

		private void schreibeVerlustAnRohstoffe() {
			Rohstoffe a = new Rohstoffe();
			foreach (Einheit e in todeVomAngreiferGesamt) {
				a.Beer += e.rohstoffe.Beer;
				a.Bow += e.rohstoffe.Bow;
				a.BronzeSword += e.rohstoffe.BronzeSword;
				a.Cannon += e.rohstoffe.Cannon;
				a.Crossbow += e.rohstoffe.Crossbow;
				a.Horse += e.rohstoffe.Horse;
				a.IronSword += e.rohstoffe.IronSword;
				a.Longbow += e.rohstoffe.Longbow;
				a.Population += e.rohstoffe.Population;
				a.SteelSword += e.rohstoffe.SteelSword;
				a.TitaniumSword += e.rohstoffe.TitaniumSword;
			}

			Rohstoffe d = new Rohstoffe();
			foreach (Einheit e in todeVomVerteidigerrGesamt) {
				d.Beer += e.rohstoffe.Beer;
				d.Bow += e.rohstoffe.Bow;
				d.BronzeSword += e.rohstoffe.BronzeSword;
				d.Cannon += e.rohstoffe.Cannon;
				d.Crossbow += e.rohstoffe.Crossbow;
				d.Horse += e.rohstoffe.Horse;
				d.IronSword += e.rohstoffe.IronSword;
				d.Longbow += e.rohstoffe.Longbow;
				d.Population += e.rohstoffe.Population;
				d.SteelSword += e.rohstoffe.SteelSword;
				d.TitaniumSword += e.rohstoffe.TitaniumSword;
			}


			kampbericht += "<div id=\"container1\">";
			kampbericht += "<div id=\"container2\">";
			kampbericht += "<h2>Verlust an Rohstoffe</h2>";

			kampbericht += "<div style=\"float:left; width:398px\"><h3>Angreifer</h3>";
			kampbericht += "<p>" + a.Crossbow + " Armbrüste</p>";
			kampbericht += "<p>" + a.Beer + " Bier</p>";
			kampbericht += "<p>" + a.Bow + " Bögen</p>";
			kampbericht += "<p>" + a.BronzeSword + " Bronzeschwerter</p>";
			kampbericht += "<p>" + a.IronSword + " Eisenschwerter</p>";
			kampbericht += "<p>" + a.Cannon + " Kanonen</p>";
			kampbericht += "<p>" + a.Longbow + " Langbogen</p>";
			kampbericht += "<p>" + a.Horse + " Pferde</p>";
			kampbericht += "<p>" + a.Population + " Siedler</p>";
			kampbericht += "<p>" + a.SteelSword + " Stahlschwerter</p>";
			kampbericht += "<p>" + a.TitaniumSword + " Titaniumschwerter</p>";

			kampbericht += "</div>";

			kampbericht += "<div style=\"float:right; width:398px\"><h3>Verteidiger</h3>";
			kampbericht += "<p>" + d.Crossbow + " Armbrüste</p>";
			kampbericht += "<p>" + d.Beer + " Bier</p>";
			kampbericht += "<p>" + d.Bow + " Bögen</p>";
			kampbericht += "<p>" + d.BronzeSword + " Bronzeschwerter</p>";
			kampbericht += "<p>" + d.IronSword + " Eisenschwerter</p>";
			kampbericht += "<p>" + d.Cannon + " Kanonen</p>";
			kampbericht += "<p>" + d.Longbow + " Langbogen</p>";
			kampbericht += "<p>" + d.Horse + " Pferde</p>";
			kampbericht += "<p>" + d.Population + " Siedler</p>";
			kampbericht += "<p>" + d.SteelSword + " Stahlschwerter</p>";
			kampbericht += "<p>" + d.TitaniumSword + " Titaniumschwerter</p>";
			kampbericht += "</div>";

			kampbericht += "<div style=\"clear:both\">&nbsp;</div>";
			kampbericht += "</div>";
			kampbericht += "</div>";

		}

		private void setzteMaxHP() {
			foreach (Einheit e in verteidiger) {
				e.HitPoints = e.MaxHP;
			}
			if (kb)
				kampbericht += "<div id=\"container1\"><p>Alle übriggebliebenen Einheiten des Verteigigers haben sich vollständig erholt.</p></div>";
		}

		private void AngriffsWelle(ArrayList angreifer) {
			bool ende = false;
			int i = 1;
			while (ende == false) {

				if (kb) {
					kampbericht += "<div id=\"container1\"><h1> Kampfrunde " + i.ToString() + "</h1>\r\n";

					kampbericht += "<div id=\"container2\">";
					kampbericht += "<h2>Schlachtfeld</h2>";
					kampbericht += "<div style=\"float:left; width:398px\"><h3>" + angreifername + " (" + angreifer.Count.ToString() + ")</h3>";
					schreibeArmeeübersicht(angreifer);
					kampbericht += "</div>";
					kampbericht += "<div style=\"float:right; width:398px\"><h3>" + verteidigername + " (" + verteidiger.Count.ToString() + ")";
					if (turm == true)
						kampbericht += " hat Turmbonus</h3>";
					else
						kampbericht += " hat keinen Turmbonus</h3>";
					schreibeArmeeübersicht(verteidiger);
					kampbericht += "</div>";
					kampbericht += "<div style=\"clear:both\">&nbsp;</div></div>";
				}

				for (int p = 1; p < 4; p++) {
					string phase = "";
					if (p == 1)
						phase = "Phase 1: Firststrike";
					if (p == 2)
						phase = "Phase 2: normale Einheiten";
					if (p == 3)
						phase = "Phase 3: langsame Einheiten";

					//Kampfphase
					if (kb) {
						kampbericht += "<div id=\"container2\">\r\n<h2>" + phase + "</h2>\r\n";
						kampbericht += "<h3>" + angreifername + " vs. " + verteidigername + "</h3> \r\n";
					}

					KampfRundenPhase(angreifer, verteidiger, turm, p);
					if (kb)
						kampbericht += "<h3>" + verteidigername + " vs. " + angreifername + "</h3> \r\n";

					KampfRundenPhase(verteidiger, angreifer, false, p);
					//Tode Einheiten entfernen           
					if (kb)
						kampbericht += "<h3>gestorbene Einheiten von " + angreifername + "</h3> \r\n";
					todeEinheiten(ref angreifer, ref ExpVerteidiger, ref todeVomAngreiferGesamt);
					if (kb)
						kampbericht += "<h3>gestorbene Einheiten von " + verteidigername + "</h3> \r\n";
					todeEinheiten(ref verteidiger, ref ExpAngreifer, ref todeVomVerteidigerrGesamt);
					if (kb)
						kampbericht += "</div>";
				}

				//Rundenergebnis
				if (kb)
					kampbericht += "<b>Rundenergebnis:</b> " + angreifername + " = " + angreifer.Count.ToString() + " vs. " + verteidigername + " = " + verteidiger.Count.ToString();

				if (angreifer.Count == 0 || verteidiger.Count == 0)
					ende = true;
				i++;
				if (kb)
					kampbericht += "</div>\r\n\r\n";
			}
			if (kb) {
				kampbericht += "<div id=\"container1\"><h1>Ergebnis der Angriffswelle </h1>\r\n";
				kampbericht += "<div id=\"container2\">";
				kampbericht += "<h2>Schlachtfeld</h2>";
				kampbericht += "<div style=\"float:left; width:398px\"><h3>" + angreifername + " (" + angreifer.Count.ToString() + ") (+" + ExpAngreifer.ToString() + " Erfahrung Summe)</h3>";
				schreibeArmeeübersicht(angreifer);

				kampbericht += "</div>";
				kampbericht += "<div style=\"float:right; width:398px\"><h3>" + verteidigername + " (" + verteidiger.Count.ToString() + ") (+" + ExpVerteidiger.ToString() + " Erfahrung Summe)";
				if (turm == true)
					kampbericht += " hat Turmbonus</h3>";
				else
					kampbericht += " hat keinen Turmbonus</h3>";
				schreibeArmeeübersicht(verteidiger);

				kampbericht += "</div>";
				kampbericht += "<div style=\"clear:both\">&nbsp;</div></div>";

				kampbericht += "<div id=\"container2\">";
				if (angreifer.Count == 0)
					kampbericht += "<h2>Die Armee hat die Schlacht verloren und zieht sich zurück.</h2><p>Der General braucht eine Erholungsphase von 4 Stunden.</p>";
				else { kampbericht += "<h2>Der General war siegreich. Er zieht sich in seine Garnision zurück.</h2>"; }
				kampbericht += "</div>";
				kampbericht += "</div>";
			}
		}

		private void schreibeArmeeübersicht(ArrayList liste) {
			if (liste.Count == 0)
				return;
			Klassen.Einheit e = (Klassen.Einheit)liste[0];
			int hitpoints = 0;

			Einheit a = e;
			int counter = 0;
			for (int i = 0; i < liste.Count; i++) {
				e = (Klassen.Einheit)liste[i];

				if (e.Typ != a.Typ) {
					kampbericht += "<p>" + counter.ToString() + " " + a.Typ +
					" Schaden (" + (a.HitDamage * counter).ToString() + "/" + (a.MissDamage * counter).ToString() + ") " +
					"HP (" + hitpoints.ToString() + ") " +
					"Prod.-Zeit: (" + (a.ProductionTimeSeconds * counter / 60).ToString() + "min) " +
					"</p>";
					a = e;
					hitpoints = 0;
					counter = 0;
				}
				hitpoints += a.HitPoints;
				counter++;
			}
			kampbericht += "<p>" + counter.ToString() + " " + a.Typ +
					" Schaden (" + (a.HitDamage * counter).ToString() + "/" + (a.MissDamage * counter).ToString() + ") " +
					"HP (" + hitpoints.ToString() + ") " +
					 "Prod.-Zeit: (" + (a.ProductionTimeSeconds * counter / 60).ToString() + "min) " +
					"</p>";
		}

		private void todeEinheiten(ref ArrayList Armee, ref int exp, ref ArrayList todeArmee) {
			if (Armee.Count == 0)
				return;
			Klassen.Einheit e;

			Armee.Sort((IComparer)new Klassen.Einheit.SortByNameClass());

			int i = 0;
			string typ = "";
			int counter = 0;

			while (i < Armee.Count) {
				e = (Klassen.Einheit)Armee[i];

				if (e.HitPoints <= 0) {
					if (typ == "")
						typ = e.Typ;

					todeArmee.Add(e);

					Armee.RemoveAt(i);
					exp += e.XpForDefeat;

					if (e.Typ != typ) {
						if (kb)
							kampbericht += "<p>" + counter.ToString() + " " + typ + "</p>";
						typ = e.Typ;
						counter = 0;
					}
					counter++;
				} else
					i++;
			}
			if (counter > 0 && kb)
				kampbericht += "<p>" + counter.ToString() + " " + typ + "</p>";
		}

		/// <summary>
		/// KampfRundenPhase durchführen
		/// </summary>
		/// <param name="a">Angreifer</param>
		/// <param name="d">Verteidiger</param>
		/// <param name="tower">Turm</param>
		/// <param name="phase">Inititiative</param>
		private void KampfRundenPhase(ArrayList a, ArrayList d, bool tower, int phase) {
			//Sortiere Angreifer
			a.Sort((IComparer)new Einheit.SortBysequencePrioThenHp());

			//Sortiere Verteidiger
			if (phase != 1)
				d.Sort((IComparer)new Einheit.SortBysequencePrioThenHp());

			foreach (Klassen.Einheit ae in a) {
				//Überprüfen, ob Angreifereinheit die richtige Initiative besitzt
				if (phase == 1 && ae.skills.Skill5 == false)
					continue;
				if (phase == 2 && (ae.skills.Skill5 == true || ae.skills.Skill6 == true))
					continue;
				if (phase == 3 && ae.skills.Skill6 == false)
					continue;

				//Sortierung wegen FistStrikeEinheiten
				if (phase == 1) {
					//Wenn SequencePrio 12=chuck; 11=waltraud; Neusortierung SortBysequencePrioThenHp, sonst SortByHpThendPrio
					if (ae.SequencePrio.Equals(11) || ae.SequencePrio.Equals(12))
						d.Sort((IComparer)new Einheit.SortBysequencePrioThenHp());
				}

				//Schaden errechnen - zwecks voller Treffer oder geblockter Treffer bzw.Turmbonus 
				int damage = 0; // normaler Schaden
				int splash = 0; // Flächenschaden - Zähler
				if (rdm.Next(0, 101) <= ae.HitPercentage)
					damage = ae.HitDamage;
				else
					damage = ae.MissDamage;

				damage += damage / 100 * ae.skills.Skill1; //Bonus damage vs. units

				if (ae.skills.Skill3 == true) { splash = damage; } //Flächenschaden Zähler setzen, falls vorhanden             

				foreach (Klassen.Einheit de in d) {
					if (de.HitPoints <= 0)
						continue; //Wenn Verteiger keine HP, dann zum nächsten Verteiger
					if (de.skills.Skill8 == true) //Spezialisten (Generäle) werden erst angegriffen, wenn alle normalen Einheit HP Null haben
                    {
						bool z = true;
						foreach (Klassen.Einheit item in d) {
							if (item.HitPoints > 0 && item.skills.Skill8 == false)
								break;
							else
								z = false;
						}
						if (z)
							continue;
					}
					if (de.skills.Skill4 == true && tower == true && ae.skills.Skill7 == false)
						damage = damage / 2; //ignore Tower Armore

					int spl = de.HitPoints; // Angerichteter Flächenschaden
					splash -= spl; //  Angerichteter Flächenschaden wird von Flächenschadenzähler abgezogen 

					de.HitPoints -= damage; // Treffer wird bei Verteidiger abgezogen

					//Kampfbericht
					if (kb) {
						kampbericht += "<p>" + ae.Typ + " (" + ae.HitPoints.ToString() + "HP)" + " verursacht ";
						if (ae.skills.Skill3 == true)
							kampbericht += spl + " Flächenschaden (" + splash.ToString() + ")";
						else
							kampbericht += damage + " Schaden";
						kampbericht += " bei " + de.Typ + " (" + de.HitPoints + "HP)</p>\r\n";
					}

					if (splash <= 0) {
						//12=chuck; 11=waltraud; Rücksortierung falls Hunde noch angreifen
						if (ae.SequencePrio.Equals(11) || ae.SequencePrio.Equals(12))
							d.Sort((IComparer)new Einheit.SortByHpThendPrio());
						break; // Ist der Flächenschaden kleinergleich Null gehts zum nächsten Angreifer
					}
				}
			}
		}
	}
}
