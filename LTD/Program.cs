using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Newtonsoft.Json;



namespace LTD
{
    public class Engine
    {

        public static Config.ConfigStore conf = Config.ConfigStore.LoadConfig();
        public static Graphics.TextureManager textureManager = new Graphics.TextureManager();
        public static LTD.Game.GameManager gameManager;

        static void Main(string[] args)
        {
            var window = new LTD.Window();
            window.Run();
        }
    }
    
}

