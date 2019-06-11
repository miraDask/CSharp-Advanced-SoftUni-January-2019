namespace BoxOfT
{
    public class StartUp
    {
        public static void Main()
        {
            Box<int> container = new Box<int>();

            container.Add(1);
            container.Add(12);
            container.Add(14);
            container.Add(156);
            System.Console.WriteLine(container.Remove());
            System.Console.WriteLine(container);
        }
    }
}
