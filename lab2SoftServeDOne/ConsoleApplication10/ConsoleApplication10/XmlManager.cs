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
        public void Serializable(object obj,string path)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            
            using (FileStream fs = new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                xs.Serialize(fs, obj);
            }
        }

       /* public void AddInXml (Person person,string path)
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
        }*/


        public object Deserializable(Type t ,string path)
        {
            XmlSerializer xs = new XmlSerializer(t);
            object items;

            using (StreamReader sr = new StreamReader(path))
            {
                items = (Items)xs.Deserialize(sr);
            }
            return items;
        }

        public Items DeserializableToListItems(string path)
        {
            return (Items) Deserializable(typeof(Items), path);

        }

    }
}
