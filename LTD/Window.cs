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
    public class Window
    {
        public static Clock clock;
        public RenderWindow renderWindow;

        public Window()
        {
            var mode = new SFML.Window.VideoMode((uint)Engine.conf.screenWidth, (uint)Engine.conf.screenHeight);
            renderWindow = new SFML.Graphics.RenderWindow(mode, "LTD", Styles.Close);
        }
        public void Run()
        {
            renderWindow.KeyPressed += Window_KeyPressed;

            GameManager gameManager = new GameManager();
            
            while (renderWindow.IsOpen)
            {
                clock = new Clock();
                renderWindow.Clear();
                renderWindow.DispatchEvents();
                
                gameManager.RunGame(this);

                renderWindow.Display();
                clock.Restart();
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
