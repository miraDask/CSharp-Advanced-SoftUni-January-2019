namespace GenericScale
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string left = "Ana";
            string right = "Anna";
            EqualityScale<string> scale = new EqualityScale<string>(left, right);

            Console.WriteLine(scale.AreEqual());

            int leftNum = 5;
            int rightNum = 05;
            EqualityScale<int> numScale = new EqualityScale<int>(leftNum, rightNum);

            Console.WriteLine(numScale.AreEqual());
        }
    }
}
