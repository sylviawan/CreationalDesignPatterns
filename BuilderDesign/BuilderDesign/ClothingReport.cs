using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderDesign
{
    public class ClothingItem
    {
        public string Name;
        public double Price;
        public string Type;
        public string Size;

        public ClothingItem(string productName, double price, string type, string size)
        {
            this.Name = productName;
            this.Price = price;
            this.Type = type;
            this.Size = size;
        }
    }

    public class ClothingReport
    {
        public string TitleSection;
        public string DetailsSection;
        public string LogisticsSection;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DetailsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }

    public interface IClothingItemBuilder
    {
        IClothingItemBuilder AddTitle();
        IClothingItemBuilder AddDetails();
        IClothingItemBuilder AddLogistics(DateTime dateTime);
        ClothingReport GetProductReport();
    }

    public class ClothingReportBuilder : IClothingItemBuilder
    {
        private ClothingReport _report;
        private IEnumerable<ClothingItem> _items;

        public ClothingReportBuilder(IEnumerable<ClothingItem> items)
        {
            Reset();
            _items = items;
        }

        public IClothingItemBuilder AddTitle()
        {
            _report.TitleSection = "\n\n------- Items in Shopping Cart -------\n\n";
            return this;
        }

        public IClothingItemBuilder AddDetails()
        {
            _report.DetailsSection = string.Join(Environment.NewLine, _items.Select(product =>
                $"Product: {product.Name} \nPrice: {product.Price} \n" +
                $"Product Type: {product.Type} \nSize: {product.Size} \n"));

            return this;
        }

        public IClothingItemBuilder AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Items added on {dateTime}";
            return this;
        }

        public ClothingReport GetProductReport()
        {
            ClothingReport finishedReport = _report;
            Reset();

            return finishedReport;
        }

        public void Reset()
        {
            _report = new ClothingReport();
        }
    }

    public class ItemBuildDirector
    {
        private IClothingItemBuilder _builder;

        public ItemBuildDirector(IClothingItemBuilder concreteBuilder)
        {
            _builder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDetails();
            _builder.AddLogistics(DateTime.Now);
        }
    }
}
