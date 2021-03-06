﻿using System;
using System.Drawing;

namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// Utilities functions used by the TargaImage class.
	/// </summary>
	static class TargaUtilities {

		/// <summary>
		/// Gets an int value representing the subset of bits from a single Byte.
		/// </summary>
		/// <param name="b">The Byte used to get the subset of bits from.</param>
		/// <param name="offset">The offset of bits starting from the right.</param>
		/// <param name="count">The number of bits to read.</param>
		/// <returns>
		/// An int value representing the subset of bits.
		/// </returns>
		/// <remarks>
		/// Given -> b = 00110101 
		/// A call to GetBits(b, 2, 4)
		/// GetBits looks at the following bits in the byte -> 00{1101}00
		/// Returns 1101 as an int (13)
		/// </remarks>
		internal static int GetBits(byte b, int offset, int count) {
			return (b >> offset) & ((1 << count) - 1);
		}

		/// <summary>
		/// Reads ARGB values from the 16 bits of two given Bytes in a 1555 format.
		/// </summary>
		/// <param name="one">The first Byte.</param>
		/// <param name="two">The Second Byte.</param>
		/// <returns>A System.Drawing.Color with a ARGB values read from the two given Bytes</returns>
		/// <remarks>
		/// Gets the ARGB values from the 16 bits in the two bytes based on the below diagram
		/// |   BYTE 1   |  BYTE 2   |
		/// | A RRRRR GG | GGG BBBBB |
		/// </remarks>
		internal static Color GetColorFrom2Bytes(byte one, byte two) {
			// get the 5 bits used for the RED value from the first byte
			int r1 = TargaUtilities.GetBits(one, 2, 5);
			int r = r1 << 3;

			// get the two high order bits for GREEN from the from the first byte
			int bit = TargaUtilities.GetBits(one, 0, 2);
			// shift bits to the high order
			int g1 = bit << 6;

			// get the 3 low order bits for GREEN from the from the second byte
			bit = TargaUtilities.GetBits(two, 5, 3);
			// shift the low order bits
			int g2 = bit << 3;
			// add the shifted values together to get the full GREEN value
			int g = g1 + g2;

			// get the 5 bits used for the BLUE value from the second byte
			int b1 = TargaUtilities.GetBits(two, 0, 5);
			int b = b1 << 3;

			// get the 1 bit used for the ALPHA value from the first byte
			int a1 = TargaUtilities.GetBits(one, 7, 1);
			int a = a1 * 255;

			// return the resulting Color
			return Color.FromArgb(a, r, g, b);
		}

		/// <summary>
		/// Gets a 32 character binary string of the specified Int32 value.
		/// </summary>
		/// <param name="n">The value to get a binary string for.</param>
		/// <returns>A string with the resulting binary for the supplied value.</returns>
		/// <remarks>
		/// This method was used during debugging and is left here just for fun.
		/// </remarks>
		internal static string GetIntBinaryString(Int32 n) {
			char[] b = new char[32];
			int pos = 31;
			int i = 0;

			while (i < 32) {
				if ((n & (1 << i)) != 0) {
					b[pos] = '1';
				} else {
					b[pos] = '0';
				}
				pos--;
				i++;
			}
			return new string(b);
		}

		/// <summary>
		/// Gets a 16 character binary string of the specified Int16 value.
		/// </summary>
		/// <param name="n">The value to get a binary string for.</param>
		/// <returns>A string with the resulting binary for the supplied value.</returns>
		/// <remarks>
		/// This method was used during debugging and is left here just for fun.
		/// </remarks>
		internal static string GetInt16BinaryString(Int16 n) {
			char[] b = new char[16];
			int pos = 15;
			int i = 0;

			while (i < 16) {
				if ((n & (1 << i)) != 0) {
					b[pos] = '1';
				} else {
					b[pos] = '0';
				}
				pos--;
				i++;
			}
			return new string(b);
		}

	}

}
