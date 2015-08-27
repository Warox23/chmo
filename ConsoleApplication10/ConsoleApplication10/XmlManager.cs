using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApplication10
{
    class XmlManager
    {
        public void Serializable(List<Person> persons,string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Person>));
            
            using (FileStream fs = new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                xs.Serialize(fs, persons);
                
            }
        }

        public void AddInXml (Person person,string path)
        {

            if (!File.Exists(path))
                throw new FileNotFoundException();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement newPerson = doc.CreateElement("Person");

            XmlElement newName = doc.CreateElement("Name");
            newName.InnerText = person.Name;
            newPerson.AppendChild(newName);

            XmlElement newAge = doc.CreateElement("Age");
            newAge.InnerText = person.Age.ToString();
            newPerson.AppendChild(newAge);

            XmlElement newSex = doc.CreateElement("Sex");
            newSex.InnerText = person.Sex.ToString();
            newPerson.AppendChild(newSex);

            XmlElement newRace = doc.CreateElement("Race");
            newRace.InnerText = person.Race.ToString();
            newPerson.AppendChild(newRace);

            XmlElement newFavoriteCar = doc.CreateElement("FavoriteCar");
            newFavoriteCar.InnerText = person.FavoriteCar;
            newPerson.AppendChild(newFavoriteCar);

            doc.DocumentElement.AppendChild(newPerson);
            doc.Save(path);
        }

    }
}
