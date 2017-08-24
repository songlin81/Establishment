using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableDemo
{
    static class Program
    {
        static void Main()
        {
            //1.
            IEnumerable<int> values = from value in Enumerable.Range(1, 10) select value;
            foreach (int a in values)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();

            //2.
            List<string> List = new List<string>();
            List.Add("Sourav");
            List.Add("Ram");
            List.Add("shyam");
            List.Add("Sachin");
            IEnumerable names = from n in List where (n.StartsWith("S")) select n;
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();

            //3.
            Test t1 = new Test();
            t1.Name = "Sourav";
            t1.Surname = "Kayal";
            Test t2 = new Test();
            t2.Name = "Ram";
            t2.Surname = "Das";
            Test myList = new Test();
            myList.Add(t1);
            myList.Add(t2);
            foreach (Test obj in myList)
            {
                Console.WriteLine("Name:- " + obj.Name + "Surname :- " + obj.Surname);
            }
            Console.ReadLine();

            //4.
            DogPack pack = new DogPack();
            pack.Add(new Dog("Lassie", 8));
            pack.Add(new Dog("Shep", 12));
            pack.Add(new Dog("Kirby", 10));
            pack.Add(new Dog("Jack", 15));
            pack.Cull();

            // Who's left?
            foreach (Dog d in pack)
                Console.WriteLine(d);
            Console.ReadLine();

            //5.
            Console.WriteLine(SimpleReturn());
            Console.WriteLine(SimpleReturn());
            Console.ReadLine();
            foreach (int i in YieldReturn())
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            //6.
            MyArrayList myList2 = new MyArrayList();
            myList2.Add("1");
            myList2.Add("2");
            myList2.Add("3");
            myList2.Add("4");
            foreach (object s in myList2)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();

            //7.
            // Let us first see how we can enumerate an custom MyList<t> class implementing IEnumerable<T>
            MyList<string> myListOfStrings = new MyList<string>();
            myListOfStrings.Add("one");
            myListOfStrings.Add("two");
            myListOfStrings.Add("three");
            myListOfStrings.Add("four");
            foreach (string s in myListOfStrings)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        class Test : IEnumerable
        {
            Test[] Items = null;
            int freeIndex = 0;

            public String Name { get; set; }
            public string Surname { get; set; }

            public Test()
            {
                Items = new Test[10];
            }

            public void Add(Test item)
            {
                Items[freeIndex] = item;
                freeIndex++;
            }

            public IEnumerator GetEnumerator()
            {
                foreach (object o in Items)
                {
                    if (o == null)
                    {
                        break;
                    }
                    yield return o;
                }
            }
        }

        internal class Dog
        {
            private readonly string _lassie;
            private readonly int _i;

            public Dog(string lassie, int i)
            {
                _lassie = lassie;
                _i = i;
            }

            public override string ToString()
            {
                return _lassie + "--" + _i;
            }
        }

        public class DogPack : IEnumerable<Dog>
        {
            private List<Dog> thePack;

            public DogPack()
            {
                thePack = new List<Dog>();
            }

            public void Add(Dog d)
            {
                thePack.Add(d);
            }

            // Remove arbitrary dog
            public void Cull()
            {
                if (thePack.Count == 0)
                    return;

                if (thePack.Count == 1)
                    thePack.RemoveAt(0);
                else
                {
                    Random rnd1 = new Random();
                    int indRemove = rnd1.Next(thePack.Count);
                    thePack.RemoveAt(indRemove);
                }
            }

            public IEnumerator<Dog> GetEnumerator()
            {
                return thePack.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        static int SimpleReturn()
        {
            return 1;
            return 2;
            return 3;
        }
        static IEnumerable<int> YieldReturn()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        class MyArrayList : IEnumerable
        {
            object[] m_Items = null;
            int freeIndex = 0;

            public MyArrayList()
            {
                // For the sake of simplicity lets keep them as arrays
                // ideally it should be link list
                m_Items = new object[100];
            }

            public void Add(object item)
            {
                // Let us only worry about adding the item 
                m_Items[freeIndex] = item;
                freeIndex++;
            }

            // IEnumerable Member
            public IEnumerator GetEnumerator()
            {
                foreach (object o in m_Items)
                {
                    // Lets check for end of list (its bad code since we used arrays)
                    if (o == null)
                    {
                        break;
                    }

                    // Return the current element and then on next function call 
                    // resume from next element rather than starting all over again;
                    yield return o;
                }
            }
        }

        class MyList<T> : IEnumerable<T>
        {
            T[] m_Items = null;
            int freeIndex = 0;

            public MyList()
            {
                // For the sake of simplicity lets keep them as arrays
                // ideally it should be link list
                m_Items = new T[100];
            }

            public void Add(T item)
            {
                // Let us only worry about adding the item 
                m_Items[freeIndex] = item;
                freeIndex++;
            }

            #region IEnumerable<T> Members

            public IEnumerator<T> GetEnumerator()
            {
                foreach (T t in m_Items)
                {
                    // Lets check for end of list (its bad code since we used arrays)
                    if (t == null) // this wont work is T is not a nullable type
                    {
                        break;
                    }

                    // Return the current element and then on next function call 
                    // resume from next element rather than starting all over again;
                    yield return t;
                }
            }

            #endregion

            #region IEnumerable Members
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                // Lets call the generic version here
                return this.GetEnumerator();
            }
            #endregion
        }
    }
}
