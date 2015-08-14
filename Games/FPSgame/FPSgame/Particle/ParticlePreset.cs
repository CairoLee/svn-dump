using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FPSgame {

	public class ParticlePreset : ParticleManager {

		public ParticlePreset(Game game, Renderer renderer)
			: base(game, renderer) {
		}


		public override void LoadContent(Game game) {
			Textureset[0] = game.Content.Load<Texture2D>("Particles/smoke");
			Textureset[1] = game.Content.Load<Texture2D>("Particles/Particle");
			Textureset[2] = game.Content.Load<Texture2D>("Particles/Fire");
			Textureset[3] = game.Content.Load<Texture2D>("Particles/Smoke2");
			Textureset[4] = game.Content.Load<Texture2D>("Particles/Smoke3");
			Textureset[5] = game.Content.Load<Texture2D>("Particles/Attack");
			Textureset[6] = game.Content.Load<Texture2D>("Particles/Ring");
			Textureset[7] = game.Content.Load<Texture2D>("Particles/Particle");
			Textureset[8] = game.Content.Load<Texture2D>("Particles/Attack2");
			Textureset[9] = game.Content.Load<Texture2D>("Particles/Ring2");
			Textureset[10] = game.Content.Load<Texture2D>("Particles/BlackBlood");
			Textureset[11] = game.Content.Load<Texture2D>("Particles/Blood1");
			Textureset[12] = game.Content.Load<Texture2D>("Particles/Blood2");
			Textureset[15] = game.Content.Load<Texture2D>("Particles/BloodSmoke");
			Textureset[16] = game.Content.Load<Texture2D>("Particles/Hit");
			Textureset[17] = game.Content.Load<Texture2D>("Particles/EffectNormal2");
			Textureset[18] = game.Content.Load<Texture2D>("Particles/EffectNormal");
			Textureset[19] = game.Content.Load<Texture2D>("Particles/Smoke1");
			Textureset[20] = game.Content.Load<Texture2D>("Particles/Blood3");
			Textureset[21] = game.Content.Load<Texture2D>("Particles/Blood4");
			Textureset[22] = game.Content.Load<Texture2D>("Particles/Blood5");
			Textureset[23] = game.Content.Load<Texture2D>("Particles/HitEffect");

			Textureset[24] = game.Content.Load<Texture2D>("Particles/HitEffectDes");
			Textureset[25] = game.Content.Load<Texture2D>("Particles/RingDes");
			Textureset[26] = game.Content.Load<Texture2D>("Particles/Lumber1");
			Textureset[27] = game.Content.Load<Texture2D>("Particles/Lumber2");

			NormTexture[2] = game.Content.Load<Texture2D>("Particles/Blood1_Norm");
			NormTexture[3] = game.Content.Load<Texture2D>("Particles/Blood2_Norm");

			Modelset[0] = game.Content.Load<Model>("Particles/plane");
			Modelset[1] = game.Content.Load<Model>("Models/bug/lag_crack");
			Modelset[2] = game.Content.Load<Model>("Models/bug/lag2_crack");
			Modelset[3] = game.Content.Load<Model>("Models/bug/lag3_crack");
			Modelset[4] = game.Content.Load<Model>("Models/bug/lag4_crack");
			Modelset[5] = game.Content.Load<Model>("Models/bug/lag5_crack");

		}


		public void ParticleGunFlash(Vector3 pos) {
			AddParticle(0, 1,
					 pos,
					 new Vector3(0),
					 new Vector3(0),
					 new Vector3(Rand.Next(5, 10) / 300f),
					 new Vector3(Rand.Next(1, 5) / 1000f),
					 Vector3.Zero,
					 new Vector3(0, 0, Rand.Next(360) / 10f),
					 new Vector3(0, 0, Rand.Next(-10, 10) / 500f),
					 Vector3.Zero,
					 5, -0.2f, 0,
					 new Vector3(10),
					 new Vector3(0, 0, 0),
					 new Vector3(0, 0, 0),
					 2, true, 1);
		}

		public void ParticleBloodMini(Vector3 pos, Vector3 Dir) {
			AddParticle(0, Rand.Next(11, 12),
					  pos,
					  new Vector3((Rand.Next(-15, 85) / 100f) * Dir.X, (Rand.Next(-20, 50) / 100f) * Dir.Y, Rand.Next(-15, 15) / 100f),
					  new Vector3(0, -0.01f, 0),
					  new Vector3(Rand.Next(5, 10) / 500f),
					  new Vector3(Rand.Next(1, 5) / 1000f),
					  Vector3.Zero,
					  new Vector3(0, 0, Rand.Next(360) / 10f),
					  new Vector3(0, 0, Rand.Next(-10, 10) / 500f),
					  Vector3.Zero,
					  Rand.Next(10, 40) / 10f, -0.2f, 0,
					  new Vector3(1, 1, 1),
					  new Vector3(0, 0, 0),
					  new Vector3(0, 0, 0),
					  100, false, 1);
		}
		public void ParticleSmokeBlood(Vector3 pos, Vector3 Dir) {
			AddParticle(0, 15,
				pos,
				new Vector3((Rand.Next(-15, 45) / 100f) * Dir.X, Rand.Next(15) / 100f, Rand.Next(-15, 15) / 100f),
				new Vector3(0, -0.01f, 0),
				new Vector3(Rand.Next(30) / 1000f),
				new Vector3(0.01f),
				Vector3.Zero,
				new Vector3(0, 0, Rand.Next(360) / 10f),
				new Vector3(0, 0, Rand.Next(-10, 10) / 500f),
				Vector3.Zero,
				Rand.Next(30) / 10f, -0.05f, 0,
				new Vector3(10f, 5, 2),
				new Vector3(0.1f, 0, 0),
				new Vector3(0, 0, 0),
				100, false, 1
			);
		}
		public void ParticleBlood(Vector3 pos, Vector3 Dir) {
			AddParticle(0, Rand.Next(20, 22),
				pos,
				new Vector3(0),
				new Vector3(0),
				new Vector3(Rand.Next(1, 20) / 1000f),
				new Vector3(0.004f),
				Vector3.Zero,
				new Vector3(0, 0, Rand.Next(360) / 10f),
				new Vector3(0),
				Vector3.Zero,
				Rand.Next(5, 40) / 10f, -0.2f, 0,
				new Vector3(1, 1, 1),
				new Vector3(0, 0, 0),
				new Vector3(0, 0, 0),
				100, false, 1
			);



			for (int i = 0; i < 10; i++) {
				AddParticle(0, Rand.Next(11, 12),
					pos,
					new Vector3((Rand.Next(-15, 85) / 100f) * Dir.X, (Rand.Next(-20, 100) / 100f) * Dir.Y, Rand.Next(-15, 15) / 100f),
					new Vector3(0, -0.01f, 0),
					new Vector3(Rand.Next(5, 10) / 500f),
					new Vector3(Rand.Next(1, 5) / 1000f),
					Vector3.Zero,
					new Vector3(0, 0, Rand.Next(360) / 10f),
					new Vector3(0, 0, Rand.Next(-10, 10) / 500f),
					Vector3.Zero,
					Rand.Next(10, 40) / 10f, -0.1f, 0,
					new Vector3(1, 1, 1),
					new Vector3(0, 0, 0),
					new Vector3(0, 0, 0),
					100, false, 1
				);
			}

		}
		public void ParticleSmokeGround(Vector3 pos) {
			AddParticle(0, 19,
				pos,
				new Vector3(Rand.Next(-10, 10), Rand.Next(-10, 10), Rand.Next(-10, 10)) / 100f,
				new Vector3(0),
				new Vector3(Rand.Next(1, 20) / 100f),
				new Vector3(0.005f),
				new Vector3(0, 0, 0),
				new Vector3(0, 0, Rand.Next(300) / 100f),
				new Vector3(0, 0, Rand.Next(-10, 10) / 1000f),
				Vector3.Zero,
				Rand.Next(5, 10) / 10f, -0.01f, 0,
				new Vector3(11, 11, 10),
				new Vector3(0),
				new Vector3(0, 0, 0),
				100, false, 1
			);
		}
		public void ParticleSmokeGroundBig(Vector3 pos) {
			AddParticle(0, 19,
				pos,
				new Vector3(Rand.Next(1, 30), Rand.Next(1, 10), Rand.Next(-10, 10)) / 100f,
				new Vector3(0),
				new Vector3(Rand.Next(10, 50) / 100f),
				new Vector3(0.01f),
				new Vector3(0, 0, 0),
				new Vector3(0, 0, Rand.Next(300) / 100f),
				new Vector3(0, 0, Rand.Next(-10, 10) / 1000f),
				Vector3.Zero,
				Rand.Next(8, 20) / 10f, -0.01f, 0,
				new Vector3(2.3f, 3.3f, 3.9f),
				new Vector3(0.1f),
				new Vector3(0, 0, 0),
				100, false, 1
			);
		}

		public void ParticleHitNormal(Vector3 pos) {
			AddParticle(0, 19,
				pos,
				new Vector3(Rand.Next(-10, 10), Rand.Next(-10, 50), Rand.Next(-10, 10)) / 100f,
				new Vector3(0),
				new Vector3(Rand.Next(1, 20) / 100f),
				new Vector3(0.005f),
				new Vector3(0, 0, 0),
				new Vector3(0, 0, Rand.Next(300) / 100f),
				new Vector3(0, 0, Rand.Next(-10, 10) / 1000f),
				Vector3.Zero,
				Rand.Next(5, 10) / 10f, -0.05f, 0,
				new Vector3(1),
				new Vector3(0.01f),
				new Vector3(0, 0, 0),
				100, false, 1
			);
		}

		public void ParticleGeeCrops(Vector3 position, Vector3 Dir) {
			int[] node = { 1 };
			for (int i = 1; i < 6; i++) {
				AddParticleMesh(
					i, 
					node, 
					position, 
					new Vector3((Rand.Next(-20, 100) / 50f) * -Dir.X, Rand.Next(-10, 10) / 10f, 0), 
					new Vector3(0, -0.04f, 0),
					new Vector3(0.01f), 
					Vector3.Zero, 
					Vector3.Zero, 
					new Vector3(Rand.Next(5, 30) / 100f, Rand.Next(5, 30) / 100f, Rand.Next(5, 30) / 100f), 
					new Vector3(Rand.Next(5, 30) / 100f, Rand.Next(5, 30) / 100f, Rand.Next(5, 30) / 100f), 
					Vector3.Zero, 
					100
				);
			}
		}

	}

}
