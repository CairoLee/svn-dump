using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace FinalSoftware.Games.Defender.Library {

	public class DefenderAudioEffects : GameComponent {

		private class Cue3D {
			public Cue Cue;
			public Vector3 Position;
		}

		private readonly AudioEmitter mEmitter = new AudioEmitter();
		private readonly List<Cue3D> mActiveCues = new List<Cue3D>();
		private readonly Stack<Cue3D> mCuePool = new Stack<Cue3D>();

		public AudioEngine Engine;
		public WaveBank WaveBank;
		public SoundBank SoundBank;
		public AudioListener Listener = new AudioListener();


		public DefenderAudioEffects(Game game)
			: base(game) {
		}


		public override void Initialize() {
			if (Engine == null || WaveBank == null || SoundBank == null) {
				Engine = new AudioEngine("Content/audio/siegeAudio.xgs");
				WaveBank = new WaveBank(Engine, "Content/audio/Wave Bank.xwb");
				SoundBank = new SoundBank(Engine, "Content/audio/Sound Bank.xsb");
			}

			base.Initialize();
		}

		protected override void Dispose(bool disposing) {
			try {
				if (disposing) {
					SoundBank.Dispose();
					WaveBank.Dispose();
					Engine.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		public override void Update(GameTime gameTime) {
			Listener.Position = new Vector3(DefenderWorld.Instance.Interface.Camera.Position.X, DefenderWorld.Instance.Interface.Camera.Position.Y, 100 / DefenderWorld.Instance.Interface.Camera.Zoom);

			int index = 0;
			while (index < mActiveCues.Count) {
				Cue3D cue3D = mActiveCues[index];

				if (cue3D.Cue.IsStopped) {
					cue3D.Cue.Dispose();
					mCuePool.Push(cue3D);
					mActiveCues.RemoveAt(index);
				} else {
					Apply3D(cue3D);
					index++;
				}
			}
			Engine.Update();

			base.Update(gameTime);
		}

		public Cue Play3DCue(string cueName, Vector2 position) {
			Cue3D cue3D;

			if (mCuePool.Count > 0) {
				cue3D = mCuePool.Pop();
			} else {
				cue3D = new Cue3D();
			}

			cue3D.Cue = SoundBank.GetCue(cueName);
			cue3D.Position = new Vector3(position.X, position.Y, 0);

			Apply3D(cue3D);
			cue3D.Cue.Play();
			mActiveCues.Add(cue3D);

			return cue3D.Cue;
		}

		public Cue Play3DCue(string cueName) {
			return Play3DCue(cueName, new Vector2(Listener.Position.X, Listener.Position.Y));
		}


		private void Apply3D(Cue3D cue3D) {
			mEmitter.Position = cue3D.Position;
			cue3D.Cue.Apply3D(Listener, mEmitter);
		}

	}
}
