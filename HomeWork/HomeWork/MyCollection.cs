using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class MyCollection<TID, TName, TVal>
    {
        private readonly Dictionary<TID, Dictionary<TName, TVal>> dictByID;
        private readonly Dictionary<TName, Dictionary<TID, TVal>> dictByName;
        private int count;
        object locker = new object();

        public MyCollection()
        {
            dictByID = new Dictionary<TID, Dictionary<TName, TVal>>();
            dictByName = new Dictionary<TName, Dictionary<TID, TVal>>();
        }

        #region Добавление элемента
        public void AddToCollection(TID ID, TName Name, TVal Val)
        {         
            lock (locker)
            {
                Dictionary<TName, TVal> dictName;
                if (!dictByID.TryGetValue(ID, out dictName))
                {
                    dictName = new Dictionary<TName, TVal>();
                    dictByID.Add(ID, dictName);
                }
                if (dictName.ContainsKey(Name))
                {
                    return;
                }

                Dictionary<TID, TVal> dictID;
                if (!dictByName.TryGetValue(Name, out dictID))
                {
                    dictID = new Dictionary<TID, TVal>();
                    dictByName.Add(Name, dictID);
                }
                if (dictID.ContainsKey(ID))
                {
                    return;
                }

                dictID.Add(ID, Val);
                dictName.Add(Name, Val);
                count++;
            }
        }
        #endregion

        #region Поиск по ID и Name
        public TVal GetBuyIDandName(TID ID, TName Name)
        {
            lock (locker)
            {
                Dictionary<TName, TVal> dictName;
                TVal value;
                if (dictByID.TryGetValue(ID, out dictName))
                {
                    if (dictName.TryGetValue(Name, out value)) return value;
                }
                return default(TVal);
            }
        }
        #endregion

        #region Выборка элементов по Name
        public IList<TVal> GetByName(TName Name)
        {
            lock (locker)
            {
                Dictionary<TID, TVal> dictID;
                if (dictByName.TryGetValue(Name, out dictID)) return dictID.Values.ToList();
                return new List<TVal>();
            }
        }
        #endregion
        
        #region Выборка элементов по ID
        public IList<TVal> GetByID(TID ID)
        {
            lock (locker)
            {
                Dictionary<TName, TVal> dictName;
                if (dictByID.TryGetValue(ID, out dictName)) return dictName.Values.ToList();
                return new List<TVal>();
            }
        }
        #endregion

        #region Удаление элемента
        public void Remove(TID ID, TName Name)
        {
            lock (locker)
            {
                Dictionary<TID, TVal> dictID;
                if (dictByName.TryGetValue(Name, out dictID))
                {
                    Dictionary<TName, TVal> dictName;
                    if (dictByID.TryGetValue(ID, out dictName))
                    {
                        dictID.Remove(ID);
                        dictName.Remove(Name);
                        count--;
                    }
                }
                return;
            }
        }
        #endregion

        #region Количество элементов
        public int Count
        {        
            get
            {
                return count;
            }
        }
        #endregion

    }
}
