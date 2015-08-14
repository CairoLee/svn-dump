using System;

namespace GodLesZ.Library.Xrel {

    [AttributeUsage(AttributeTargets.Field)]
    public class ValueAttribute : Attribute {

        public string Value {
            get;
            set;
        }

        public ValueAttribute(string value) {
            Value = value;
        }

        public override string ToString() {
            return Value;
        }

    }

}