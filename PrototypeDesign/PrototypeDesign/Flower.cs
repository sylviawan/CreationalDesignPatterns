using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeDesign
{

    public abstract class Prototype
    {
        public abstract Prototype ShallowCopy();
        public abstract Prototype DeepCopy();
        public abstract void Debug();
    }

    public class FlowerInfo
    {
        public int id;

        public FlowerInfo(int id)
        {
            this.id = id;
        }
    }
    public class Flower : Prototype
    {
        public string flowerName;
        public bool isNativeFlower;
        public string[] flowerColors;
        public FlowerInfo info;

        public Flower(string name, bool nativeFlower, string[] color, FlowerInfo info)
        {
            this.flowerName = name;
            this.isNativeFlower = nativeFlower;
            this.flowerColors = color;
            this.info = info;
        }

        public override Prototype ShallowCopy()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override Prototype DeepCopy()
        {
            Flower clonedFlower = (Flower)this.MemberwiseClone();
            clonedFlower.info = new FlowerInfo(this.info.id);
            return clonedFlower;
        }

        public override void Debug()
        {
            Console.WriteLine("- Flowers - ");
            Console.WriteLine("Flower name: {0} \nNative: {1} ", this.flowerName, this.isNativeFlower);
            Console.WriteLine("Flower ID: {0}", this.info.id);
            Console.WriteLine("Flower colors: " + string.Join(",", flowerColors) + "\n");
        }
    } 
}
