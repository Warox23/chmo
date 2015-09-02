using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    class DataTableManeger
    {
        public DataTable dt { get; set; }
        public DataTableManeger()
        {
             dt = new DataTable("TEST");

            dt.Columns.Add
                (
                new DataColumn("Id", typeof(int)) { Caption = "АЙ ДИ", AutoIncrement = true, AllowDBNull = false, Unique = true, ReadOnly = true, AutoIncrementSeed = 1 }
                );

            dt.Columns.Add(new DataColumn("Name", typeof(string)) { Caption = "Name", AllowDBNull = false });
            dt.Columns.Add(new DataColumn("Price", typeof(float)) { AllowDBNull = false, Caption = "Price" });
        }

        public void AddRow(string name)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = dr["Id"] + name;
            
            //иначе рандом выдает одинаковые значения
            Thread.Sleep(10);
            dr["Price"] = new Random().Next(10000) / 100f;
            dt.Rows.Add(dr);
        }

        public void FiilTable (string []names = null)
        {
            if (names!=null)
            {
                foreach (var n in names)
                    AddRow(n);
                return;
            }

            for (int i = 0; i < 10; i++)
                AddRow(i.ToString());
        }

    }
}
