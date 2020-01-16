using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace LTD.Config
{
    public class ConfigStore
    {
        public int screenWidth;
        public int screenHeight;

        private static string defaultConfigJson = @"
            {
                'screenWidth': 640,
                'screenHeight': 480
            }";


        public static ConfigStore LoadConfig()
        {
            string json = "";
            try
            {
                using (FileStream fs = new FileStream("config\\config.ltd", FileMode.Open))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    string read = Encoding.UTF8.GetString(bytes);
                    json = read;
                }
            }
            catch
            {
                try
                {
                    using (FileStream fs = File.Create("config\\config.ltd"))
                    {
                        json = defaultConfigJson;
                        byte[] bytes = new UTF8Encoding(true).GetBytes(json);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Config file problem! " + e.Message);
                }
            }
            return JsonConvert.DeserializeObject<ConfigStore>(json);
        }
    }
}
