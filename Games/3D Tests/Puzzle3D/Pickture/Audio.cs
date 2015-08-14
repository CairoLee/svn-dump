using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Puzzle3D {

	public static class Audio {

		static AudioEngine engine = new AudioEngine( "Content/Audio/Puzzle3D.xgs" );
		static WaveBank waveBank = new WaveBank( engine, "Content/Audio/Wave Bank.xwb" );
		static SoundBank soundBank = new SoundBank( engine, "Content/Audio/Sound Bank.xsb" );


		public static void Update() {
			engine.Update();
		}

		public static void Play( string cueName ) {
			soundBank.PlayCue( cueName );
		}

	}

}
