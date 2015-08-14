using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using SkinnedModel;

namespace SkinnedModelPipeline {

	[ContentProcessor]
	public class SkinnedModelProcessor : ModelProcessor {
		private const int MaxBones = 59;

		public SkinnedModelProcessor() {
		}

		private static int CompareKeyframeTimes(Keyframe a, Keyframe b) {
			TimeSpan time = a.Time;
			int num = time.CompareTo(b.Time);
			return num;
		}

		protected override MaterialContent ConvertMaterial(MaterialContent material, ContentProcessorContext context) {
			BasicMaterialContent basicMaterialContent = material as BasicMaterialContent;
			bool texture = basicMaterialContent != null;
			if (texture) {
				EffectMaterialContent effectMaterialContent = new EffectMaterialContent();
				string fullPath = Path.GetFullPath("SkinnedModel.fx");
				effectMaterialContent.Effect = new ExternalReference<EffectContent>(fullPath);
				texture = basicMaterialContent.Texture == null;
				if (!texture) {
					effectMaterialContent.Textures.Add("Texture", basicMaterialContent.Texture);
				}
				MaterialContent materialContent = base.ConvertMaterial(effectMaterialContent, context);
				return materialContent;
			} else {
				throw new InvalidContentException(string.Format("SkinnedModelProcessor only supports BasicMaterialContent, but input mesh uses {0}.", material.GetType()));
			}
		}

		private static void FlattenTransforms(NodeContent node, BoneContent skeleton) {
			bool flag;
			IEnumerator<NodeContent> enumerator = node.Children.GetEnumerator();
			try {
				while (true) {
					flag = enumerator.MoveNext();
					if (!flag) {
						break;
					}
					NodeContent current = enumerator.Current;
					flag = current != skeleton;
					if (flag) {
						MeshHelper.TransformScene(current, current.Transform);
						current.Transform = Matrix.Identity;
						SkinnedModelProcessor.FlattenTransforms(current, skeleton);
					}
				}
			} finally {
				flag = enumerator == null;
				if (!flag) {
					enumerator.Dispose();
				}
			}
		}

		private static bool MeshHasSkinning(MeshContent mesh) {
			bool flag;
			bool flag1;
			IEnumerator<GeometryContent> enumerator = mesh.Geometry.GetEnumerator();
			try {
				do {
					flag1 = enumerator.MoveNext();
					if (flag1) {
						GeometryContent current = enumerator.Current;
						flag1 = current.Vertices.Channels.Contains(VertexChannelNames.Weights());
					} else {
						flag = true;
						return flag;
					}
				}
				while (flag1);
				flag = false;
				return flag;
			} finally {
				flag1 = enumerator == null;
				if (!flag1) {
					enumerator.Dispose();
				}
			}
			flag = true;
			return flag;
		}

		public override ModelContent Process(NodeContent input, ContentProcessorContext context) {
			SkinnedModelProcessor.ValidateMesh(input, context, null);
			BoneContent boneContent = MeshHelper.FindSkeleton(input);
			bool count = boneContent != null;
			if (count) {
				SkinnedModelProcessor.FlattenTransforms(input, boneContent);
				IList<BoneContent> boneContents = MeshHelper.FlattenSkeleton(boneContent);
				count = boneContents.Count <= 59;
				if (count) {
					List<Matrix> matrices = new List<Matrix>();
					List<Matrix> matrices1 = new List<Matrix>();
					List<int> nums = new List<int>();
					IEnumerator<BoneContent> enumerator = boneContents.GetEnumerator();
					try {
						while (true) {
							count = enumerator.MoveNext();
							if (!count) {
								break;
							}
							BoneContent current = enumerator.Current;
							matrices.Add(current.Transform);
							matrices1.Add(Matrix.Invert(current.AbsoluteTransform));
							nums.Add(boneContents.IndexOf(current.Parent as BoneContent));
						}
					} finally {
						count = enumerator == null;
						if (!count) {
							enumerator.Dispose();
						}
					}
					Dictionary<string, AnimationClip> strs = SkinnedModelProcessor.ProcessAnimations(boneContent.Animations, boneContents);
					ModelContent modelContent = base.Process(input, context);
					modelContent.Tag = new SkinningData(strs, matrices, matrices1, nums);
					ModelContent modelContent1 = modelContent;
					return modelContent1;
				} else {
					throw new InvalidContentException(string.Format("Skeleton has {0} bones, but the maximum supported is {1}.", boneContents.Count, 59));
				}
			} else {
				throw new InvalidContentException("Input skeleton not found.");
			}
		}

		private static AnimationClip ProcessAnimation(AnimationContent animation, Dictionary<string, int> boneMap) {
			int num = 0;
			bool count;
			List<Keyframe> keyframes = new List<Keyframe>();
			IEnumerator<KeyValuePair<string, AnimationChannel>> enumerator = animation.Channels.GetEnumerator();
			try {
				while (true) {
					count = enumerator.MoveNext();
					if (!count) {
						break;
					}
					KeyValuePair<string, AnimationChannel> current = enumerator.Current;
					count = boneMap.TryGetValue(current.Key, out num);
					if (!count) {
						throw new InvalidContentException(string.Format("Found animation for bone '{0}', which is not part of the skeleton.", current.Key));
					}
					IEnumerator<AnimationKeyframe> enumerator1 = current.Value.GetEnumerator();
					try {
						while (true) {
							count = enumerator1.MoveNext();
							if (!count) {
								break;
							}
							AnimationKeyframe animationKeyframe = enumerator1.Current;
							keyframes.Add(new Keyframe(num, animationKeyframe.Time, animationKeyframe.Transform));
						}
					} finally {
						count = enumerator1 == null;
						if (!count) {
							enumerator1.Dispose();
						}
					}
				}
			} finally {
				count = enumerator == null;
				if (!count) {
					enumerator.Dispose();
				}
			}
			keyframes.Sort(SkinnedModelProcessor.CompareKeyframeTimes);
			count = keyframes.Count != 0;
			if (count) {
				count = !(animation.Duration <= TimeSpan.Zero);
				if (count) {
					AnimationClip animationClip = new AnimationClip(animation.Duration, keyframes);
					return animationClip;
				} else {
					throw new InvalidContentException("Animation has a zero duration.");
				}
			} else {
				throw new InvalidContentException("Animation has no keyframes.");
			}
		}

		private static Dictionary<string, AnimationClip> ProcessAnimations(AnimationContentDictionary animations, IList<BoneContent> bones) {
			bool count;
			Dictionary<string, int> strs = new Dictionary<string, int>();
			int num = 0;
			while (true) {
				count = num < bones.Count;
				if (!count) {
					break;
				}
				string name = bones[num].Name;
				count = string.IsNullOrEmpty(name);
				if (!count) {
					strs.Add(name, num);
				}
				num++;
			}
			Dictionary<string, AnimationClip> strs1 = new Dictionary<string, AnimationClip>();
			IEnumerator<KeyValuePair<string, AnimationContent>> enumerator = animations.GetEnumerator();
			try {
				while (true) {
					count = enumerator.MoveNext();
					if (!count) {
						break;
					}
					KeyValuePair<string, AnimationContent> current = enumerator.Current;
					AnimationClip animationClip = SkinnedModelProcessor.ProcessAnimation(current.Value, strs);
					strs1.Add(current.Key, animationClip);
				}
			} finally {
				count = enumerator == null;
				if (!count) {
					enumerator.Dispose();
				}
			}
			count = strs1.Count != 0;
			if (count) {
				Dictionary<string, AnimationClip> strs2 = strs1;
				return strs2;
			} else {
				throw new InvalidContentException("Input file does not contain any animations.");
			}
		}

		private static void ValidateMesh(NodeContent node, ContentProcessorContext context, string parentBoneName) {
			object[] name;
			MeshContent meshContent = node as MeshContent;
			bool flag = meshContent == null;
			if (flag) {
				flag = node as BoneContent != null;
				if (!flag) {
					parentBoneName = node.Name;
				}
			} else {
				flag = parentBoneName == null;
				if (!flag) {
					name = new object[2];
					name[0] = meshContent.Name;
					name[1] = parentBoneName;
					context.Logger.LogWarning(null, null, "Mesh {0} is a child of bone {1}. SkinnedModelProcessor does not correctly handle meshes that are children of bones.", name);
				}
				flag = SkinnedModelProcessor.MeshHasSkinning(meshContent);
				if (!flag) {
					name = new object[1];
					name[0] = meshContent.Name;
					context.Logger.LogWarning(null, null, "Mesh {0} has no skinning information, so it has been deleted.", name);
					meshContent.Parent.Children.Remove(meshContent);
					return;
				}
			}
			IEnumerator<NodeContent> enumerator = (new List<NodeContent>(node.Children)).GetEnumerator();
			try {
				while (true) {
					flag = enumerator.MoveNext();
					if (!flag) {
						break;
					}
					NodeContent current = enumerator.Current;
					SkinnedModelProcessor.ValidateMesh(current, context, parentBoneName);
				}
			} finally {
				enumerator.Dispose();
			}
		}
	}
}