using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace LTD.Game
{
    public class Menu
    {
        Text text = new Text("Menu", LTD.Config.FontsManager.roboto);
        Utility.Button button;
        Sprite s = new Sprite(Engine.textureManager.GetTexture(@"img\jebla.jpg"));

        public Menu() // once at start
        {
            button = new Utility.Button(new Vector2f(50, 50), Engine.textureManager.GetTexture(@"img\jebla.jpg"), Engine.textureManager.GetTexture(@"img\mentosno.jpg"), Engine.textureManager.GetTexture(@"img\ricardo.jpg"));
            text.FillColor = Color.White;
            text.OutlineColor = Color.Red;
            text.OutlineThickness = 1;
            text.Position = new Vector2f(50, 50);
            text.CharacterSize = 72;
        }

        public void HandleMenu(Window window) // every frame
        {
            text.Position = new Vector2f(window.renderWindow.Size.X / 2 - text.GetLocalBounds().Width / 2, 50);

            window.renderWindow.Draw(text);
            

            if (button.Pressed())
            {
                Console.WriteLine("YAY!");
            }

            button.Draw(window.renderWindow);
        }
    }
}
