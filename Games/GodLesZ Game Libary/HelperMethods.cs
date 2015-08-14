using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace GLibary {
	public partial class Utility {
		public static void SetPrivateMemberValueType<TObjectType, TValueType>(
			ref TObjectType o,
			string variableName,
			TValueType Value ) {
			Type t = o.GetType();
			FieldInfo fi = t.GetField( variableName, BindingFlags.NonPublic | BindingFlags.Instance );

			if( fi != null ) {
				object ob = o;
				fi.SetValue( ob, Value );
				o = (TObjectType)ob;
			}
		}

		public static void SetPrivateMemberRefType<TObjectType, TValueType>(
			ref TObjectType o,
			string variableName,
			TValueType Value ) {
			Type t = o.GetType();
			FieldInfo fi = t.GetField( variableName, BindingFlags.NonPublic | BindingFlags.Instance );

			if( fi != null ) {
				fi.SetValue( o, Value );
			}
		}

		public static List<T> GetValuesList<T>() {
			Type currentEnum = typeof( T );
			List<T> resultSet = new List<T>();
			if( currentEnum.IsEnum ) {
				FieldInfo[] fields = currentEnum.GetFields( BindingFlags.Static |  BindingFlags.Public );

				foreach( FieldInfo field in fields )
					resultSet.Add( (T)field.GetValue( null ) );
			}

			return resultSet;
		}

		public static T[] GetValuesArray<T>() {
			Type currentEnum = typeof( T );
			T[] resultSet = null;
			if( currentEnum.IsEnum ) {
				FieldInfo[] fields = currentEnum.GetFields( BindingFlags.Static | BindingFlags.Public );

				resultSet = new T[ fields.Length ];

				for( int x = 0; x < fields.Length; x++ ) {
					resultSet[ x ] = (T)fields[ x ].GetValue( null );
				}
			}

			return resultSet;
		}
	}
}
