using System;
using System.IO;
using Microsoft.Xna.Framework.Audio;

namespace Tetris.Sounds {

	public class Sound {
		private static AudioEngine mAudioEngine;
		private static WaveBank mWaveBank;
		private static SoundBank mSoundBank;

		public static bool MuteSound {
			get;
			set;
		}


		static Sound() {
			// Load sound files in static constructor
			try {
				string dir = "Content/Sounds/";
				mAudioEngine = new AudioEngine(Path.Combine(dir, "TetrisSound.xgs"));
				mWaveBank = new WaveBank(mAudioEngine, Path.Combine(dir, "Wave Bank.xwb"));
				if (mWaveBank != null) {
					mSoundBank = new SoundBank(mAudioEngine, Path.Combine(dir, "Sound Bank.xsb"));
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

		/// <summary>
		/// Play
		/// </summary>
		/// <param name="soundName">Sound name</param>
		public static void Play(string soundName) {
			if (mSoundBank == null || MuteSound) {
				return;
			}

			try {
				mSoundBank.PlayCue(soundName);
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

		/// <summary>
		/// Play
		/// </summary>
		/// <param name="sound">Sound</param>
		public static void Play(ESoundTypes sound) {
			if (MuteSound == false) {
				Play(sound.ToString());
			}
		}

		/// <summary>
		/// Update, just calls audioEngine.Update!
		/// </summary>
		public static void Update() {
			if (mAudioEngine != null && MuteSound == false) {
				mAudioEngine.Update();
			}
		}

	}

}
