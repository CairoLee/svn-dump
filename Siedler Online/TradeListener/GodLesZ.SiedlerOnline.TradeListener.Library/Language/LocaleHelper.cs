using System.Drawing;
using System.Globalization;
using System.Resources;
using GodLesZ.Library;

namespace GodLesZ.SiedlerOnline.TradeListener.Library.Language {

	public class LocaleHelper {
		private ResourceManager mResLocale;
		private ResourceManager mRes;
		private CultureInfo mCulture;

		public ELanguage Language {
			get;
			protected set;
		}

		public string this[string index] {
			get { return GetString(index); }
		}


		public LocaleHelper(ELanguage lang, ResourceManager locales, ResourceManager resources, CultureInfo culture) {
			Language = lang;

			mResLocale = locales;
			mRes = resources;
			mCulture = culture;
		}


		public string GetString(string index) {
			return mResLocale.GetString(index, mCulture);
		}

		public Bitmap GetImage(string index) {
			return (Bitmap)mRes.GetObject(index, mCulture);
		}

	}

}
