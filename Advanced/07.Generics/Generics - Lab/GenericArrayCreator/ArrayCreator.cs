using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            T[] arr = new T[lenght];
            for (int i = 0; i < lenght; i++)
            {
                arr[i] = item;
            }
            return arr;
        }
    }
}
