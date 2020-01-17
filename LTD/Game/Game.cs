using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace LTD.Game
{
    public class GameManager
    {
        public Window currentWindow;
        public enum GameState
        {
            MENU, // - default
            MAP,
            FIGHT
        };

        public Menu menu;

        public GameManager()
        {
            menu = new Menu();
            Engine.gameManager = this;
        }

        public GameState CurrentGameState;
        public void RunGame(Window window)
        {
            currentWindow = window;
            switch(CurrentGameState)
            {
                case GameState.MENU:
                    menu.HandleMenu(window);
                    break;

                case GameState.MAP:

                    break;

                case GameState.FIGHT:

                    break;
            }
        }
    }
}
