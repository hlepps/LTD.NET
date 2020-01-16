using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTD.Game
{
    class GameManager
    {
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
        }

        public GameState CurrentGameState;
        public void RunGame(SFML.Window.Window window)
        {

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
