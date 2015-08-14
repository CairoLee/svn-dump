using System;
using System.Windows.Forms;

namespace GodLesZ.SettlerOnline.FightSimulator {
	public partial class frmUnitInfo : Form {
		Klassen.Einheit e;


		public frmUnitInfo(object obj) {
			InitializeComponent();
			e = (Klassen.Einheit)obj;
		}

		private void einheitenInfo_Load(object sender, EventArgs e) {
			schreibeEinheitenInfos();
		}

		private void schreibeEinheitenInfos() {
			this.Text = "Einheiteninformation";

			//Allgemein
			lblName.Text = e.Typ;
			pbBild.Image = e.Bild;

			//Eigenschaften
			lblGesundheit.Text = e.HitPoints.ToString();
			lblMaxSchaden.Text = e.HitDamage.ToString();
			lblMinSchaden.Text = e.MissDamage.ToString();
			lbltrefferwahrscheinlichkeit.Text = e.HitPercentage.ToString();

			lblproduzierbar.Text = JaNein(e.Produceable);
			lblproduktionszeit.Text = e.ProductionTimeSeconds.ToString() + " s";

			lblExp.Text = e.XpForDefeat.ToString();

			//Fertigkeiten
			lblbonusgebäudeschaden.Text = e.skills.Skill0.ToString() + " %";
			lblbonuseinheitenschaden.Text = e.skills.Skill1.ToString() + " %";
			lblattackiertschwächsteeinheitzuerst.Text = JaNein(e.skills.Skill2);
			lblsplashschaden.Text = JaNein(e.skills.Skill3);
			lblturmbonus.Text = JaNein(e.skills.Skill4);
			lblerstschlag.Text = JaNein(e.skills.Skill5);
			lblgreiftzuletztan.Text = JaNein(e.skills.Skill6);
			lblIgnoriertTurmbonus.Text = JaNein(e.skills.Skill7);
			lblspezialist.Text = JaNein(e.skills.Skill8);

			//Rohstoffkosten
			lblarmbrüste.Text = e.rohstoffe.Crossbow.ToString();
			lblBier.Text = e.rohstoffe.Beer.ToString();
			lblBogen.Text = e.rohstoffe.Bow.ToString();
			lblBronzeschwert.Text = e.rohstoffe.BronzeSword.ToString();
			lblEisenschwert.Text = e.rohstoffe.IronSword.ToString();
			lblkanonen.Text = e.rohstoffe.Cannon.ToString();
			lblLangbögen.Text = e.rohstoffe.Longbow.ToString();
			lblPferde.Text = e.rohstoffe.Horse.ToString();
			lblSiedler.Text = e.rohstoffe.Population.ToString();
			lblStahlschwerter.Text = e.rohstoffe.SteelSword.ToString();
			lbltitaniumschwerter.Text = e.rohstoffe.TitaniumSword.ToString();
		}

		private string JaNein(bool b) {
			if (b == true)
				return "ja";
			else
				return "nein";
		}
	}
}
