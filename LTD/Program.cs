using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace LTD
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new SimpleWindow();
            window.Run();
        }
    }

    class SimpleWindow
    {
        public void Run()
        {
            var mode = new SFML.Window.VideoMode(800, 600);
            var window = new SFML.Graphics.RenderWindow(mode, "LTD Engine");
            window.KeyPressed += Window_KeyPressed;

            var circle = new SFML.Graphics.CircleShape(100f)
            {
                FillColor = SFML.Graphics.Color.Blue
            };
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Draw(circle);
                
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

