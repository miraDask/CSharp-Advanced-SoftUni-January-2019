namespace GenericArrayCreator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] names = ArrayCreator.Create(4,"Pesho");
            int[] numbers = ArrayCreator.Create(10, 20);

            Console.WriteLine();
        }
    }
}
