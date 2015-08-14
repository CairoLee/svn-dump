using System;
using System.Collections.Generic;
using System.Text;

namespace MarketTool.Library {

	public class Lapi {
		public static int[] AmountBase = new int[ 8 ] { 0, 3, 5, 7, 10, 20, 30, 45 };
		public static int[] AmountLP = new int[ 8 ] { 0, 100, 140, 180, 220, 360, 500, 750 };
		public static int[] AmountMP = new int[ 8 ] { 0, 120, 160, 200, 240, 400, 600, 700 };
		public static int[] AmountAP = new int[ 8 ] { 0, 100, 140, 180, 220, 360, 500, 750 };
		public static int[] AmountDEF = new int[ 8 ] { 0, 2, 5, 8, 16, 24, 32, 40 };
		public static int[] AmountRES = new int[ 8 ] { 0, 10, 20, 30, 50, 75, 100, 150 };
		public static int[] AmountHALT = new int[ 8 ] { 0, 200, 400, 800, 1200, 1500, 2000, 3000 };
		public static int[] AmountMaxANG = new int[ 8 ] { 0, 2, 5, 8, 16, 24, 32, 40 };
		public static int[] AmountANG = new int[ 8 ] { 0, 2, 5, 8, 16, 24, 32, 40 };
		public static int[] AmountVOLLENDUNG = new int[ 8 ] { 0, 1, -1, 7, -1, -1, -1, -1 };

		private ELapi mType;
		private int mLevel;

		public ELapi Type {
			get { return mType; }
		}

		public int Level {
			get { return mLevel; }
		}

		public string Name {
			get { return ToName(); }
		}

		public int ImageIndex {
			get { return ToImageIndex(); }
		}


		public Lapi( ELapi Type, int Level ) {
			mType = Type;
			mLevel = Level;
		}




		public string ToName() {
			switch( this.Type ) {

				default:
					return "UNKNOWN TYPE " + this.Type;

				case ELapi.STR:
					return "Stärke St." + this.Level;
				case ELapi.INT:
					return "Intelligenz St." + this.Level;
				case ELapi.WEI:
					return "Weisheit St." + this.Level;
				case ELapi.ABW:
					return "Abwehr St." + this.Level;
				case ELapi.GES:
					return "Geschick St." + this.Level;
				case ELapi.GLÜ:
					return "Glück St." + this.Level;

				case ELapi.LP:
					return "Leben St." + this.Level;
				case ELapi.MP:
					return "Mana St." + this.Level;
				case ELapi.AP:
					return "AP St." + this.Level;

				case ELapi.VER:
					return "Verteidigung St." + this.Level;
				case ELapi.ANG:
					return "Angriff St." + this.Level;
				case ELapi.HALT:
					return "Haltbarkeit St." + this.Level;
				case ELapi.GEIST:
					return "Geist St." + this.Level;
				case ELapi.MaxANG:
					return "Max Angriff St." + this.Level;

				case ELapi.DUALSTR:
					return "Dual-Stärke V" + this.Level;
				case ELapi.DUALINT:
					return "Dual-Intelligenz V" + this.Level;
				case ELapi.DUALWEI:
					return "Dual-Weisheit V" + this.Level;
				case ELapi.DUALABW:
					return "Dual-Abwehr V" + this.Level;
				case ELapi.DUALGES:
					return "Dual-Geschick V" + this.Level;
				case ELapi.DUALGLÜ:
					return "Dual-Glück St." + this.Level;

				case ELapi.SCHMUCKSTR:
					return this.Level == 0 ? "Kampfglück" : "Kampflust";
				case ELapi.SCHMUCKINT:
					return this.Level == 0 ? "Spruch" : "Heilig";
				case ELapi.SCHMUCKWEI:
					return this.Level == 0 ? "Unscheinbar" : "Heiligenkraft";
				case ELapi.SCHMUCKABW:
					return this.Level == 0 ? "Kampfrausch" : "Zauberdauer";
				case ELapi.SCHMUCKGES:
					return this.Level == 0 ? "Glückspilz" : "Zielgerichtheit";
				case ELapi.SCHMUCKGLÜ:
					return this.Level == 0 ? "Berserkerwut" : "Treffsicherheit";

				case ELapi.VOLLENDUNG:
					return "Vollendung St." + this.Level;
				case ELapi.BLITZ:
					return "Blitz St." + this.Level;
				case ELapi.FLINK:
					return "Flinkheit St." + this.Level;

				case ELapi.ELEMENTANG:
					switch( this.Level ) {
						default:
							return "UNKNOWN ANGELE " + this.Level;
						case 0:
							return "Flamme";
						case 1:
							return "Wind";
						case 2:
							return "Erde";
						case 3:
							return "Wasser";
					}
				case ELapi.ELEMENTDEF:
					switch( this.Level ) {
						default:
							return "UNKNOWN DEFELE " + this.Level;
						case 0:
							return "Feuerglanz";
						case 1:
							return "Windglanz";
						case 2:
							return "Erdeglanz";
						case 3:
							return "Wasserglanz";
					}

				case ELapi.DEBUFF1:
					switch( this.Level ) {
						default:
							return "UNKNOWN DEBUFF1 " + this.Level;
						case 0:
							return "Manabrand";
						case 1:
							return "Infektion";
						case 2:
							return "Nervengift";
						case 3:
							return "Verkrüppelung";
						case 4:
							return "Trägheit";
						case 5:
							return "Aussetzer";
						case 6:
							return "Betäubung";
						case 7:
							return "Schwund";
						case 8:
							return "Durchdringen";
						case 9:
							return "Dunkelheit";
						case 10:
							return "Stille";
						case 11:
							return "Koma";
						case 12:
							return "Verfehlung";
					}

				case ELapi.DEBUFF2:
					switch( this.Level ) {
						default:
							return "UNKNOWN DEBUFF2 " + this.Level;
						case 0:
							return "Schlaf";
						case 1:
							return "Betäubung";
						case 2:
							return "Stille";
						case 3:
							return "Dunkelheit";
						case 4:
							return "Aussetzer";
						case 5:
							return "Trägheit";
						case 6:
							return "Verdammung";
						case 7:
							return "Furcht";
						case 8:
							return "Gift";
						case 9:
							return "Krankheit";
						case 10:
							return "Wahn";
						case 11:
							return "Unglück";
						case 12:
							return "Blindheit";
						case 13:
							return "Aussterben";
						case 14:
							return "Tod";
					}

				case ELapi.ANTIDEBUFF:
					switch( this.Level ) {
						default:
							return "UNKNOWN ANTIDEBUFF " + this.Level;
						case 0:
							return "Anti Schlaf";
						case 1:
							return "Anti Betäubung";
						case 2:
							return "Anti Stille";
						case 3:
							return "Anti Dunkelheit";
						case 4:
							return "Anti Aussetzer";
						case 5:
							return "Anti Trägheit";
						case 6:
							return "Anti Verdammung";
						case 7:
							return "Anti Furcht";
						case 8:
							return "Anti Gift";
						case 9:
							return "Anti Krankheit";
						case 10:
							return "Anti Wahn";
						case 11:
							return "Anti Unglück";
						case 12:
							return "Anti Blindheit";
						case 13:
							return "Anti Aussterben";
						case 14:
							return "Anti Tod";
					}

			}

		}

		public string ToEffect() {
			switch( this.Type ) {

				default:
					return "UNKNOWN TYPE " + this.Type;

				case ELapi.STR:
					return "+" + AmountBase[ this.Level ] + " STR";
				case ELapi.INT:
					return "+" + AmountBase[ this.Level ] + " INT";
				case ELapi.WEI:
					return "+" + AmountBase[ this.Level ] + " WEI";
				case ELapi.ABW:
					return "+" + AmountBase[ this.Level ] + " ABW";
				case ELapi.GES:
					return "+" + AmountBase[ this.Level ] + " GES";
				case ELapi.GLÜ:
					return "+" + AmountBase[ this.Level ] + " GLÜ";

				case ELapi.LP:
					return "+" + AmountLP[ this.Level ] + " LP";
				case ELapi.MP:
					return "+" + AmountMP[ this.Level ] + " MP";
				case ELapi.AP:
					return "+" + AmountAP[ this.Level ] + " AP";

				case ELapi.VER:
					return "+" + AmountDEF[ this.Level ] + " DEF";
				case ELapi.ANG:
					return "+" + AmountANG[ this.Level ] + " ANG";
				case ELapi.HALT:
					return "+" + AmountHALT[ this.Level ] + " Haltbarkeit";
				case ELapi.GEIST:
					return "+" + AmountRES[ this.Level ] + " Resistenz";
				case ELapi.MaxANG:
					return "+" + AmountANG[ this.Level ] + " MaxANG";

				case ELapi.DUALSTR:
					switch( this.Level ) {
						default:
							return "UNKNOWN DUAL " + this.Level;
						case 1:
							return "+7 STR, +8 GES";
						case 2:
							return "+7 STR, +12 DEF";
						case 3:
							return "+7 STR, +175 LP";
						case 4:
							return "+7 STR, +175 AP";
					}
				case ELapi.DUALINT:
					switch( this.Level ) {
						default:
							return "UNKNOWN DUAL " + this.Level;
						case 1:
							return "+7 INT, +8 WEI";
						case 2:
							return "+7 INT, +175 LP";
						case 3:
							return "+7 INT, +8 ABW";
						case 4:
							return "+7 INT, +195 MP";
					}
				case ELapi.DUALWEI:
					switch( this.Level ) {
						default:
							return "UNKNOWN DUAL " + this.Level;
						case 1:
							return "+7 WEI, +175 LP";
						case 2:
							return "+7 WEI, +195 MP";
						case 3:
							return "+7 WEI, +12 DEF";
						case 4:
							return "+7 WEI, +36 Resi";
					}
				case ELapi.DUALABW:
					switch( this.Level ) {
						default:
							return "UNKNOWN DUAL " + this.Level;
						case 1:
							return "+7 ABW, +12 DEF";
						case 2:
							return "+7 ABW, +11 MaxANG";
						case 3:
							return "+7 ABW, +36 Resi";
						case 4:
							return "+7 ABW, +175 AP";
					}
				case ELapi.DUALGES:
					switch( this.Level ) {
						default:
							return "UNKNOWN DUAL " + this.Level;
						case 1:
							return "+7 GES, +12 DEF";
						case 2:
							return "+7 GES, +8 GLÜ";
						case 3:
							return "+7 GES, +175 AP";
						case 4:
							return "+7 GES, +175 LP";
					}
				case ELapi.DUALGLÜ:
					switch( this.Level ) {
						default:
							return "UNKNOWN DUAL " + this.Level;
						case 1:
							return "+7 GLÜ, +8 STR";
						case 2:
							return "+7 GLÜ, +11 ANG";
						case 3:
							return "+7 GLÜ, +175 AP";
						case 4:
							return "+7 GLÜ, +36 Resi";
					}

				case ELapi.SCHMUCKSTR:
					return "+7 STR, +6 " + ( this.Level == 0 ? "GLÜ" : "GES" );
				case ELapi.SCHMUCKINT:
					return "+7 INT, +6 " + ( this.Level == 0 ? "ABW" : "WEI" );
				case ELapi.SCHMUCKWEI:
					return "+7 WEI, +6 " + ( this.Level == 0 ? "INT" : "ABW" );
				case ELapi.SCHMUCKABW:
					return "+7 ABW, +6 " + ( this.Level == 0 ? "STR" : "INT" );
				case ELapi.SCHMUCKGES:
					return "+7 GES, +6 " + ( this.Level == 0 ? "GLÜ" : "WEI" );
				case ELapi.SCHMUCKGLÜ:
					return "+7 GLÜ, +6 " + ( this.Level == 0 ? "STR" : "GES" );

				case ELapi.VOLLENDUNG:
					return "+" + AmountVOLLENDUNG[ this.Level ] + " auf jedes Attrib.";
				case ELapi.BLITZ:
					return "Angriffsgeschw. +" + ( this.Level == 1 ? "1 Stufe" : "2 Stufen" );
				case ELapi.FLINK:
					return "Laufgeschw. +" + ( this.Level == 1 ? "1 Stufe" : "2 Stufen" );

				case ELapi.ELEMENTANG:
					switch( this.Level ) {
						default:
							return "UNKNOWN ANGELE " + this.Level;
						case 0:
							return "Angriff Feuer-elementar";
						case 1:
							return "Angriff Wind-elementar";
						case 2:
							return "Angriff Erde-elementar";
						case 3:
							return "Angriff Wasser-elementar";
					}
				case ELapi.ELEMENTDEF:
					switch( this.Level ) {
						default:
							return "UNKNOWN DEFELE " + this.Level;
						case 0:
							return "Verteidigung Feuer-elementar";
						case 1:
							return "Verteidigung Wind-elementar";
						case 2:
							return "Verteidigung Erde-elementar";
						case 3:
							return "Verteidigung Wasser-elementar";
					}

				case ELapi.DEBUFF1:
					switch( this.Level ) {
						default:
							return "UNKNOWN DEBUFF1 " + this.Level;
						case 0:
							return "Manabrand";
						case 1:
							return "Infektion";
						case 2:
							return "Nervengift";
						case 3:
							return "Verkrüppelung";
						case 4:
							return "Trägheit";
						case 5:
							return "Aussetzer";
						case 6:
							return "Betäubung";
						case 7:
							return "Schwund";
						case 8:
							return "Durchdringen";
						case 9:
							return "Dunkelheit";
						case 10:
							return "Stille";
						case 11:
							return "Koma";
						case 12:
							return "Verfehlung";
					}

				case ELapi.DEBUFF2:
					switch( this.Level ) {
						default:
							return "UNKNOWN DEBUFF2 " + this.Level;
						case 0:
							return "Schlaf";
						case 1:
							return "Betäubung";
						case 2:
							return "Stille";
						case 3:
							return "Dunkelheit";
						case 4:
							return "Aussetzer";
						case 5:
							return "Trägheit";
						case 6:
							return "Verdammung";
						case 7:
							return "Furcht";
						case 8:
							return "Gift";
						case 9:
							return "Krankheit";
						case 10:
							return "Wahn";
						case 11:
							return "Unglück";
						case 12:
							return "Blindheit";
						case 13:
							return "Aussterben";
						case 14:
							return "Tod";
					}

				case ELapi.ANTIDEBUFF:
					switch( this.Level ) {
						default:
							return "UNKNOWN ANTIDEBUFF " + this.Level;
						case 0:
							return "Anti Schlaf";
						case 1:
							return "Anti Betäubung";
						case 2:
							return "Anti Stille";
						case 3:
							return "Anti Dunkelheit";
						case 4:
							return "Anti Aussetzer";
						case 5:
							return "Anti Trägheit";
						case 6:
							return "Anti Verdammung";
						case 7:
							return "Anti Furcht";
						case 8:
							return "Anti Gift";
						case 9:
							return "Anti Krankheit";
						case 10:
							return "Anti Wahn";
						case 11:
							return "Anti Unglück";
						case 12:
							return "Anti Blindheit";
						case 13:
							return "Anti Aussterben";
						case 14:
							return "Anti Tod";
					}

			}

		}

		public int ToImageIndex() {
			switch( this.Type ) {

				default:
					return -1;

				case ELapi.STR:
					return 0;
				case ELapi.INT:
					return 2;
				case ELapi.WEI:
					return 3;
				case ELapi.ABW:
					return 1;
				case ELapi.GES:
					return 4;
				case ELapi.GLÜ:
					return 5;

				case ELapi.LP:
					return 6;
				case ELapi.MP:
					return 8;
				case ELapi.AP:
					return 7;

				case ELapi.VER:
					return 17;
				case ELapi.ANG:
					return 15;
				case ELapi.HALT:
					return 14;
				case ELapi.GEIST:
					return 18;
				case ELapi.MaxANG:
					return 16;

				case ELapi.DUALSTR:
					return 0;
				case ELapi.DUALINT:
					return 2;
				case ELapi.DUALWEI:
					return 3;
				case ELapi.DUALABW:
					return 1;
				case ELapi.DUALGES:
					return 4;
				case ELapi.DUALGLÜ:
					return 5;

				case ELapi.SCHMUCKSTR:
					return 0;
				case ELapi.SCHMUCKINT:
					return 2;
				case ELapi.SCHMUCKWEI:
					return 3;
				case ELapi.SCHMUCKABW:
					return 1;
				case ELapi.SCHMUCKGES:
					return 4;
				case ELapi.SCHMUCKGLÜ:
					return 5;

				case ELapi.VOLLENDUNG:
					return 26;
				case ELapi.BLITZ:
					return 19;
				case ELapi.FLINK:
					return 19;

				case ELapi.ELEMENTANG:
					switch( this.Level ) {
						default:
							return -1;
						case 0:
							return 42;
						case 1:
							return 45;
						case 2:
							return 44;
						case 3:
							return 43;
					}
				case ELapi.ELEMENTDEF:
					switch( this.Level ) {
						default:
							return -1;
						case 0:
							return 42;
						case 1:
							return 45;
						case 2:
							return 44;
						case 3:
							return 43;
					}

				case ELapi.DEBUFF1:
					if( this.Level < 0 || this.Level > 12 )
						return -1;
					return 55;

				case ELapi.DEBUFF2:
					if( this.Level < 0 || this.Level > 14 )
						return -1;
					return 53;

				case ELapi.ANTIDEBUFF:
					if( this.Level < 0 || this.Level > 14 )
						return -1;
					return 54;


			}

		}

	}




}
