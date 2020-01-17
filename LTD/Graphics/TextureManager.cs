using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

namespace LTD.Graphics
{
    public class TextureManager
    {

        Dictionary<string, SFML.Graphics.Texture> textures = new Dictionary<string, SFML.Graphics.Texture>();
        List<string> filenames = new List<string>();

        public SFML.Graphics.Texture GetTexture(string path)
        {
            SFML.Graphics.Texture tex = new SFML.Graphics.Texture(@"img\default.png");
            if (textures.TryGetValue(path, out tex))
                return tex;
            else
                return tex;
        }

        public TextureManager()
        {
            try
            {
                filenames.AddRange(Directory.GetFiles("img\\"));
                for(int i = 0; i < filenames.Count; i++)
                {
                    if (!Regex.IsMatch(filenames[i], @"^.*\.(jpg|JPG|png|PNG)$"))
                    {
                        filenames.Remove(filenames[i]);
                        i--;
                    }
                    else
                    {
                        Console.WriteLine(filenames[i]);
                        textures.Add(filenames[i], new SFML.Graphics.Texture(filenames[i]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sprite Manager Error!!! " + e.Message);
            }
        }

    }
}
