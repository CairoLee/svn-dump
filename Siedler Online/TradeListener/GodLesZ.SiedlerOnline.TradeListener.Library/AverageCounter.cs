using System;
using System.Xml.Serialization;

namespace GodLesZ.SiedlerOnline.TradeListener.Library {

	[XmlRoot("AverageCounter")]
	public class AverageCounter {

		public int Count {
			get;
			set;
		}

		public DateTime Created {
			get;
			set;
		}

		public DateTime LastUpdate {
			get;
			set;
		}

		public double LowerBoundExclusive {
			get;
			set;
		}

		public double Max {
			get;
			set;
		}

		public DateTime MaxTime {
			get;
			set;
		}

		public double Min {
			get;
			set;
		}

		public DateTime MinTime {
			get;
			set;
		}

		public EResource Resource {
			get;
			set;
		}

		public EResource ResourceDemanded {
			get;
			set;
		}

		public double UpperBoundExclusive {
			get;
			set;
		}

		public double Value {
			get;
			set;
		}

		public string ValueFormatted {
			get { return FormatDouble(Value); }
		}


		public AverageCounter()
			: this(EResource.Beer, EResource.Beer) {
		}

		public AverageCounter(EResource res, EResource resDemanded) {
			Resource = res;
			ResourceDemanded = resDemanded;
			Value = 0.0;
			Count = 0;
			Created = DateTime.Now;
			LastUpdate = DateTime.Now;
			Min = double.NaN;
			Max = double.NaN;
			MinTime = DateTime.Now;
			MaxTime = DateTime.Now;
		}


		public double Add(double NewValue, double UpperBound, double LowerBound, double HistoricalFactor) {
			// Calc new max
			if (double.IsNaN(Max) || NewValue >= Max || NewValue >= UpperBound || Max >= UpperBound) {
				if (NewValue >= UpperBound) {
					NewValue = UpperBound - double.Epsilon;
				}

				Max = NewValue;
				MaxTime = DateTime.Now;
			}

			// Calc new min
			if (double.IsNaN(Min) || NewValue <= Min || NewValue <= LowerBound || Min <= LowerBound) {
				if (NewValue <= LowerBound) {
					NewValue = LowerBound + double.Epsilon;
				}

				Min = NewValue;
				MinTime = DateTime.Now;
			}

			// Calc new avg
			Value = (((NewValue - ((NewValue - Value) * HistoricalFactor)) * Count) + NewValue) / ((double)(Count + 1));
			// Inc counter and update time
			Count++;
			LastUpdate = DateTime.Now;

			return Value;
		}


		public static string GetKey(EResource res, EResource resDemanded) {
			// Build a key from both resources
			// This ensures a unique entry for each resource trade
			string key = string.Format("{0};{1}", res.ToString(), resDemanded.ToString());
			return key;
		}

		public static string FormatDouble(double value) {
			return Math.Round(value, 2).ToString("0.00");
		}

	}

}

