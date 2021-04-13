using System;
using System.Collections.Generic;

namespace BuilderDesign
{
    class Program
    {

        static void Main(string[] args)
        {
            var items = new List<ClothingItem>
            {
                new ClothingItem("Tshirt", 15.99, "Tops", "S"),
                new ClothingItem("Skirt", 35, "Bottoms", "XS"),
                new ClothingItem("Scarf", 8.99, "Accessory", "One Size"),
            };

            var itemBuilder = new ClothingReportBuilder(items);
            var director = new ItemBuildDirector(itemBuilder);

            director.BuildCompleteReport();
            var directorReport = itemBuilder.GetProductReport();
            Console.WriteLine(directorReport.Debug());

        }
    }
}
