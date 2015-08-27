using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Race Race { get; set; }
        public string FavoriteCar { get; set; }

        public Person (string name,int age, Sex sex, Race race, String favoriteCar )
        {
            Name = name;
            Age = age;
            Sex = sex;
            Race = race;
            FavoriteCar = favoriteCar;
        }

        public Person() { }


        public override string ToString()
        {
            //string str = String.Format("{0},{1},{2},{3},{5}",Name,Age,IsMan,Race,FavoriteCar);

            return String.Format("{0},{1},{2},{3},{4}", Name, Age, Sex, Race, FavoriteCar);
        }

    }
}
