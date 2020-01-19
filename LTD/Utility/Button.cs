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

        public string text;

        SFML.Graphics.Text sfmlText;
        bool pressed;
        bool wait;

        SFML.Graphics.Sprite sprite;

        

        public Button(string textToShow, SFML.Graphics.Font font, SFML.System.Vector2f position, SFML.Graphics.Texture normal, SFML.Graphics.Texture highlighted, SFML.Graphics.Texture pressed)
        {
            text = textToShow;
            sfmlText = new SFML.Graphics.Text(text, font);
            sfmlText.OutlineThickness = 1;
            sfmlText.OutlineColor = SFML.Graphics.Color.Black;
            normalTXT = normal;
            highlightedTXT = highlighted;
            pressedTXT = pressed;
            
            sprite = new SFML.Graphics.Sprite(normalTXT);
            sprite.Position = position;
        }

        public void SetPosition(SFML.System.Vector2f pos)
        {
            sprite.Position = pos;
        }

        public SFML.System.Vector2f GetPosition()
        {
            return sprite.Position;
        }

        public SFML.Graphics.FloatRect GetGlobalBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public SFML.Graphics.FloatRect GetLocalBounds()
        {
            return sprite.GetLocalBounds();
        }


        public bool Pressed()
        {
            SFML.System.Vector2i mousePos = SFML.Window.Mouse.GetPosition(Engine.gameManager.currentWindow.renderWindow);
            
            sfmlText.Position = sprite.Position + new SFML.System.Vector2f(sprite.GetGlobalBounds().Width / 2 - sfmlText.GetGlobalBounds().Width / 2, sprite.GetGlobalBounds().Height / 2 - sfmlText.GetGlobalBounds().Height / 2 * 1.5f);
            

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
            window.Draw(sfmlText);
        }

    }
}
