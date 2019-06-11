namespace _09.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfRectangles = input[0];
            int numberOfIntersections = input[1];

            for (int i = 0; i < numberOfRectangles; i++)
            {
                string[] rectangleData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string id = rectangleData[0];
                double width = double.Parse(rectangleData[1]);
                double height = double.Parse(rectangleData[2]);
                double x = double.Parse(rectangleData[3]);
                double y = double.Parse(rectangleData[4]);

                Rectangle currentRectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(currentRectangle);
            }

            for (int i = 0; i < numberOfIntersections; i++)
            {
                string[] rectanglesToCompare = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string idOfFirstRectangle = rectanglesToCompare[0];
                string idOfSecondRectangle = rectanglesToCompare[1];

                var firstRectangle = rectangles.Find(x => x.Id == idOfFirstRectangle);
                var secondRectangle = rectangles.Find(x => x.Id == idOfSecondRectangle);

                Console.WriteLine(firstRectangle.Interracts(secondRectangle).ToString().ToLower());

            }
        }
    }
}
