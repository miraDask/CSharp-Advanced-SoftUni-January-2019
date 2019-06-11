namespace GenericArrayCreator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            T[] newArr = new T[length];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = element;
            }

            return newArr;
        }   
    }
}
