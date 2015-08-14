using System;
using System.Collections.Generic;
using GodLesZ.Library.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Library;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class ChatListView : FilterableFastListView {

		public ChatListView()
			: base() {
			Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				new OLVColumn {
					AspectName = "Timestamp",
					IsEditable = false,
					Name = "colDate",
					Text = "Date",
					Width = 100,
					AspectToStringConverter = delegate(object x) {
						return FormatDate((DateTime)x);
					}
				},
				new OLVColumn {
					AspectName = "SenderNameFormatted",
					IsEditable = false,
					Name = "colFrom",
					Text = "From",
					Width = 120
				},
				new OLVColumn {
					AspectName = "MessageBody",
					IsEditable = false,
					Name = "colMessage",
					Text = "Message",
					Width = 390,
					FillsFreeSpace = true
				},
            });
		}


		public void AddMessages(DsoChatPacket packet) {
			AddMessages(packet.Messages);
		}

		public void AddMessages(List<DsoChatPacketMessage> messages) {
			foreach (var msg in messages) {
				AddMessage(msg);
			}
		}

		public void AddMessage(DsoChatPacketMessage msg) {
			if (string.IsNullOrEmpty(msg.MessageBody) || msg.MessageDetails == null) {
				return;
			}

			AddObject(msg);
		}

	}

}
