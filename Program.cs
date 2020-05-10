using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main()
        {
            MyList<string> a = new MyList<string>();
            a.Add("Bill");
            a.Add("Max");
            a.Add("Conor");
            a.Add("Jack");
            a.Add("Luis");
            a.Add("Dominik");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }


            Map<int, string> map = new Map<int, string>();
            map.Add(10, "Mag");
            map.Add(20, "Warrior");
            map.Add(22, "Inquisitor");
            map.Add(30, "Ogr");
            map.Add(80, "Programist");
            foreach (var item in map)
            {
                Console.WriteLine(item);
            }


            

            Console.ReadKey();
        }


        
    }
    

    class MyList<T>
    {
        
        T[] element = null;
        
        int eIt = 0;
        public int Count { get; set; }



        public void Add(T ele) {
            if(eIt == Count)
            {
                Count = swapArr(ref element);
                
            }
            element[eIt] = ele;
            eIt++;
        }


        private int swapArr(ref T[] arr)
        {
            T[] newArr = new T[arr.Length + 5];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
            return arr.Length;
        }


        public T this[int index]
        {
            get
            {
                if(index>=0&&index<element.Length) return element[index];
                else
                {
                    Console.WriteLine(new InvalidOperationException("Пустой лист.").Message);
                    return element[0];
                }
            }
            set
            {
                element[index] = value;
            }
        }


        public MyList()
        {
            element = new T[5];
            Count = 5;
        }

        public MyList(int size)
        {
            element = new T[size];
            Count = size;
        }


        public IEnumerator GetEnumerator()
        {
            return element.GetEnumerator();
        }

       
       
    }

    public class Item<T, S>
    {
        
        public T Key { get; set; }
        public S Value { get; set; }

        public Item() { }
        public Item(T key, S value)
        {
            
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Key.ToString() + " : " + Value.ToString();
        }
    }

    public class Map<T, S>
    {
        private List<Item<T, S>> _items = new List<Item<T, S>>();
        
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public IReadOnlyList<T> Keys
        {
            get
            {
                return _items.Select(i => i.Key).ToList();
            }
        }


        public void Add(Item<T, S> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_items.Any(i => i.Key.Equals(item.Key)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {item.Key}.", nameof(item));
            }

            _items.Add(item);
        }


        public void Add(T key, S value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_items.Any(i => i.Key.Equals(key)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {key}.", nameof(key));
            }

            var item = new Item<T, S>()
            {
                Key = key,
                Value = value
            };

            // Добавляем данные в коллекцию.
            _items.Add(item);
        }
        
        
        
        public S Get(T key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            

            var item = _items.SingleOrDefault(i => i.Key.Equals(key)) ??
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));

            return item.Value;
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }


    }
    

}
