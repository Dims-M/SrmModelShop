using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RaboraXML
{
    /// <summary>
    /// Логика работы с Xml файлами
    /// </summary>
    public class RabXml
    {
        /// <summary>
        /// Чтение файла Xml
        /// </summary>
        public string ReadingXml()
        {
           // string patch = @"users.xml";
            string patch = @"users2.xml";
            string tempItem ="";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(patch);

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            // обход всех узлов в корневом элементе

            foreach (XmlNode xnode in xRoot)
            {

                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Header");
                    if (attr != null)
                        tempItem += $"ИМЯ узла{attr.Value}\t\n";
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - company
                    if (childnode.Name == "company\t\n")
                    {
                        tempItem +=  $"Компания: {childnode.InnerText}\t\n";
                    }
                    // если узел age
                    if (childnode.Name == "age\t\n")
                    {
                        tempItem += ($"Возраст: {childnode.InnerText}\t\n");
                    }
                }

            }
            return tempItem;
        }


    }
}
