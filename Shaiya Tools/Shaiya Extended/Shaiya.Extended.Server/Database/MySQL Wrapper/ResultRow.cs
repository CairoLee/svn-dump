using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Shaiya.Extended.Server.MySql {
	public class ResultTable {
		private DataTable mTable;
		private ResultRowCollection mRows;
		private int mRowCount = -1;

		public string TableName {
			get { return mTable.TableName; }
			set { mTable.TableName = value; }
		}

		public ResultRowCollection Rows {
			get { return mRows; }
		}

		public ResultRow this[ int Index ] {
			get { return mRows.Get( Index ); }
		}



		public ResultTable() {
			mTable = new DataTable();
			mRows = null;
			mRowCount = -1;
		}

		public ResultTable( DataTable Table ) {
			if( Table == null )
				throw new Exception( "Table is NULL!" );
			mTable = Table;
			mRows = new ResultRowCollection( mTable.Rows );
			mRowCount = -1;
		}


		public ResultRow GetNext() {
			if( mRowCount == -1 )
				mRowCount = 0;

			if( mRowCount < mRows.Count )
				return mRows[ mRowCount++ ];

			return null;
		}

	}

	public class ResultRowCollection {
		private DataRowCollection mRows;

		public int Count {
			get { return mRows.Count; }
		}

		public ResultRow this[ int Index ] {
			get { return Get( Index ); }
		}

		public ResultRowCollection( DataRowCollection Rows ) {
			if( Rows == null )
				throw new Exception( "Rows is NULL!" );
			mRows = Rows;
		}


		public ResultRow Get( int Index ) {
			if( Index >= mRows.Count )
				return new ResultRow();
			return new ResultRow( mRows[ Index ] );
		}

		public System.Collections.IEnumerator GetEnumerator() {
			return mRows.GetEnumerator();
		}
	}

	public class ResultRow {
		private DataRow mRow;

		public ResultRowValue this[ int Index ] {
			get { return Get( Index ); }
		}

		public ResultRowValue this[ string Index ] {
			get { return Get( Index ); }
		}

		public ResultRow() {
		}

		public ResultRow( DataRow Row ) {
			if( Row == null )
				throw new Exception( "Row is NULL!" );
			mRow = Row;
		}


		private ResultRowValue Get( int Index ) {
			if( Index >= mRow.Table.Columns.Count )
				return new ResultRowValue();
			return new ResultRowValue( mRow[ Index ] );
		}

		private ResultRowValue Get( string Index ) {
			object value;
			try {
				value = mRow[ Index ];
			} catch {
				value = null;
			}
			return new ResultRowValue( value );
		}
	}

	public class ResultRowValue {
		private object mValue = null;


		public ResultRowValue( object Value ) {
			mValue = Value;
		}
		public ResultRowValue() {
		}



		public Int32 GetInt32() {
			Int32 result;
			if( mValue != null && Int32.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return -1;
		}

		public Int16 GetInt16() {
			Int16 result;
			if( mValue != null && Int16.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return -1;
		}

		public int GetInt() {
			return GetInt32();
		}

		public UInt32 GetUInt32() {
			UInt32 result;
			if( mValue != null && UInt32.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return 0;
		}

		public UInt16 GetUInt16() {
			UInt16 result;
			if( mValue != null && UInt16.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return 0;
		}

		public uint GetUInt() {
			return GetUInt32();
		}

		public float GetFloat() {
			float result;
			if( mValue != null && float.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return 0f;
		}

		public double GetDouble() {
			double result;
			if( mValue != null && double.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return 0d;
		}

		public decimal GetDecimal() {
			decimal result;
			if( mValue != null && decimal.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return 0m;
		}

		public byte GetByte() {
			byte result;
			if( mValue != null && byte.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return 0;
		}

		public char GetChar() {
			char result;
			if( mValue != null && char.TryParse( mValue.ToString(), out result ) == true )
				return result;
			return (char)0;
		}

		public string GetString() {
			if( mValue != null )
				return mValue.ToString();
			return string.Empty;
		}

		public T GetEnum<T>() {
			try {
				return (T)Enum.Parse( typeof( T ), mValue.ToString() );
			} catch {
				return default( T );
			}
		}

		public bool GetBool() {
			return GetByte() > 0;
		}



		public override string ToString() {
			return GetString();
		}

	}

}
