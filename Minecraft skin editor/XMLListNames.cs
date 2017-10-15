using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Minecraft_skin_editor
{
    public class NamePlayer
    {
        [XmlElement(ElementName = "Name")]
        public string  Name; 
    }
    [XmlRoot(ElementName = "NamesOfPlayers")]
    public class NamesOfPlayers
    {
        [XmlElement(ElementName = "Player")]
        public List<NamePlayer> NamePlayersList { get; set; } = new List<NamePlayer>();
    }
}
