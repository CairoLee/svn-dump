using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Shaiya_Skill_Ressources.Structs;
using Shaiya_Skill_Ressources;

namespace Ssc.Components {

	public partial class SkillDescControl : UserControl {
		private Font mFontSmall = new Font( "Microsoft Sans Serif", 6.000001f, FontStyle.Regular );
		private Font mFontSmallBold = new Font( "Microsoft Sans Serif", 6.000001f, FontStyle.Bold );
		private Font mFontNormal = new Font( "Microsoft Sans Serif", 8.25f, FontStyle.Regular );
		private Font mFontNormalBold = new Font( "Microsoft Sans Serif", 8.25f, FontStyle.Bold );
		private int mPanelCount = 0;
		private Label mLastLabel = null;


		public SkillDescControl() {
			InitializeComponent();
		}


		public void SetSkillDesc( SkillControl SkillPanel, int LvlNum ) {
			SkillLevel Level = SkillPanel.Skill[ LvlNum ];
			LvlNum++; // lazy for ( LvlNum + 1 )


			if( Level.Name == "" )
				lblName.Text = SkillPanel.Skill.Name + " - Lvl " + LvlNum;
			else
				lblName.Text = Level.Name + " - Lvl " + LvlNum;

			if( SkillPanel.CurrentLevelNum >= LvlNum )
				this.BackColor = Color.FromArgb( 227, 240, 254 );

			picIcon.Image = SkillPanel.Skill.Icon;
			lblDesc.Text = Level.Description;
			lblLevelValue.Text = Level.RequiredLevel.ToString();
			lblLevel.Location = new Point( lblLevel.Location.X, lblDesc.Location.Y + lblDesc.Height + 4 );
			lblLevelValue.Location = new Point( lblLevelValue.Location.X, lblLevel.Location.Y );
			lblSkillPointsValue.Text = Level.SkillPunkte.ToString();
			lblSkillPoints.Location = new Point( lblSkillPoints.Location.X, lblLevel.Location.Y );
			lblSkillPointsValue.Location = new Point( lblSkillPointsValue.Location.X, lblSkillPoints.Location.Y );

			this.Anchor = ( AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top );
			this.Height = lblLevel.Location.Y + lblLevel.Size.Height + 4;

			if( SkillPanel.Skill.Type == ESkillType.Passive ) {
				if( this.Height < 58 ) {
					this.Height = 58; // 13 padding below Icon
					// move Label near bottom line
					lblLevel.Location = new Point( lblLevel.Location.X, this.Height - lblLevel.Height - 4 );
					lblLevelValue.Location = new Point( lblLevelValue.Location.X, lblLevel.Location.Y );
					lblSkillPoints.Location = new Point( lblSkillPoints.Location.X, lblLevel.Location.Y );
					lblSkillPointsValue.Location = new Point( lblSkillPointsValue.Location.X, lblSkillPoints.Location.Y );
				}
				return;
			}

			if( Level.Mana != 0 ) 
				AddLabel( "Mana:", ( Level.Mana < 0 ? Level.Mana + "%" : Level.Mana.ToString() ) );

			if( Level.Stamina != 0 )
				AddLabel( "Ausdauer:", ( Level.Stamina < 0 ? Level.Stamina + "%" : Level.Stamina.ToString() ) );

			if( Level.Delay != 0 )
				AddLabel( "Cooldown:", Level.Delay + " sec" );

			if( Level.Range != 0 )
				AddLabel( "Reichweite:", Level.Range + "m" );

			if( Level.CastTime != 0f )
				AddLabel( "Casttime:", Level.CastTime + " sec" );

			if( Level.AoE != 0 )
				AddLabel( "AoE:", Level.AoE + "m" );

			if( Level.Element != ESkillElement.None ) {
				AddLabel( "Element:", Level.Element.ToString() );
				AddElementBox( Level.Element );
			}

			if( Level.Status != "" )
				AddLabel( "Status:", Level.Status );

			// reconfig height based on last label
			if( mLastLabel != null )
				this.Size = new Size( this.Size.Width, mLastLabel.Location.Y + mLastLabel.Size.Height + 4 );
		}



		private void AddLabel( string Text, string Value ) {
			Point Location = Point.Empty;
			Location.X = 50; // left
			if( ( mPanelCount % 2 ) != 0 )
				Location.X = 211; // right
			Location.Y = ( lblLevel.Location.Y + lblLevel.Height + 1 ) + ( 13 * ( mPanelCount / 2 ) );
			mPanelCount++;

			mLastLabel = new Label();
			mLastLabel.Font = mFontSmallBold;
			mLastLabel.AutoSize = true;
			mLastLabel.MaximumSize = new Size( 150, 12 );
			mLastLabel.Location = Location;
			mLastLabel.Text = Text;

			Controls.Add( mLastLabel );

			Size oldSize = mLastLabel.Size;
			// Value Label \\
			mLastLabel = new Label();
			mLastLabel.Font = mFontSmall;
			mLastLabel.AutoSize = true;
			mLastLabel.Location = new Point( Location.X + oldSize.Width - 2, Location.Y );
			mLastLabel.Text = Value;

			Controls.Add( mLastLabel );
		}

		private void AddElementBox( ESkillElement Element ) {
			PictureBox pic = new PictureBox();
			pic.SizeMode = PictureBoxSizeMode.AutoSize;
			pic.Image = Element.ToImage();
			pic.Location = new Point( mLastLabel.Location.X + mLastLabel.Width + 2, mLastLabel.Location.Y + ( mLastLabel.Height / 2 ) - ( pic.Image.Height / 2 ) );

			Controls.Add( pic );
		}

	}

}
