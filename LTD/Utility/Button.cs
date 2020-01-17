using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LTD.Utility
{
    class Button
    {
        public SFML.Graphics.Texture normalTXT, highlightedTXT, pressedTXT;
        public bool disabled;

        bool pressed;
        bool wait;

        SFML.Graphics.Sprite sprite;

        

        public Button(SFML.System.Vector2f position, SFML.Graphics.Texture normal, SFML.Graphics.Texture highlighted, SFML.Graphics.Texture pressed)
        {
            normalTXT = normal;
            highlightedTXT = highlighted;
            pressedTXT = pressed;
            
            sprite = new SFML.Graphics.Sprite(normalTXT);
            sprite.Position = position;
        }


        public bool Pressed()
        {
            SFML.System.Vector2i mousePos = SFML.Window.Mouse.GetPosition(Engine.gameManager.currentWindow.renderWindow);

            

            if(sprite.GetGlobalBounds().Contains(mousePos.X, mousePos.Y))
            {
                if(SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Left))
                {
                    if (wait)
                    {
                        pressed = false;
                    }
                    else
                    {
                        sprite.Texture = pressedTXT;
                        pressed = true;
                        wait = true;
                    }
                }
                else
                {
                    sprite.Texture = highlightedTXT;
                    pressed = false;
                    wait = false;
                }
            }
            else
            {
                sprite.Texture = normalTXT;
                return false;
            }

            return pressed;
        }

        public void Draw(SFML.Graphics.RenderWindow window)
        {
            window.Draw(sprite);
        }

    }
}
