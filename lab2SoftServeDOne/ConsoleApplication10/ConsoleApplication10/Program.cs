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

            Items itms = (Items) new XmlManager().Deserializable(typeof(Items), "qwe.xml");

                    
            using (var db = new ItemContext())
            {
                foreach(var t in itms.Itms)
                db.Items.Add(t);
                db.SaveChanges();
            }

            Console.Read();

        }
    }


   

}