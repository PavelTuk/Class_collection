using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tests
{
    [TestClass]
    public class MyCollectionTests
    {
        [TestMethod]
        public void add_7_items_to_collection() //добавить 5 элементов в коллекцию
        {
            //arrange

            //act  
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Two", "Val_3_Two");
            mycoll.AddToCollection(3, "One", "Val_3_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            //assert
            Assert.IsTrue(mycoll.Count == 7);
        }

        [TestMethod]
        public void get_item_with_key_5_Five() //получить элемент по составному ключу (5, "Five")
        {
            //arrange
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Two", "Val_3_Two");
            mycoll.AddToCollection(3, "One", "Val_3_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            //act

            //assert
            Assert.IsTrue("Val_5_Five" == mycoll.GetBuyIDandName(5, "Five"));
        }

        [TestMethod]
        public void remove_item() //удалить элемент с составном ключом (5, "Five")
        {
            //arrange
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Two", "Val_3_Two");
            mycoll.AddToCollection(3, "One", "Val_3_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            //act
            mycoll.Remove(5, "Five");

            //assert
            Assert.IsTrue(mycoll.GetBuyIDandName(5, "Five") == null);
        }

        [TestMethod]
        public void add_item_with_non_unique_key() //попытка вставить элемент имеющий неуникальный составной ключ
        {
            //arrange
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Two", "Val_3_Two");
            mycoll.AddToCollection(3, "One", "Val_3_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            //act
            mycoll.AddToCollection(5, "Five", "Dubbed");

            //assert
            Assert.IsFalse("Dubbed" == mycoll.GetBuyIDandName(5, "Five"));
        }

        [TestMethod]
        public void get_items_with_id_5() //получить элементы с ID=5
        {
            //arrange
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Two", "Val_3_Two");
            mycoll.AddToCollection(5, "One", "Val_5_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            //act
            var ListByID = mycoll.GetByID(5);

            //assert
            Assert.IsTrue(ListByID.Count == 4); //в списке 4 элемента удововлетворяющих ключу
        }

        [TestMethod]
        public void get_items_with_name_Five() ////получить элементы с Name='Five'
        {
            //arrange
            MyCollection<int, string, string> mycoll = new MyCollection<int, string, string>();
            mycoll.AddToCollection(5, "Five", "Val_5_Five");
            mycoll.AddToCollection(5, "Six", "Val_5_Six");
            mycoll.AddToCollection(6, "Five", "Val_6_Five");
            mycoll.AddToCollection(2, "Two", "Val_2_Two");
            mycoll.AddToCollection(3, "Five", "Val_3_Five");
            mycoll.AddToCollection(3, "One", "Val_3_One");
            mycoll.AddToCollection(5, "Seven", "Val_5_Seven");

            //act
            var ListByName = mycoll.GetByName("Five");

            //assert
            Assert.IsTrue(ListByName.Count == 3); //в списке 3 элемента удововлетворяющих ключу
        }
    }
}

