using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BridgeSerialize
{
    
    public interface ISerialize
    {
        void Serialize(string pathSave);
    }

    public class XMLSerializeRaces : ISerialize
    {
        private readonly List<Race> data;

        public XMLSerializeRaces(List<Race> data)
        {
            this.data = data;
        }
        public void Serialize(string pathSave)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Race>));
            using (var fs = new FileStream(pathSave, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, data);
            }
        }
    }

    public class JsonSerializeRaces : ISerialize
    {   
        private readonly List<Race> data;

        public JsonSerializeRaces(List<Race> data)
        {
            this.data = data;
        }
        public void Serialize(string pathSave)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(data, options);

            using (var sw = new StreamWriter(pathSave, false, Encoding.UTF8))
            {
                sw.Write(json);
            }
        }
    }
}
