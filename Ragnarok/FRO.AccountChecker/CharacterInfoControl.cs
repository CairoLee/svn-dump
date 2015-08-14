using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FRO.AccountChecker {
	
	public partial class CharacterInfoControl : UserControl {
		private CharacterInfo mCharacter;
		
		public CharacterInfoControl(CharacterInfo c) {
			InitializeComponent();

			RefreshInfos(c);
		}

		
		public void RefreshInfos(CharacterInfo c) {
			mCharacter = c;

			imgAvatar.Image = mCharacter.Avatar;
			lblName.Text = "Name: " + mCharacter.Name;
			lblJob.Text = "Class: " + mCharacter.Class;
			lblLevel.Text = "Level: " + mCharacter.LevelBase + "/" + mCharacter.LevelJob;
			lblZeny.Text = "Zeny: " + int.Parse(mCharacter.Zeny).ToString("n0");
		}

	}

}
