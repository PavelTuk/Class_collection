using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
                 
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(5, "Five", "Dubbed"); //неуникальный составной ключ
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Two", "Val_3_Two");
            mycoll.AddToCollection(3, "One", "Val_3_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            Console.WriteLine("Вывод элемента по составному ключу");
            Console.WriteLine(mycoll.GetBuyIDandName(5, "Five"));
            Console.WriteLine();

            Console.WriteLine("Элементы с ID=5");
            foreach (var ListByID in mycoll.GetByID(5))
            {
                Console.WriteLine(ListByID);
            }
            Console.WriteLine();

            Console.WriteLine("Элементы с Name='Five'");
            foreach (var ListByName in mycoll.GetByName("Five"))
            {
                Console.WriteLine(ListByName);
            }
            Console.WriteLine();

            Console.WriteLine("Количество элементов = " + mycoll.Count);
            Console.WriteLine();

            //удаление элемента
            mycoll.Remove(5, "Five");

            //проверка удален ли элемент
            Console.WriteLine("Элементы с Name='Five'");
            foreach (var ListByName in mycoll.GetByName("Five"))
            {           
                Console.WriteLine(ListByName);
            }
            Console.WriteLine();

            Console.WriteLine("Количество элементов = " + mycoll.Count);       
    
            Console.ReadLine();
        }
    }
}
