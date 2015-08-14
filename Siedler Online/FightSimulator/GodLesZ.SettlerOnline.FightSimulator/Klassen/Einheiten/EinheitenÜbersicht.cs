
namespace GodLesZ.SettlerOnline.FightSimulator.Klassen.Einheiten {
	class EinheitenÜbersicht {
		public static string html = "";

		public EinheitenÜbersicht() {

		}

		public static string Übersicht() {

			Einheiten_des_Spielers();
			Einheiter_der_Räuber();

			return html;
		}

		private static string Einheiter_der_Räuber() {
			Plünderer pl = new Plünderer();
			Schläger sl = new Schläger();
			Wachhund wh = new Wachhund();
			Raufbold rb = new Raufbold();
			Steinwerfer sw = new Steinwerfer();
			Waldläufer wl = new Waldläufer();

			BB2_Einäugiger_Bert eb = new BB2_Einäugiger_Bert();
			BB1_Stinktier st = new BB1_Stinktier();
			BB4_Chuck ck = new BB4_Chuck();
			BB3_Metallgebiss mg = new BB3_Metallgebiss();
			BB5_Die_wilde_Waltraud dww = new BB5_Die_wilde_Waltraud();

			html += "<div id=\"container1\"><h1>Übersicht Einheiten der Räuber</h1>";
			html += "<div id=\"container2\"><h2>Räuber</h2>";
			html += "<table>";
			html += "<tr>";
			html += "<th>Typ</th><th>Pos.</th><th>HP</th><th>Max.<br />Schaden</th><th>Min.<br />Schaden</th><th>Treffer-<br/>chance</th>";
			html += "<th>Initiative</th><th>Turm</th><th>ign.<br />Turm</th><th>EP</th>";
			html += "<th>Attackiert<br />Einh. m.<br /> kleinster HP<br/>zuerst</th>";
			html += "</tr>";
			for (int i = 0; i < 30; i++) {
				Einheit einheit = new Einheit();
				if (i == pl.SequencePrio)
					einheit = pl;
				if (i == sl.SequencePrio)
					einheit = sl;
				if (i == wh.SequencePrio)
					einheit = wh;
				if (i == rb.SequencePrio)
					einheit = rb;
				if (i == sw.SequencePrio)
					einheit = sw;
				if (i == wl.SequencePrio)
					einheit = wl;
				if (einheit.Typ == null)
					continue;

				html += "<tr>";
				html += "<td><b>" + einheit.Typ + "</b></td>";
				html += "<td class=\"center\">" + einheit.SequencePrio + "</td>";
				html += "<td class=\"center\">" + einheit.HitPoints + "</td>";
				html += "<td class=\"center\">" + einheit.HitDamage + "</td>";
				html += "<td class=\"center\">" + einheit.MissDamage + "</td>";
				html += "<td class=\"center\">" + einheit.HitPercentage + " %</td>";

				if (einheit.skills.Skill5 == true || einheit.skills.Skill6 == true) {
					if (einheit.skills.Skill5 == true)
						html += "<td class=\"center\">hoch</td>";
					else
						html += "<td class=\"center\">niedrig</td>";
				} else
					html += "<td class=\"center\">normal</td>";

				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill4) + "</td>";
				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill7) + "</td>";
				html += "<td class=\"center\">" + einheit.XpForDefeat + "</td>";
				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill2) + "</td>";
				html += "</tr>";
			}
			html += "</tr>";
			html += "</table>";
			html += "</div>";

			html += "<div id=\"container2\"><h2>Bosse</h2>";
			html += "<table>";
			html += "<tr>";
			html += "<th>Typ</th><th>Pos.</th><th>HP</th><th>Max.<br />Schaden</th><th>Min.<br />Schaden</th><th>Treffer-<br/>chance</th>";
			html += "<th>Initiative</th><th>EP</th><th>Flächen-<br />schaden</th>";
			html += "</tr>";


			for (int i = 0; i < 30; i++) {
				Einheit einheit = new Einheit();
				if (i == eb.SequencePrio)
					einheit = eb;
				if (i == st.SequencePrio)
					einheit = st;
				if (i == ck.SequencePrio)
					einheit = ck;
				if (i == mg.SequencePrio)
					einheit = mg;
				if (i == dww.SequencePrio)
					einheit = dww;


				if (einheit.Typ == null)
					continue;

				html += "<tr>";
				html += "<td><b>" + einheit.Typ + "</b></td>";
				html += "<td class=\"center\">" + einheit.SequencePrio + "</td>";
				html += "<td class=\"center\">" + einheit.HitPoints + "</td>";
				html += "<td class=\"center\">" + einheit.HitDamage + "</td>";
				html += "<td class=\"center\">" + einheit.MissDamage + "</td>";
				html += "<td class=\"center\">" + einheit.HitPercentage + " %</td>";

				if (einheit.skills.Skill5 == true || einheit.skills.Skill6 == true) {
					if (einheit.skills.Skill5 == true)
						html += "<td class=\"center\">hoch</td>";
					else
						html += "<td class=\"center\">niedrig</td>";
				} else
					html += "<td class=\"center\">normal</td>";

				html += "<td class=\"center\">" + einheit.XpForDefeat + "</td>";
				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill3) + "</td>";
				html += "</tr>";



			}
			html += "</tr>";
			html += "</table>";
			html += "</div>";

			html += "</div>";

			return html;
		}

		private static string Einheiten_des_Spielers() {
			Rekrut r = new Rekrut();
			Bogenschütze b = new Bogenschütze();
			Militz m = new Militz();
			Kavallerie c = new Kavallerie();
			Langbogenschütze lb = new Langbogenschütze();
			Soldat s = new Soldat();
			Elitesoldat es = new Elitesoldat();
			Armbrustschütze a = new Armbrustschütze();
			Kanonier k = new Kanonier();
			Genral g = new Genral();
			Spezialist sp = new Spezialist();


			html += "<div id=\"container1\"><h1>Übersicht Einheiten des Spielers</h1>";
			html += "<div id=\"container2\"><h2>Eigenschaften</h2>";
			html += "<table>";
			html += "<tr>";
			html += "<th>Typ</th><th>Pos.</th><th>HP</th><th>Max.<br />Schaden</th><th>Min.<br />Schaden</th><th>Treffer-<br/>chance</th>";
			html += "<th>Initiative</th><th>Turm</th><th>ign.<br />Turm</th><th>EP</th><th>Bonus<br/>Schaden<br/>Gebäude</th><th>Bonus<br/>Schaden<br/>Einh.</th>";
			html += "<th>Attackiert<br />Einh. m.<br /> kleinster HP<br/>zuerst</th><th>Spezialist</th><th>Prod.-<br/>Zeit</th>";
			html += "</tr>";
			for (int i = 0; i < 902; i++) {
				Einheit einheit = new Einheit();
				if (i == r.SequencePrio)
					einheit = r;
				if (i == b.SequencePrio)
					einheit = b;
				if (i == m.SequencePrio)
					einheit = m;
				if (i == c.SequencePrio)
					einheit = c;
				if (i == lb.SequencePrio)
					einheit = lb;
				if (i == s.SequencePrio)
					einheit = s;
				if (i == es.SequencePrio)
					einheit = es;
				if (i == a.SequencePrio)
					einheit = a;
				if (i == k.SequencePrio)
					einheit = k;
				if (i == g.SequencePrio)
					einheit = g;
				if (i == sp.SequencePrio)
					einheit = sp;
				if (einheit.Typ == null)
					continue;

				html += "<tr>";
				html += "<td><b>" + einheit.Typ + "</b></td>";
				html += "<td class=\"center\">" + einheit.SequencePrio + "</td>";
				html += "<td class=\"center\">" + einheit.HitPoints + "</td>";
				html += "<td class=\"center\">" + einheit.HitDamage + "</td>";
				html += "<td class=\"center\">" + einheit.MissDamage + "</td>";
				html += "<td class=\"center\">" + einheit.HitPercentage + " %</td>";

				if (einheit.skills.Skill5 == true || einheit.skills.Skill6 == true) {
					if (einheit.skills.Skill5 == true)
						html += "<td class=\"center\">hoch</td>";
					else
						html += "<td class=\"center\">niedrig</td>";
				} else
					html += "<td class=\"center\">normal</td>";

				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill4) + "</td>";
				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill7) + "</td>";
				html += "<td class=\"center\">" + einheit.XpForDefeat + "</td>";
				html += "<td class=\"center\">" + einheit.skills.Skill0 + " %</td>";
				html += "<td class=\"center\">" + einheit.skills.Skill1 + " %</td>";
				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill2) + "</td>";
				html += "<td class=\"center\">" + JaNein(einheit.skills.Skill8) + "</td>";
				html += "<td class=\"center\">" + einheit.ProductionTimeSeconds.ToString() + " s</td>";
				html += "</tr>";
			}
			html += "</tr>";
			html += "</table>";
			html += "</div>";

			html += "<div id=\"container2\"><h2>Rohstoffkosten</h2>";
			html += "<table>";
			html += "<tr>";
			html += "<th>Typ</th>";
			html += "<th>Bier</th>";
			html += "<th>Bogen</th>";
			html += "<th>Bronze-<br/>schwerter</th>";
			html += "<th>Eisen-<br/>schwerter</th>";
			html += "<th>Langbögen</th>";
			html += "<th>Pferde</th>";
			html += "<th>Siedler</th>";
			html += "<th>Stahl<br/>schwerter</th>";
			html += "<th>Titanium-<br/>schwerter</th>";
			html += "<th>Armbrüste</th>";
			html += "<th>Kanonen</th>";

			html += "</tr>";
			for (int i = 0; i < 10; i++) {
				Einheit einheit = new Einheit();
				if (i == r.SequencePrio)
					einheit = r;
				if (i == b.SequencePrio)
					einheit = b;
				if (i == m.SequencePrio)
					einheit = m;
				if (i == c.SequencePrio)
					einheit = c;
				if (i == lb.SequencePrio)
					einheit = lb;
				if (i == s.SequencePrio)
					einheit = s;
				if (i == es.SequencePrio)
					einheit = es;
				if (i == a.SequencePrio)
					einheit = a;
				if (i == k.SequencePrio)
					einheit = k;

				if (einheit.Typ == null)
					continue;

				html += "<td><b>" + einheit.Typ + "</b></td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Beer + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Bow + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.BronzeSword + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.IronSword + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Longbow + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Horse + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Population + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.IronSword + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.SteelSword + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Crossbow + "</td>";
				html += "<td class=\"center\">" + einheit.rohstoffe.Cannon + "</td>";


				html += "</tr>";
			}
			html += "</tr>";
			html += "</table>";
			html += "</div>";

			html += "</div>";

			return html;
		}

		static string JaNein(bool b) {
			if (b == true)
				return "ja";
			else
				return "nein";
		}



	}
}
