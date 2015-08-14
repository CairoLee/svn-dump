using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace FinalSoftware.Games.Defender.Library {

	public class DefenderMusic {
		private SoundBank mSounds;
		private AudioEngine mEngine;
		private Cue mMusic;
		private Cue mBossMusic;
		private string mMusicName;
		private float mVolume;
		private bool mBossEvent;

		public float Volume {
			get { return mVolume; }
			set {
				mVolume = value;
				if( mVolume > 1 )
					mVolume = 1;
				else if( mVolume < 0 )
					mVolume = 0;
				mEngine.GetCategory( "Music" ).SetVolume( mVolume );
			}
		}

		public bool BossEvent {
			get { return mBossEvent; }
			set { mBossEvent = value; }
		}


		public DefenderMusic( SoundBank sounds, AudioEngine engine ) {
			mSounds = sounds;
			mEngine = engine;
			mMusic = sounds.GetCue( "stage_music" );
			mMusicName = mMusic.Name;
			mVolume = 1.0f;
			mMusic.Play();
		}


		public void Update() {
			if( mMusic.IsStopped ) {
				mMusic = mSounds.GetCue( "stage_music" );
				mMusic.Play();
			}


			if( mBossEvent && mBossMusic.IsStopped ) {
				mBossEvent = false;
			}
		}

		public void ChangeTrack() {
			mMusic.Stop( AudioStopOptions.Immediate );
			mMusic = mSounds.GetCue( "stage_music" );
			mMusic.Play();
		}

		public void EndBossEvent() {
			mBossEvent = false;
			mMusicName = mMusic.Name;
			mBossMusic.Stop( AudioStopOptions.Immediate );
			mMusic.Resume();
		}

		public void TriggerBossEvent() {
			mBossEvent = true;
			mMusic.Pause();
			mBossMusic = mSounds.GetCue( "boss_music" );
			mMusicName = mBossMusic.Name;
			mBossMusic.Play();
		}

		public override string ToString() {
			string musicString = "{Cue: " + mMusicName + " | Volume: " + mVolume + "}";
			return musicString;
		}
	}
}
