

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// The UpdateCollectionRange class provides specific information about a range 
	/// of add and remove operations made to a collection. 
	/// These objects are associated with a specific UpdateCollectionMessage and 
	/// are carried in an Array on its body property.
	/// </summary>
	public class UpdateCollectionRange {
		/// <summary>
		/// Indicates a range of items that have been deleted from the collection.
		/// </summary>
		public const int DeleteFromCollection = 1;
		/// <summary>
		/// Indicates a range of items have been inserted into the collection.
		/// </summary>
		public const int InsertIntoCollection = 0;

		object[] _identities;
		int _position;
		int _updateType;
		int _size;

		/// <summary>
		/// Initializes a new instance of the UpdateCollectionRange class.
		/// </summary>
		public UpdateCollectionRange() {
		}

		/// <summary>
		/// An Array of identity objects that represent which items were either 
		/// deleted or inserted in the associated collection starting at the position 
		/// indicated by the position property.
		/// </summary>
		public object[] identities {
			get { return _identities; }
			set { _identities = value; }
		}
		/// <summary>
		/// Indicates the begining index for the range of updates made to the associated collection. 
		/// The updateType indicates if the range was an insert or a remove operation. 
		/// </summary>
		public int position {
			get { return _position; }
			set { _position = value; }
		}
		/// <summary>
		/// Indicates what operation this range represents.
		/// </summary>
		public int updateType {
			get { return _updateType; }
			set { _updateType = value; }
		}
		/// <summary>
		/// Indicates the increase in collection size. Only applicatble when update type is INCREMENT_COLLECTION_SIZE or DECREMENT_COLLECTION_SIZE.
		/// </summary>
		public int size {
			get { return _size; }
			set { _size = value; }
		}
		/*
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			string value = (updateType != 0 ? "delete" : "insert") + "@" + "position = " + position + " [" + ArrayUtils.ArrayToString((IList)identities) + "]";
			return value;
		}
		*/
	}
}
