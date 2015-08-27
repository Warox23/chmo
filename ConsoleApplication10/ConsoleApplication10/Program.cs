using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication10
{
       
    class Program
    {        
        static void Main(string[] args)
        {
           /* var p = new Person("Viktor",25,Sex.Man,Race.Mongloid,"Buggatti");
            var p1 = new Person("Roma", 22, Sex.Man, Race.Africoid, "Audi");
            var p2 = new Person("Alex", 11, Sex.Woman, Race.Austroloid, "Bmw");
            var p3 = new Person("Kondrat", 52, Sex.Man, Race.Mongloid, "Maclaren");
            var p4 = new Person("Orest", 13, Sex.Man, Race.American, "Merssedes");
            var p5 = new Person("Kolya", 24, Sex.Man, Race.Africoid, "Ausi");
            var p6 = new Person("Lesya", 16, Sex.Woman, Race.Africoid, "Bmw");
            var p7 = new Person("Olya", 19, Sex.Gender, Race.Austroloid, "Bmw");

            StreamWriter sw = new StreamWriter("File.txt");

            sw.WriteLine(p);
            sw.WriteLine(p1);
            sw.WriteLine(p2);
            sw.WriteLine(p3);
            sw.WriteLine(p4);
            sw.WriteLine(p5);
            sw.WriteLine(p6);
            sw.WriteLine(p7);

            sw.Close();*/


           ReadWriteFile rw = new ReadWriteFile();

           List<Person> persons = rw.GetPersons("file.txt");


            XmlManager xm = new XmlManager();
            xm.Serializable(persons,"xmltest.xml");

            xm.AddInXml(new Person("Marina",20,Sex.Woman,Race.American,"Bmw"),"xmltest.xml");



            Console.Read();

        }
    }


   

}