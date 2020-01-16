using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using LTD.Game;

namespace LTD
{
    class Window
    {
        public void Run()
        {
            Config.ConfigStore conf = Config.ConfigStore.LoadConfig();
            var mode = new SFML.Window.VideoMode((uint)conf.screenWidth, (uint)conf.screenHeight);
            var window = new SFML.Graphics.RenderWindow(mode, "LTD");
            window.KeyPressed += Window_KeyPressed;

            GameManager gameManager = new GameManager();
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                
                gameManager.RunGame(window);

                window.Display();
            }
        }
        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
            }

        }
    }
}
