using System;

namespace Ireckonu.DomainModel
{
    public class IruData
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string ArticleCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Q1 { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
    }
}
