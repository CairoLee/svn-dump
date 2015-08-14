using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.SettlerOnline.FightSimulator {

	public partial class frmMain : Form {
		ArrayList a1;
		ArrayList a2;
		ArrayList a3;
		ArrayList d;
		ArrayList config;
		DataSet1 ds;
		string datasetVersion;
		ArrayList browserListe;
		BindingSource bs;


		public frmMain() {
			InitializeComponent();

			a1 = new ArrayList();
			a2 = new ArrayList();
			a3 = new ArrayList();
			d = new ArrayList();
			config = new ArrayList();
			ds = new DataSet1();
			browserListe = new ArrayList();
			bs = new BindingSource();
			datasetVersion = "1.0.0";
		}

		private void frmMain_Load(object sender, EventArgs e) {
			this.Icon = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.icon;
			configDataSetLoad();
			this.Text += " " + Application.ProductVersion.ToString();

			btmInfoArmbrustschütze.BackgroundImage = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Armbrustschuetze;

			browserListe.Add("http://sok.kann-helfen.de");
			browserListe.Add("http://forum.diesiedleronline.de/threads/2441-.Net-Siedler-Online-Kampfsimulator");

			webbrowser("");
		}

		private void cmbAR_SelectedIndexChanged(object sender, EventArgs e) {
			setzeArmee();
		}

		private void setzeArmee() {
			try {
				a1.Clear();
				a2.Clear();
				a3.Clear();
				d.Clear();

				for (int i = 0; i < Convert.ToInt16(txtAR1.Text); i++)
					a1.Add(new Klassen.Rekrut());
				for (int i = 0; i < Convert.ToInt16(txtAM1.Text); i++)
					a1.Add(new Klassen.Militz());
				for (int i = 0; i < Convert.ToInt16(txtAC1.Text); i++)
					a1.Add(new Klassen.Kavallerie());
				for (int i = 0; i < Convert.ToInt16(txtAS1.Text); i++)
					a1.Add(new Klassen.Soldat());
				for (int i = 0; i < Convert.ToInt16(txtAE1.Text); i++)
					a1.Add(new Klassen.Elitesoldat());
				for (int i = 0; i < Convert.ToInt16(txtAB1.Text); i++)
					a1.Add(new Klassen.Bogenschütze());
				for (int i = 0; i < Convert.ToInt16(txtAL1.Text); i++)
					a1.Add(new Klassen.Langbogenschütze());
				for (int i = 0; i < Convert.ToInt16(txtAA1.Text); i++)
					a1.Add(new Klassen.Armbrustschütze());
				for (int i = 0; i < Convert.ToInt16(txtAK1.Text); i++)
					a1.Add(new Klassen.Kanonier());
				if (chkG1.Checked == true)
					a1.Add(new Klassen.Genral());


				for (int i = 0; i < Convert.ToInt16(txtAR2.Text); i++)
					a2.Add(new Klassen.Rekrut());
				for (int i = 0; i < Convert.ToInt16(txtAM2.Text); i++)
					a2.Add(new Klassen.Militz());
				for (int i = 0; i < Convert.ToInt16(txtAC2.Text); i++)
					a2.Add(new Klassen.Kavallerie());
				for (int i = 0; i < Convert.ToInt16(txtAS2.Text); i++)
					a2.Add(new Klassen.Soldat());
				for (int i = 0; i < Convert.ToInt16(txtAE2.Text); i++)
					a2.Add(new Klassen.Elitesoldat());
				for (int i = 0; i < Convert.ToInt16(txtAB2.Text); i++)
					a2.Add(new Klassen.Bogenschütze());
				for (int i = 0; i < Convert.ToInt16(txtAL2.Text); i++)
					a2.Add(new Klassen.Langbogenschütze());
				for (int i = 0; i < Convert.ToInt16(txtAA2.Text); i++)
					a2.Add(new Klassen.Armbrustschütze());
				for (int i = 0; i < Convert.ToInt16(txtAK2.Text); i++)
					a2.Add(new Klassen.Kanonier());
				if (chkG2.Checked == true)
					a2.Add(new Klassen.Genral());

				for (int i = 0; i < Convert.ToInt16(txtAR3.Text); i++)
					a3.Add(new Klassen.Rekrut());
				for (int i = 0; i < Convert.ToInt16(txtAM3.Text); i++)
					a3.Add(new Klassen.Militz());
				for (int i = 0; i < Convert.ToInt16(txtAC3.Text); i++)
					a3.Add(new Klassen.Kavallerie());
				for (int i = 0; i < Convert.ToInt16(txtAS3.Text); i++)
					a3.Add(new Klassen.Soldat());
				for (int i = 0; i < Convert.ToInt16(txtAE3.Text); i++)
					a3.Add(new Klassen.Elitesoldat());
				for (int i = 0; i < Convert.ToInt16(txtAB3.Text); i++)
					a3.Add(new Klassen.Bogenschütze());
				for (int i = 0; i < Convert.ToInt16(txtAL3.Text); i++)
					a3.Add(new Klassen.Langbogenschütze());
				for (int i = 0; i < Convert.ToInt16(txtAA3.Text); i++)
					a3.Add(new Klassen.Armbrustschütze());
				for (int i = 0; i < Convert.ToInt16(txtAK3.Text); i++)
					a3.Add(new Klassen.Kanonier());
				if (chkG3.Checked == true)
					a3.Add(new Klassen.Genral());


				if (rbPlayer.Checked == true) {
					if (chkDG.Checked == true)
						d.Add(new Klassen.Genral());
					{
						for (int j = 0; j < Convert.ToInt16(txtDR.Text); j++)
							d.Add(new Klassen.Rekrut());
						for (int j = 0; j < Convert.ToInt16(txtDM.Text); j++)
							d.Add(new Klassen.Militz());
						for (int j = 0; j < Convert.ToInt16(txtDC.Text); j++)
							d.Add(new Klassen.Kavallerie());
						for (int j = 0; j < Convert.ToInt16(txtDS.Text); j++)
							d.Add(new Klassen.Soldat());
						for (int j = 0; j < Convert.ToInt16(txtDE.Text); j++)
							d.Add(new Klassen.Elitesoldat());
						for (int j = 0; j < Convert.ToInt16(txtDB.Text); j++)
							d.Add(new Klassen.Bogenschütze());
						for (int j = 0; j < Convert.ToInt16(txtDL.Text); j++)
							d.Add(new Klassen.Langbogenschütze());
						for (int j = 0; j < Convert.ToInt16(txtDA.Text); j++)
							d.Add(new Klassen.Armbrustschütze());
						for (int j = 0; j < Convert.ToInt16(txtDK.Text); j++)
							d.Add(new Klassen.Kanonier());
					}
				}

				if (rbBandit.Checked == true) {
					for (int j = 0; j < Convert.ToInt16(txtPL.Text); j++)
						d.Add(new Klassen.Plünderer());
					for (int j = 0; j < Convert.ToInt16(txtSL.Text); j++)
						d.Add(new Klassen.Schläger());
					for (int j = 0; j < Convert.ToInt16(txtWH.Text); j++)
						d.Add(new Klassen.Wachhund());
					for (int j = 0; j < Convert.ToInt16(txtRB.Text); j++)
						d.Add(new Klassen.Raufbold());
					for (int j = 0; j < Convert.ToInt16(txtSW.Text); j++)
						d.Add(new Klassen.Steinwerfer());
					for (int j = 0; j < Convert.ToInt16(txtWL.Text); j++)
						d.Add(new Klassen.Waldläufer());

					if (rbEB.Checked == true)
						d.Add(new Klassen.BB2_Einäugiger_Bert());
					if (rbST.Checked == true)
						d.Add(new Klassen.BB1_Stinktier());
					if (rbCK.Checked == true)
						d.Add(new Klassen.BB4_Chuck());
					if (rbMG.Checked == true)
						d.Add(new Klassen.BB3_Metallgebiss());
					if (rbDWW.Checked == true)
						d.Add(new Klassen.BB5_Die_wilde_Waltraud());
				}
			} catch (Exception ex) {
				webbrowser("<div id=\"container1\"><h1>fehlerhafte Eingabe</h1>\r\n" + ex.Message + "</div>");

			}
		}

		private void btnStart_Click(object sender, EventArgs e) {
			Klassen.KampfSimulation ks = new Klassen.KampfSimulation();

			string defenderName = txtDefenderName.Text;
			if (rbBandit.Checked == true)
				defenderName = txtBanditName.Text;

			//Detailierter Kampfbericht
			if (chkSimulationen.Checked == false) {
				setzeArmee();
				ks.KapmfSimulation(a1, a2, a3, d, chkDT.Checked, txtAngreiferName.Text, defenderName, !chkSimulationen.Checked);
				webbrowser(ks.Bericht);
			} else { //Auswertunf von mehreren Kampfberichten
				if (MessageBox.Show("Willst Du wirklich mehrere Simulationen berechnen lassen?\r\n\r\nJe nach Rechenleistung und Anzahl Simulationen bzw. Einheiten, \r\nkann die Berechnung sehr lange dauern.", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
					return;
				if (Convert.ToInt32(txtAnzSimulationen.Text) == 0)
					txtAnzSimulationen.Text = "1";
				ArrayList simulationen = new ArrayList();

				this.Refresh();

				frmSimulationProgress frmStatus = new frmSimulationProgress(Convert.ToInt32(txtAnzSimulationen.Text));
				frmStatus.Show();

				for (int i = 0; i < Convert.ToInt32(txtAnzSimulationen.Text); i++) {
					a1 = new ArrayList();
					a2 = new ArrayList();
					a3 = new ArrayList();
					d = new ArrayList();

					setzeArmee();
					simulationen.Add(ks.KapmfSimulation(a1, a2, a3, d, chkDT.Checked, txtAngreiferName.Text, defenderName, !chkSimulationen.Checked));
					frmStatus.Step();
				}
				Klassen.KampfSimulatorAuswertung Auswertung = new Klassen.KampfSimulatorAuswertung(simulationen);
				webbrowser(Auswertung.Bericht);
			}


		}

		private void webbrowser(string Body) {


			webFightSummary.DocumentText = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\"><html>\r\n" +
										"<head>\r\n" +
											"<title>Siedler-Online-Kampfsimulator</title>\r\n" +
											" <style type=\"text/css\"> <!--\r\n" +
											" root{display:block}*{margin:0;padding:0} \r\n" +
											" body {background-color: #6a9acb;font-family:\"Segoe UI\"; font-size: 11px;}\r\n" +
											" h1 {background-color: white;    color: red;   font-size: 14px;    margin-bottom: 2px;  padding:2px 2px;}\r\n" +
											" h2 {background-color: orange; font-size: 12px;    padding:2px 1px;}\r\n" +
											" h3 {background-color: #fce68c; font-size: 11px;   border-top: 1px solid; padding:2px 1px;}\r\n" +
											" p  {padding:0px 2px;}\r\n" +
											" li {margin-left:20px;padding-left:20} \r\n " +
											" #container1 {background-color: #ffFFFF; border: 1px solid; padding: 2px; margin: 2px auto; width: 800px}\r\n" +
											" #container2 {border: 1px solid; margin: 2px 0px;}\r\n" +
											" table {width: 100%}" +
											" td {border: 1px solid black; margin: 2px; padding: 2px;}" +
											" th {border: 1px solid black; margin: 2px; padding: 2px;}" +
											" .center {text-align: center;}" +
											" .left {float:left;} " +
											" .right {float:right;} " +
											" .right.after {clear:both} " +
											" --></style>\r\n" +

											"<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\" />\r\n" +
										"</head>\r\n" +
										 "<body>\r\n  " +
										 "<div id=\"container1\"><h1>Siedler-Online-Kampfsimulator V." + Application.ProductVersion.ToString() + "</h1></div>"

										 + Body +

										 "\r\n</body>\r\n" +
										 "</html>";
		}




		private void endeToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void btnSpeichern_Click(object sender, EventArgs e) {
			try {
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.FileName = "SOK_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + "_" + txtAngreiferName.Text + "_" + txtDefenderName.Text + ".html";
				sfd.Filter = "HTML-Dateien (*.html)|*.html";

				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
					System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName);
					sw.Write(webFightSummary.DocumentText);
					sw.Close();
				}
			} catch (Exception) {

			}

		}

		#region Einheiteninformationen anzeigen
		private void btmInfoRekrut_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Rekrut());
			info.ShowDialog();
		}

		private void btmInfoBogenschütze_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Bogenschütze());
			info.ShowDialog();
		}

		private void btmInfoMilitz_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Militz());
			info.ShowDialog();
		}

		private void btmInfoReiterei_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Kavallerie());
			info.ShowDialog();
		}

		private void btmInfoLangbogenschütze_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Langbogenschütze());
			info.ShowDialog();
		}

		private void btmInfoSoldat_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Soldat());
			info.ShowDialog();
		}

		private void btmInfoElitesoldat_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Elitesoldat());
			info.ShowDialog();
		}

		private void btmInfoArmbrustschütze_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Armbrustschütze());
			info.ShowDialog();
		}

		private void btmInfoKononiere_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Kanonier());
			info.ShowDialog();
		}

		private void btmInfoGeneral_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Genral());
			info.ShowDialog();
		}
		#endregion


		private void theWarGuideToolStripMenuItem_Click(object sender, EventArgs e) {
			webbrowser(GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.WarGuide);
		}

		private void versionscheckToolStripMenuItem_Click(object sender, EventArgs e) {
			webbrowser(Klassen.versionscheck.Check(Application.ProductVersion));
		}

		private void infoToolStripMenuItem_Click(object sender, EventArgs e) {
			frmAbout about = new frmAbout();
			about.ShowDialog();
		}

		private void chkG2_CheckedChanged(object sender, EventArgs e) {
			txtAR2.Enabled = chkG2.Checked;
			txtAB2.Enabled = chkG2.Checked;
			txtAM2.Enabled = chkG2.Checked;
			txtAC2.Enabled = chkG2.Checked;
			txtAL2.Enabled = chkG2.Checked;
			txtAS2.Enabled = chkG2.Checked;
			txtAE2.Enabled = chkG2.Checked;
			txtAA2.Enabled = chkG2.Checked;
			txtAK2.Enabled = chkG2.Checked;

			if (chkG2.Checked == false) {
				txtAR2.Text = "0";
				txtAB2.Text = "0";
				txtAM2.Text = "0";
				txtAC2.Text = "0";
				txtAL2.Text = "0";
				txtAS2.Text = "0";
				txtAE2.Text = "0";
				txtAA2.Text = "0";
				txtAK2.Text = "0";
			}
		}

		private void chkG3_CheckedChanged(object sender, EventArgs e) {
			txtAR3.Enabled = chkG3.Checked;
			txtAB3.Enabled = chkG3.Checked;
			txtAM3.Enabled = chkG3.Checked;
			txtAC3.Enabled = chkG3.Checked;
			txtAL3.Enabled = chkG3.Checked;
			txtAS3.Enabled = chkG3.Checked;
			txtAE3.Enabled = chkG3.Checked;
			txtAA3.Enabled = chkG3.Checked;
			txtAK3.Enabled = chkG3.Checked;

			if (chkG3.Checked == false) {
				txtAR3.Text = "0";
				txtAB3.Text = "0";
				txtAM3.Text = "0";
				txtAC3.Text = "0";
				txtAL3.Text = "0";
				txtAS3.Text = "0";
				txtAE3.Text = "0";
				txtAA3.Text = "0";
				txtAK3.Text = "0";
			}
		}



		private void btnConfigAdd_Click(object sender, EventArgs e) {
			configAdd();
		}



		private void btnConfigDelete_Click(object sender, EventArgs e) {
			configDelete();

		}





		private void selectAllInMaskedTextBox(object sender, EventArgs e) {
			((MaskedTextBox)sender).Focus();
			((MaskedTextBox)sender).SelectAll();
		}

		private void selectAllInTextBox(object sender, EventArgs e) {
			((TextBox)sender).Focus();
			((TextBox)sender).SelectAll();
		}


		private void btnPL_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Plünderer());
			info.ShowDialog();
		}

		private void btnSG_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Schläger());
			info.ShowDialog();
		}

		private void btnWH_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Wachhund());
			info.ShowDialog();
		}

		private void btnRB_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Raufbold());
			info.ShowDialog();
		}

		private void btnSW_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Steinwerfer());
			info.ShowDialog();
		}

		private void btnWL_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.Waldläufer());
			info.ShowDialog();
		}

		private void einheitenübesichtToolStripMenuItem_Click(object sender, EventArgs e) {
			webbrowser(GodLesZ.SettlerOnline.FightSimulator.Klassen.Einheiten.EinheitenÜbersicht.Übersicht());
		}

		private void btnEB_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.BB2_Einäugiger_Bert());
			info.ShowDialog();
		}

		private void btnST_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.BB1_Stinktier());
			info.ShowDialog();
		}

		private void btnCK_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.BB4_Chuck());
			info.ShowDialog();
		}

		private void btnMG_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.BB3_Metallgebiss());
			info.ShowDialog();
		}

		private void btnDWW_Click(object sender, EventArgs e) {
			frmUnitInfo info = new frmUnitInfo(new Klassen.BB5_Die_wilde_Waltraud());
			info.ShowDialog();
		}

		private void zähleArmee(object sender, EventArgs e) {
			if (ds.DataTable1.Rows.Count == 0)
				return;
			try {
				int z1 = 0;
				int z2 = 0;
				int z3 = 0;
				int z4 = 0;
				int z5 = 0;

				z1 += Convert.ToInt32(txtAR1.Text);
				z1 += Convert.ToInt32(txtAB1.Text);
				z1 += Convert.ToInt32(txtAM1.Text);
				z1 += Convert.ToInt32(txtAC1.Text);
				z1 += Convert.ToInt32(txtAS1.Text);
				z1 += Convert.ToInt32(txtAE1.Text);
				z1 += Convert.ToInt32(txtAA1.Text);
				z1 += Convert.ToInt32(txtAK1.Text);
				z1 += Convert.ToInt32(txtAL1.Text);

				z2 += Convert.ToInt32(txtAR2.Text);
				z2 += Convert.ToInt32(txtAB2.Text);
				z2 += Convert.ToInt32(txtAM2.Text);
				z2 += Convert.ToInt32(txtAC2.Text);
				z2 += Convert.ToInt32(txtAS2.Text);
				z2 += Convert.ToInt32(txtAE2.Text);
				z2 += Convert.ToInt32(txtAA2.Text);
				z2 += Convert.ToInt32(txtAK2.Text);
				z2 += Convert.ToInt32(txtAL2.Text);

				z3 += Convert.ToInt32(txtAR3.Text);
				z3 += Convert.ToInt32(txtAB3.Text);
				z3 += Convert.ToInt32(txtAM3.Text);
				z3 += Convert.ToInt32(txtAC3.Text);
				z3 += Convert.ToInt32(txtAS3.Text);
				z3 += Convert.ToInt32(txtAE3.Text);
				z3 += Convert.ToInt32(txtAA3.Text);
				z3 += Convert.ToInt32(txtAK3.Text);
				z3 += Convert.ToInt32(txtAL3.Text);

				z4 += Convert.ToInt32(txtDR.Text);
				z4 += Convert.ToInt32(txtDB.Text);
				z4 += Convert.ToInt32(txtDM.Text);
				z4 += Convert.ToInt32(txtDC.Text);
				z4 += Convert.ToInt32(txtDS.Text);
				z4 += Convert.ToInt32(txtDE.Text);
				z4 += Convert.ToInt32(txtDA.Text);
				z4 += Convert.ToInt32(txtDK.Text);
				z4 += Convert.ToInt32(txtDL.Text);

				z5 += Convert.ToInt32(txtPL.Text);
				z5 += Convert.ToInt32(txtSL.Text);
				z5 += Convert.ToInt32(txtWH.Text);
				z5 += Convert.ToInt32(txtRB.Text);
				z5 += Convert.ToInt32(txtSW.Text);
				z5 += Convert.ToInt32(txtWL.Text);


				int boss = 0;
				if (rbEB.Checked == true)
					boss = 2;
				if (rbST.Checked == true)
					boss = 1;
				if (rbCK.Checked == true)
					boss = 3;
				if (rbMG.Checked == true)
					boss = 4;
				if (rbDWW.Checked == true)
					boss = 5;
				if (boss > 0)
					z5++;


				lblAsize1.Text = z1.ToString();
				lblAsize2.Text = z2.ToString();
				lblAsize3.Text = z3.ToString();
				lblDsize.Text = z4.ToString();
				lblBsize.Text = z5.ToString();

				if (z1 > 200)
					lblAsize1.ForeColor = Color.Red;
				else
					lblAsize1.ForeColor = Color.Green;
				if (z2 > 200)
					lblAsize2.ForeColor = Color.Red;
				else
					lblAsize2.ForeColor = Color.Green;
				if (z3 > 200)
					lblAsize3.ForeColor = Color.Red;
				else
					lblAsize3.ForeColor = Color.Green;
				if (z4 > 200)
					lblDsize.ForeColor = Color.Red;
				else
					lblDsize.ForeColor = Color.Green;
			} catch (Exception) {

			}
		}

		private void btnConfigRename_Click(object sender, EventArgs e) {
			configRename();
		}



		private void btnConfigSafe_Click(object sender, EventArgs e) {
			configSafe();
		}


		#region Configuration
		private void configDelete() {
			if (ds.DataTable1.Rows.Count <= 1)
				return;
			if (MessageBox.Show("Willst Du wirklich die aktuell ausgewählte Konfiguration unwiderruflich löschen?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
				return;

			try {
				ds.DataTable1.Rows[cmbKonfiguration.SelectedIndex].Delete();
				cmbKonfiguration.SelectedIndex = 0;
				ds.WriteXml("./config.xml");
			} catch (Exception ex) {
				webbrowser(ex.Message);
			}
		}

		private void configRename() {
			frmInput df = new frmInput();
			df.DialogText = "Gib den neuen Konfigurationsname ein:";
			df.DialogTitel = "Konfiguration umbenennen";
			df.DialogDefaultValue = ds.DataTable1.Rows[cmbKonfiguration.SelectedIndex][ds.DataTable1.ConfigNameColumn.ColumnName].ToString();
			df.ShowDialog();
			if (df.Konfigurationsname == "")
				return;

			try {
				ds.DataTable1.Rows[cmbKonfiguration.SelectedIndex][ds.DataTable1.ConfigNameColumn] = df.Konfigurationsname;
				ds.WriteXml("./config.xml");
			} catch (Exception ex) {
				webbrowser(ex.Message);
			}
		}

		private void configSafe() {
			try {
				if (MessageBox.Show("Willst Du wirklich die aktuell ausgewählte Konfiguration überschreiben?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
					return;

				try {
					ds.WriteXml("./config.xml");
				} catch (Exception ex) { webbrowser(ex.Message); }
			} catch (Exception ex) {
				webbrowser(ex.Message);
			}
		}

		private void configAdd() {

			try {
				frmInput s = new frmInput();
				s.DialogText = "Vergib Deiner Schlachtkonfiguration einen Namen:";
				s.DialogTitel = "speichern";

				s.ShowDialog();
				if (s.Konfigurationsname == "")
					return;

				DataSet1.DataTable1Row row;
				row = ds.DataTable1.NewDataTable1Row();
				row.ConfigName = s.Konfigurationsname;

				row.Bandit = rbBandit.Checked;
				row.Player = rbPlayer.Checked;

				row.Attacker = txtAngreiferName.Text;
				row.DefenderName = txtDefenderName.Text;

				//Angreifer 1
				row.AR1 = Convert.ToInt16(txtAR1.Text);
				row.AB1 = Convert.ToInt16(txtAB1.Text);
				row.AM1 = Convert.ToInt16(txtAM1.Text);
				row.AC1 = Convert.ToInt16(txtAC1.Text);
				row.AL1 = Convert.ToInt16(txtAL1.Text);
				row.AS1 = Convert.ToInt16(txtAS1.Text);
				row.AE1 = Convert.ToInt16(txtAE1.Text);
				row.AA1 = Convert.ToInt16(txtAA1.Text);
				row.AK1 = Convert.ToInt16(txtAK1.Text);

				//Angreifer 2
				row.AR2 = Convert.ToInt16(txtAR2.Text);
				row.AB2 = Convert.ToInt16(txtAB2.Text);
				row.AM2 = Convert.ToInt16(txtAM2.Text);
				row.AC2 = Convert.ToInt16(txtAC2.Text);
				row.AL2 = Convert.ToInt16(txtAL2.Text);
				row.AS2 = Convert.ToInt16(txtAS2.Text);
				row.AE2 = Convert.ToInt16(txtAE2.Text);
				row.AA2 = Convert.ToInt16(txtAA2.Text);
				row.AK2 = Convert.ToInt16(txtAK2.Text);
				row.AG2 = chkG1.Checked;

				//Angreifer 3
				row.AR3 = Convert.ToInt16(txtAR3.Text);
				row.AB3 = Convert.ToInt16(txtAB3.Text);
				row.AM3 = Convert.ToInt16(txtAM3.Text);
				row.AC3 = Convert.ToInt16(txtAC3.Text);
				row.AL3 = Convert.ToInt16(txtAL3.Text);
				row.AS3 = Convert.ToInt16(txtAS3.Text);
				row.AE3 = Convert.ToInt16(txtAE3.Text);
				row.AA3 = Convert.ToInt16(txtAA3.Text);
				row.AK3 = Convert.ToInt16(txtAK3.Text);
				row.AG3 = chkG3.Checked;

				//Player
				row.DR = Convert.ToInt16(txtDR.Text);
				row.DB = Convert.ToInt16(txtDB.Text);
				row.DM = Convert.ToInt16(txtDM.Text);
				row.DC = Convert.ToInt16(txtDC.Text);
				row.DL = Convert.ToInt16(txtDL.Text);
				row.DS = Convert.ToInt16(txtDS.Text);
				row.DE = Convert.ToInt16(txtDE.Text);
				row.DA = Convert.ToInt16(txtDA.Text);
				row.DK = Convert.ToInt16(txtDK.Text);
				row.DG = chkDG.Checked;
				row.DT = chkDT.Checked;

				//Banditen
				row.BanditName = txtBanditName.Text;

				row.PL = Convert.ToInt16(txtPL.Text);
				row.SL = Convert.ToInt16(txtSL.Text);
				row.WH = Convert.ToInt16(txtWH.Text);
				row.RB = Convert.ToInt16(txtRB.Text);
				row.SW = Convert.ToInt16(txtSW.Text);
				row.WL = Convert.ToInt16(txtWL.Text);

				row.BT = chkBT.Checked;

				//Boss
				row.noBoss = rbKeinBoss.Checked;
				row.ST = rbST.Checked;
				row.EB = rbEB.Checked;
				row.CK = rbCK.Checked;
				row.MG = rbMG.Checked;
				row.DWW = rbDWW.Checked;

				ds.DataTable1.AddDataTable1Row(row);
				cmbKonfiguration.SelectedIndex = cmbKonfiguration.Items.Count - 1;
			} catch (Exception ex) {
				webbrowser(ex.Message);
			}
		}

		private void configDataSetLoad() {
			try {
				if (!System.IO.File.Exists("config.xml")) {
					newConfig();
				} else {
					ds.ReadXml("./config.xml");

					if (ds.Tables.Count != 2)
						newConfig();
					if (ds.DataTable2.Rows.Count != 1)
						newConfig();
					if (ds.DataTable2.Rows[0][ds.DataTable2.versionColumn.ColumnName].ToString() != datasetVersion)
						newConfig();

					ds.WriteXml("./config.xml");
				}

				bs.DataSource = ds.DataTable1;

				cmbKonfiguration.DataSource = ds.DataTable1.DefaultView;
				cmbKonfiguration.DisplayMember = ds.DataTable1.ConfigNameColumn.ColumnName;
				cmbKonfiguration.SelectedIndex = 0;

				this.rbBandit.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.BanditColumn.ColumnName, true));
				this.rbPlayer.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.PlayerColumn.ColumnName, true));

				this.txtAngreiferName.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AttackerColumn.ColumnName, true));
				this.txtDefenderName.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.DefenderNameColumn.ColumnName, true));
				this.txtBanditName.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.BanditNameColumn.ColumnName, true));

				//Attacker 1
				this.txtAR1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AR1Column.ColumnName, true));
				this.txtAB1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AB1Column.ColumnName, true));
				this.txtAM1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AM1Column.ColumnName, true));
				this.txtAC1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AC1Column.ColumnName, true));
				this.txtAS1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AS1Column.ColumnName, true));
				this.txtAE1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AE1Column.ColumnName, true));
				this.txtAL1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AL1Column.ColumnName, true));
				this.txtAA1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AA1Column.ColumnName, true));
				this.txtAK1.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AK1Column.ColumnName, true));
				//Attacker 2
				this.chkG2.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.AG2Column.ColumnName, true));
				this.txtAR2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AR2Column.ColumnName, true));
				this.txtAB2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AB2Column.ColumnName, true));
				this.txtAM2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AM2Column.ColumnName, true));
				this.txtAC2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AC2Column.ColumnName, true));
				this.txtAS2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AS2Column.ColumnName, true));
				this.txtAE2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AE2Column.ColumnName, true));
				this.txtAL2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AL2Column.ColumnName, true));
				this.txtAA2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AA2Column.ColumnName, true));
				this.txtAK2.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AK2Column.ColumnName, true));
				//Attacker 3
				this.chkG3.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.AG3Column.ColumnName, true));
				this.txtAR3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AR3Column.ColumnName, true));
				this.txtAB3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AB3Column.ColumnName, true));
				this.txtAM3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AM3Column.ColumnName, true));
				this.txtAC3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AC3Column.ColumnName, true));
				this.txtAS3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AS3Column.ColumnName, true));
				this.txtAE3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AE3Column.ColumnName, true));
				this.txtAL3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AL3Column.ColumnName, true));
				this.txtAA3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AA3Column.ColumnName, true));
				this.txtAK3.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AK3Column.ColumnName, true));
				//Defender - Player
				this.chkDG.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.DGColumn.ColumnName, true));
				this.txtDR.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AR3Column.ColumnName, true));
				this.txtDB.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AB3Column.ColumnName, true));
				this.txtDM.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AM3Column.ColumnName, true));
				this.txtDC.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AC3Column.ColumnName, true));
				this.txtDS.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AS3Column.ColumnName, true));
				this.txtDE.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AE3Column.ColumnName, true));
				this.txtDL.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AL3Column.ColumnName, true));
				this.txtDA.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AA3Column.ColumnName, true));
				this.txtDK.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.AK3Column.ColumnName, true));
				this.chkDT.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.DTColumn.ColumnName, true));
				//Defender - Bandit                
				this.txtPL.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.PLColumn.ColumnName, true));
				this.txtSL.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.SLColumn.ColumnName, true));
				this.txtWH.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.WHColumn.ColumnName, true));
				this.txtRB.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.RBColumn.ColumnName, true));
				this.txtSW.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.SWColumn.ColumnName, true));
				this.txtWL.DataBindings.Add(new Binding("Text", this.bs, ds.DataTable1.WLColumn.ColumnName, true));
				this.chkBT.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.BTColumn.ColumnName, true));

				this.rbKeinBoss.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.noBossColumn.ColumnName, true));
				this.rbST.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.STColumn.ColumnName, true));
				this.rbEB.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.EBColumn.ColumnName, true));
				this.rbCK.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.CKColumn.ColumnName, true));
				this.rbMG.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.MGColumn.ColumnName, true));
				this.rbDWW.DataBindings.Add(new Binding("Checked", this.bs, ds.DataTable1.DWWColumn.ColumnName, true));

			} catch (Exception ex) {
				webbrowser(ex.Message);
			}
		}

		private void newConfig() {
			if (MessageBox.Show("Du hast nicht die aktuelle \"config.xml\"\r\n\r\nSoll eine neue angelegt werden? \r\n(die alte Datei wird gelöscht)", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
				return;
			ds.Clear();

			System.IO.File.Delete("./config.xml");

			DataSet1.DataTable1Row row;
			row = ds.DataTable1.NewDataTable1Row();
			ds.DataTable1.AddDataTable1Row(row);

			DataSet1.DataTable2Row rowVersion;
			rowVersion = ds.DataTable2.NewDataTable2Row();
			rowVersion.version = datasetVersion;
			ds.DataTable2.AddDataTable2Row(rowVersion);

			ds.WriteXml("./config.xml");
		}

		#endregion

		private void cmbKonfiguration_SelectedIndexChanged(object sender, EventArgs e) {
			this.bs.Position = this.cmbKonfiguration.SelectedIndex;
		}


		private void btnConfigLoad_Click(object sender, EventArgs e) {
			configDataSetLoad();
		}

		private void rbPlayer_CheckedChanged_1(object sender, EventArgs e) {
			if (rbPlayer.Checked == true) {
				gbPlayer.Visible = true;
				gbBandit.Visible = false;
			} else {
				gbPlayer.Visible = false;
				gbBandit.Visible = true;
			}
		}


		private void rbKeinBoss_CheckedChanged(object sender, EventArgs e) {
			if (rbKeinBoss.Checked == true) {
				zähleArmee(sender, e);
			}
		}

		private void rbEB_CheckedChanged(object sender, EventArgs e) {
			if (rbEB.Checked == true) {
				zähleArmee(sender, e);
			}
		}

		private void rbST_CheckedChanged(object sender, EventArgs e) {
			if (rbST.Checked == true) {
				zähleArmee(sender, e);
			}
		}

		private void rbDWW_CheckedChanged(object sender, EventArgs e) {
			if (rbDWW.Checked == true) {
				zähleArmee(sender, e);
			}
		}

		private void rbMG_CheckedChanged(object sender, EventArgs e) {
			if (rbMG.Checked == true) {
				zähleArmee(sender, e);
			}
		}

		private void rbCK_CheckedChanged(object sender, EventArgs e) {
			if (rbCK.Checked == true) {
				zähleArmee(sender, e);
			}
		}


		private void checkTxtToInt(object sender, EventArgs e) {
			int i = 0;
			if (int.TryParse(((MaskedTextBox)sender).Text, out i) == false)
				((MaskedTextBox)sender).Text = i.ToString();

			zähleArmee(sender, e);
		}

		private void chkSimulationen_CheckedChanged(object sender, EventArgs e) {
			txtAnzSimulationen.Enabled = chkSimulationen.Checked;
		}


	}

}
