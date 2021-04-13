using System;

namespace PrototypeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Native Island Flower -- ");

            Flower originalFlower = new Flower("Lillies", true, new string[] { "Red", "White", "Yellow" }, new FlowerInfo(1));
            originalFlower.Debug();

            Console.WriteLine("-- Cloned Island Flower -- ");
            Flower clonedFlower = (Flower)originalFlower.DeepCopy();
            clonedFlower.Debug();

            Console.WriteLine("Flower changes: ");
            originalFlower.flowerName = "Tulips";
            originalFlower.isNativeFlower = false;
            originalFlower.info.id = 2;
            originalFlower.Debug();
            clonedFlower.Debug();
        }
    }
}