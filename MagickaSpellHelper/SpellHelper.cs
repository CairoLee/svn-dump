using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MagickaSpellHelper {

    [Serializable]
    public class SpellHelper {
        private readonly List<Bind> BindedValue = new List<Bind>();
        public Keys[] BaseValue;

        public List<Bind> Binding {
            get { return BindedValue; }
        }

        public static SpellHelper Load(string Filename) {
            var fs = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            return Load(fs);
        }

        public static SpellHelper Load(Stream s, bool CloseStream = true) {
            var bf = new BinaryFormatter();
            var sh = bf.Deserialize(s) as SpellHelper;
            if (CloseStream) {
                s.Close();
            }
            return sh;
        }

        public void Save(Stream s) {
            var bf = new BinaryFormatter();
            bf.Serialize(s, this);
            s.Close();
        }

        public void Save(String Filename) {
            var fs = new FileStream(Filename, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            Save(fs);
        }

    }

    [Serializable]
    public class Bind {
        internal Keys BindedKey;
        internal int[] BindedValue = new int[10];

        public Bind() {
            for (int i = 0; i < 10; i++) {
                BindedValue[i] = -1;
            }
        }
    }

}