
using System;
using System.Collections;
using System.Text;
using GodLesZ.Library.Amf.Util;
// Import log4net classes.
using log4net;

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class Sequence : CollectionBase {
		private static readonly ILog log = LogManager.GetLogger(typeof(Sequence));

		int _id;
		object[] _parameters;
		Hashtable _subcribers;

		public Sequence() {
			_subcribers = new Hashtable();
		}

		public int Id {
			get { return _id; }
			set { _id = value; }
		}

		public int Size {
			get { return this.Count; }
		}

		public int Add(Identity identity) {
			return this.InnerList.Add(identity);
		}

		public void Insert(int index, Identity identity) {
			this.InnerList.Insert(index, identity);
		}

		public Identity this[int index] {
			get { return this.InnerList[index] as Identity; }
		}

		public bool Contains(Identity identity) {
			return this.InnerList.Contains(identity);
		}

		public void Remove(Identity identity) {
			this.InnerList.Remove(identity);
		}

		public int IndexOf(Identity identity) {
			return this.InnerList.IndexOf(identity);
		}

		public object[] Parameters {
			get { return _parameters; }
			set { _parameters = value; }
		}

		public void AddSubscriber(string clientId) {
			lock (_subcribers) {
				if (log != null && log.IsDebugEnabled)
					log.Debug(__Res.GetString(__Res.Sequence_AddSubscriber, clientId, _id));
				if (!clientId.StartsWith("srv:"))
					_subcribers[clientId] = clientId;
			}
		}

		public void RemoveSubscriber(string clientId) {
			lock (_subcribers) {
				if (log != null && log.IsDebugEnabled)
					log.Debug(__Res.GetString(__Res.Sequence_RemoveSubscriber, clientId, _id));
				if (_subcribers.Contains(clientId))
					_subcribers.Remove(clientId);
			}
		}

		public int SubscriberCount {
			get {
				lock (_subcribers) {
					return _subcribers.Count;
				}
			}
		}

		internal void Dump(DumpContext dumpContext) {
			dumpContext.AppendLine("Sequence Id = " + _id.ToString() + " Count = " + this.Count.ToString() + " Subscribers = " + this.SubscriberCount.ToString());
			dumpContext.Indent();
			int count = Math.Min(this.Count, 20);
			StringBuilder sb = new StringBuilder();
			sb.Append("[ ");
			for (int i = 0; i < count; i++) {
				if (i > 0)
					sb.Append(", ");
				Identity identity = this[i];
				sb.Append("[");
				foreach (DictionaryEntry entry in identity) {
					sb.Append(identity[entry.Key].ToString());
				}
				sb.Append("]");
			}
			sb.Append(" ]");
			dumpContext.AppendLine(sb.ToString());
			dumpContext.Unindent();
		}
	}
}
