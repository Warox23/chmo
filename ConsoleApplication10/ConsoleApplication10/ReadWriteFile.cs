using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class ReadWriteFile
    {
        private readonly Encoding _DefaultEncoding = Encoding.Default;

        public List<Person> GetPersons(string path, Encoding enc)
        {
            String []text = File.ReadAllLines(path,enc);
            List<Person> persons = new List<Person>();

            foreach (var s in text)
            {
                string []parametrs = s.Split(',');
                var person = new Person();
                person.Name = parametrs[0];
                person.Age = Int32.Parse(parametrs[1]);
                person.Sex = parametrs[2].ToEnum<Sex>();
                person.Race = parametrs[3].ToEnum<Race>();
                person.FavoriteCar = parametrs[4];

                persons.Add(person);
            }



            return persons;
        }

        public List<Person> GetPersons(string path)
        {
            return GetPersons(path, _DefaultEncoding);
        }

        public bool IsExist(string path)
        {
            return File.Exists(path);
        }


    }
}
