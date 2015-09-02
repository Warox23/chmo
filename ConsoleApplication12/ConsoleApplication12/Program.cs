using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt;
            DataTableManeger dtm = new DataTableManeger();

            dtm.FiilTable();
            dt = dtm.dt;
            //приводим к перечислению, делаем выборку с условием, приводим к листу
            var idSelect = dt.AsEnumerable().Where(x => (int)x["id"] > 3).ToList();

            //елементы где айди больше 4, выбераем цену, приводим к типу флоат, преобразуем в список
            var prices = dt.AsEnumerable().Where(x => (int)x["id"] > 4).Select(x => x["price"]).Cast<float>().ToList();

            //делаем выбрку по цене, приводим к флоат, сортируем
            var ascSort = dt.AsEnumerable().Select(x => x["price"]).Cast<float>().OrderBy(x=>x).ToList();


        
            
            //делаем выборку так, что одновременно обявляем новый анонимным тип, и в него записываем результат с каждго шага выборки
            var anonClassList = dt.AsEnumerable().Select(x => new { IdField = x["id"], NameField = x["Name"], PriceFiel = x["price"] }).ToList();


            //двойное условие, сортируем по цене
            var sumRangeDesc = dt.AsEnumerable().Where(x => (int)x["id"] > 3 && (int)x["id"] < 8).OrderByDescending(x=>x["price"]).Cast<DataRow>().ToList();

          Console.WriteLine();

        }

    }
}
