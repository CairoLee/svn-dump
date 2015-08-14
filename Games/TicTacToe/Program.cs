using System;
using System.Windows.Forms;

namespace TicTacToe {

	public static class Program {

		public static void Main( string[] args ) {

			using( GameCore game = new GameCore() ) {
				using( Control control = Form.FromHandle( game.Window.Handle ) ) {
					/*
					Form form = control.FindForm();
					form.FormBorderStyle = FormBorderStyle.None;
					form.StartPosition = FormStartPosition.CenterScreen;
					*/
					game.Run();
				}
			}

		}

	}

}

