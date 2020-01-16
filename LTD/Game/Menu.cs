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

        public Menu() // once at start
        {
            text.Color = Color.White;
            text.Position = new Vector2f(50, 50);
        }

        public void HandleMenu(RenderWindow window) // every frame
        {
            window.Draw(text);
        }
    }
}
