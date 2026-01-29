using RfrmLib.Domain.Entity;
using System.Collections.Generic;
using System.Xml;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Data.Implementation.XmlDataReader
{
    internal static class PayReaderHelper
    {
        internal static (Pay, string) ReadPay(string xmlInputFileFullname)
        {
            using XmlReader reader = XmlReader.Create(xmlInputFileFullname);

            XmlDocument doc = new();
            List<Item> items = [];

            while (reader.Read())
            {
                if (NeedSkipNode(reader)) continue;
                var node = SelectItemNode(doc, reader);
                var item = ParseItem(node);
                if(item.Name.Length > 0 && item.Surname.Length > 0)
                    items.Add(item);
            }
            return (new Pay(string.Empty, items), string.Empty);

        }

        private static bool NeedSkipNode(XmlReader xmlReader) =>
            xmlReader.NodeType != XmlNodeType.Element || xmlReader.Name != __item;

        private static XmlNode SelectItemNode(XmlDocument doc, XmlReader xmlReader)
        {
            doc.LoadXml(xmlReader.ReadOuterXml());
            return doc.SelectSingleNode(__item)!;
        }

        private static Item ParseItem(XmlNode node)
        {
            var emptyItem = new Item(string.Empty, string.Empty, string.Empty, string.Empty);
            if (node.Attributes!.Count < 1)
                return emptyItem;
            string name = node.Attributes[__name]!.Value;
            string surname = node.Attributes[__surname]!.Value;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(surname))
                return emptyItem;
            string amount = node.Attributes[__amount]!.Value;
            string mount = node.Attributes[__mount]!.Value;
            return new Item(name, surname, amount, mount);
        }
    }
}
