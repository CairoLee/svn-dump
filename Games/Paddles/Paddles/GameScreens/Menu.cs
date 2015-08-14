using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Paddles.GameScreens {
	public enum MenuState {
		Main,
		Help,
		Pause
	}
	public class Menu {
		#region Fields
		List<Text> menuItems;
		List<Text> helpText;
		List<Text> pauseText;
		Text activeItem;
		MenuState mState = MenuState.Main;
		int selection;
		#endregion

		public Menu() {
			#region Menu Items
			menuItems = new List<Text>();
			menuItems.Add(new Text("Play Game", new Vector2(30, 80), true));
			menuItems.Add(new Text("Help", new Vector2(30, menuItems[0].Position.Y + 5.0f + Game1.gSFont.MeasureString(menuItems[0].Contents).Y), true));
			menuItems.Add(new Text("Quit", new Vector2(30, menuItems[1].Position.Y + 5.0f + Game1.gSFont.MeasureString(menuItems[1].Contents).Y), true));
			#endregion
			#region Help Items
			helpText = new List<Text>();
			helpText.Add(new Text("Help", new Vector2(30, 80), false, 1.2f, Color.Black));
			helpText.Add(new Text("Up Arrow - Move Up", new Vector2(30, helpText[0].Position.Y + 5.0f + Game1.gSFont.MeasureString(helpText[0].Contents).Y),
				false, 1.0f, Color.White));
			helpText.Add(new Text("Down Arrow - Move Down", new Vector2(30, helpText[1].Position.Y + 5.0f + Game1.gSFont.MeasureString(helpText[1].Contents).Y),
				false, 1.0f, Color.White));
			helpText.Add(new Text("Escape (In Main Menu) - Quits the game", new Vector2(30, helpText[2].Position.Y + 5.0f + Game1.gSFont.MeasureString(helpText[2].Contents).Y),
				false, 1.0f, Color.White));
			helpText.Add(new Text("Escape (While Playing) - Pause Menu", new Vector2(30, helpText[3].Position.Y + 5.0f + Game1.gSFont.MeasureString(helpText[3].Contents).Y),
				false, 1.0f, Color.White));
			helpText.Add(new Text("<  Press Backspace to go back to the Main Menu", new Vector2(30, helpText[4].Position.Y + 50.0f + Game1.gSFont.MeasureString(helpText[4].Contents).Y),
				false, 1.0f, Color.White));
			#endregion
			selection = 0;
		}
		public void update(GameTime gTime) {
			#region Main Menu
			if (mState == MenuState.Main) {
				#region Movement
				if (ScreenManager.keyboard.MenuUp) {
					if (selection == 0)
						selection = 2;
					else
						selection--;
				} else if (ScreenManager.keyboard.MenuDown) {
					if (selection == 2)
						selection = 0;
					else
						selection++;
				}
				#endregion
				#region Menu Select
 else if (ScreenManager.keyboard.MenuSelect) {
					switch (selection) {
						case 0:
							GameScreen.Start(gTime);
							ScreenManager.gameState = GameState.Play;
							break;
						case 1:
							mState = MenuState.Help;
							break;
						case 2:
							Game1.quit = true;
							break;
					}
				}
				#endregion
				activeItem = menuItems[selection];
				#region Individual Update
				foreach (Text t in menuItems) {
					if (t == activeItem)
						t.setBubble(true);
					else
						t.setBubble(false);
					t.update(gTime);
				}
				#endregion
			}
			#endregion
			#region Help Menu
 else {
				if (ScreenManager.keyboard.MenuBack)
					mState = MenuState.Main;

				foreach (Text t in helpText)
					t.update(gTime);
			}
			#endregion
		}
		public void draw() {
			#region Main Menu
			if (mState == MenuState.Main) {
				foreach (Text t in menuItems)
					t.draw();
			}
			#endregion
			#region Help Menu
 else {
				foreach (Text t in helpText)
					t.draw();
			}
			#endregion
		}
	}
}
