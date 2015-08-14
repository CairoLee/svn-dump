using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shaiya.Extended.Server.Network;

namespace Shaiya.Extended.Server.Objects {

	public delegate void ItemOnUseScriptHandler( NetState Player, BaseItem Item );

	public partial class BaseItem : SerialObject {
		private string mName;
		private object[] mScriptArgs;
		private ItemScriptList mScriptList = new ItemScriptList();

		public object[] ScriptArgs {
			get { return mScriptArgs; }
			set { mScriptArgs = value; }
		}
		public string Name {
			get { return mName; }
			set { mName = value; }
		}



		public BaseItem() {
			Serial = Serial.NewItem;
			mName = string.Empty;
		}

		public BaseItem( Shaiya.Extended.Server.MySql.ResultRow Row ) {
			Serial = new Serial( Row[ "ID" ].GetInt32(), ESerialType.Item );
			mName = Row[ "Name" ].ToString();
		}



		public void OnUseScript( NetState Player ) {
			mScriptList.OnUseScript( Player, this );
		}


		public void SetOnUseScript( ItemOnUseScriptHandler OnUseDelegate, params object[] ItemArgs ) {
			mScriptList.Add( OnUseDelegate, ItemArgs );
		}
		public void SetOnUseScript( ItemOnUseScriptHandler OnUseDelegate, object ItemArg ) {
			SetOnUseScript( OnUseDelegate, ItemArg );
		}

	}


	public class ItemScriptList {
		private List<ItemOnUseScriptHandler> mHandler = new List<ItemOnUseScriptHandler>();
		private List<object[]> mArguments = new List<object[]>();


		public void Add( ItemOnUseScriptHandler Handler, object[] Args ) {
			mHandler.Add( Handler );
			mArguments.Add( Args );
		}

		public void OnUseScript( NetState Player, BaseItem Item ) {

			for( int i = 0; i < mHandler.Count; i++ ) {
				if( mHandler[ i ] == null ) 
					continue;

				Item.ScriptArgs = mArguments[ i ];
				mHandler[ i ]( Player, Item );				
			}

		}

	}

}
