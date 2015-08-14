using System;
using System.Collections.Generic;

namespace MarketTool.Library {

	public class ITemplate {
		public int cmbType = 0;
		public int cmbItemIcon = 0;
		public int cmbQuality = 0;
		public int cmbASPD = 3;
		public ELapi LapisType = ELapi.STR;
		public int LapisLevel = 0;
		public int cmbLapisa = 0;
		public decimal numEnchant = 0;

		public int cmbSockel1 = 0;
		public int cmbSockel2 = 0;
		public int cmbSockel3 = 0;
		public int cmbSockel4 = 0;
		public int cmbSockel5 = 0;
		public int cmbSockel6 = 0;

		public int txtGold = 0;

		public string txtName = "";
		public string txtANG1 = "0";
		public string txtANG2 = "0";
		public string txtHaltbarkeit = "0";
		public string txtLP = "0";
		public string txtMP = "0";
		public string txtAP = "0";
		public string txtGES = "0";
		public string txtGLÜ = "0";
		public string txtSTR = "0";
		public string txtWEI = "0";
		public string txtINT = "0";
		public string txtABW = "0";
		public string txtLPEP4 = "0";
		public string txtMPEP4 = "0";
		public string txtAPEP4 = "0";
		public string txtGESEP4 = "0";
		public string txtGLÜEP4 = "0";
		public string txtSTREP4 = "0";
		public string txtWEIEP4 = "0";
		public string txtINTEP4 = "0";
		public string txtABWEP4 = "0";
		public string txtResistenz = "0";
		public string txtSeller = "";


		public ITemplate() {
		}


		/// <summary>
		/// &lt;if Equip{Quality}&gt; Itemname &lt;if Equip{[Enchant]}&gt;
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			string name = "";
			EItemType type = (EItemType)cmbType;

			if( type == EItemType.Waffe || type == EItemType.Rüstung )
				name += ( (EQuality)cmbQuality ).ToString() + " ";
			name += txtName;
			if( type == EItemType.Waffe || type == EItemType.Rüstung ) {
				name += " [" + (int)numEnchant + "]";
				//name += " - [" + cmbSockel1 + "," + cmbSockel2 + "," + cmbSockel3 + "," + cmbSockel4 + "," + cmbSockel5 + "," + cmbSockel6 + "]";
			}

			return name.MakeValidFilename();
		}

		/// <summary>
		/// &lt;if Equip{Quality}&gt; Itemname &lt;if Equip{[Enchant]}&gt;
		/// </summary>
		/// <returns></returns>
		public string ToName() {
			return ToString();
		}

		/// <summary>
		/// Builds a unique MD5-hashed name, based on item's stats
		/// </summary>
		/// <returns></returns>
		public string ToFilename() {
			string name = "";

			name += txtName;
			name += " [" + ( (EQuality)cmbQuality ).ToString() + "]";
			name += " [" + (int)numEnchant + "]";
			name += " [" + cmbSockel1 + "," + cmbSockel2 + "," + cmbSockel3 + "," + cmbSockel4 + "," + cmbSockel5 + "," + cmbSockel6 + "]";

			name += cmbType;
			name += cmbItemIcon;
			name += cmbASPD;
			name += LapisType;
			name += LapisLevel;
			name += cmbLapisa;
			name += txtGold;
			name += txtANG1;
			name += txtANG2;
			name += txtHaltbarkeit;
			name += txtLP;
			name += txtMP;
			name += txtAP;
			name += txtGES;
			name += txtGLÜ;
			name += txtSTR;
			name += txtWEI;
			name += txtINT;
			name += txtABW;
			name += txtLPEP4;
			name += txtMPEP4;
			name += txtAPEP4;
			name += txtGESEP4;
			name += txtGLÜEP4;
			name += txtSTREP4;
			name += txtWEIEP4;
			name += txtINTEP4;
			name += txtABWEP4;
			name += txtResistenz;
			name += txtSeller;

			return GetMD5Hash( name );
		}


		private string GetMD5Hash( string TextToHash ) {
			System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] textToHash = System.Text.Encoding.Default.GetBytes( TextToHash );
			byte[] result = md5.ComputeHash( textToHash );

			return System.BitConverter.ToString( result );
		}

	}


}
