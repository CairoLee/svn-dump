namespace GodLesZ.Library.Xrel.Data {

    public class ReleaseInfo {

        public string Id {
            get;
            set;
        }

        public string Dirname {
            get;
            set;
        }

        public string Link {
            get;
            set;
        }

        public int Time {
            get;
            set;
        }

        public string GroupName {
            get;
            set;
        }

        public long SizeNumber {
            get;
            set;
        }

        public string SizeUnit {
            get;
            set;
        }

        public string Size {
            get { return string.Format("{0} {1}", SizeNumber, SizeUnit); }
        }

        public string VideoType {
            get;
            set;
        }

        public string AudioType {
            get;
            set;
        }

        
        public string ExtendedType {
            get;
            set;
        }

        public string ExtendedId {
            get;
            set;
        }

        public string ExtendedTitle {
            get;
            set;
        }

        public string ExtendedLink {
            get;
            set;
        }

        public float ExtendedRating {
            get;
            set;
        }

    }

}