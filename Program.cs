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
    

}
