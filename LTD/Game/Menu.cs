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
        Text text = new Text("Menu", Engine.fontsManager.roboto);
        Utility.Button button;
        Sprite background = new Sprite(Engine.textureManager.GetTexture(@"img\fantasy.jpg"));

        public Menu() // once at start
        {
            background.TextureRect = new IntRect(0, 0, 1280, 720);

            button = new Utility.Button("End", Engine.fontsManager.roboto, new Vector2f(50, 50), 
                Engine.textureManager.GetTexture(@"img\button_normal.png"), 
                Engine.textureManager.GetTexture(@"img\button_highlighted.png"), 
                Engine.textureManager.GetTexture(@"img\button_pressed.png"));

            text.FillColor = Color.White;
            text.OutlineColor = Color.Red;
            text.OutlineThickness = 1;
            text.Position = new Vector2f(50, 50);
            text.CharacterSize = 72;

            text.Position = new Vector2f(50, 50);
            button.SetPosition(new Vector2f(800, 50));
        }

        public void HandleMenu(Window window) // every frame
        {
            window.renderWindow.Draw(background);
            window.renderWindow.Draw(text);
            

            if (button.Pressed())
            {
                window.renderWindow.Close();
            }

            button.Draw(window.renderWindow);
        }
    }
}
