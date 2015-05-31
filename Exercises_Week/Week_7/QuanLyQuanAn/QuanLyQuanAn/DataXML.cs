using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyQuanAn
{
    public class DataXML
    {
        public static string Path_Data;
        string dataxml;
        public string DataXml
        {
            get { return dataxml; }
            set { dataxml = value; }
        }

        public static List<string> Read_DataXML()
        {
            List<string> Temp = new List<string>();
            XDocument doc = new XDocument();
            doc = XDocument.Load(Path_Data);
            var Elements = from element in doc.Elements("QLQA").Elements("QUANAN")
                           select element;
            foreach(var node in Elements)
            {
                string value = node.Attribute("Quan").Value;
                if (Check(Temp, value))
                    Temp.Add(value);
            }
            return Temp;
        }

        public static void Add_Node_Data(QuanAn QA)
        {
            XDocument doc = new XDocument();
            doc = XDocument.Load(Path_Data);
            XElement node = doc.Element("QLQA");
            XElement Quan = new XElement("QUANAN",
                new XAttribute("Ten", QA.Ten),
                new XAttribute("Duong", QA.DiaDiem.Duong),
                new XAttribute("Quan", QA.DiaDiem.Quan),
                new XAttribute("Soban", QA.SoBan));
            node.Add(Quan);
            doc.Save(Path_Data);
        }

        public static void Remove(int index, string key)
        {
            XDocument doc = new XDocument();
            doc = XDocument.Load(Path_Data);
            var Elements = from element in doc.Elements("QLQA").Elements("QUANAN")
                           where element.Attribute("Quan").Value == key
                           select element;
            int dem = -1;
            foreach (var node in Elements)
            {
                dem++;
                if (dem == index)
                {
                    node.Remove();
                    break;
                }
            }
            doc.Save(Path_Data);
        }
        public static void Update_Data(QuanAn Old, QuanAn New)
        {
            XDocument doc = new XDocument();
            doc = XDocument.Load(Path_Data);
            var Elements = from element in doc.Elements("QLQA").Elements("QUANAN")
                           where element.Attribute("Ten").Value == Old.Ten &&
                                 element.Attribute("Duong").Value == Old.DiaDiem.Duong &&
                                 element.Attribute("Quan").Value == Old.DiaDiem.Quan &&
                                 Convert.ToInt32(element.Attribute("Soban").Value) == Old.SoBan
                           select element;
            foreach (var node in Elements)
            {
                node.SetAttributeValue("Ten", New.Ten);
                node.SetAttributeValue("Duong", New.DiaDiem.Duong);
                node.SetAttributeValue("Soban", New.SoBan);
                break;
            }
            doc.Save(Path_Data);
        }
        public static bool Check(List<string> LS, string key)
        {
            for (int i = 0; i < LS.Count; i++)
                if (LS[i] == key)
                    return false;
            return true;
        }
        public static List<QuanAn> Read_QuanAn_XML(string key)
        {
            List<QuanAn> Temp = new List<QuanAn>();
            XDocument doc = new XDocument();
            doc = XDocument.Load(Path_Data);
            var Elements = from element in doc.Elements("QLQA").Elements("QUANAN")
                           where element.Attribute("Quan").Value == key
                           select element;
            foreach (var node in Elements)
            {
                QuanAn QA = new QuanAn();
                QA.Ten = node.Attribute("Ten").Value;
                QA.DiaDiem = new Diadiem() { Duong = node.Attribute("Duong").Value, Quan = node.Attribute("Quan").Value };
                Temp.Add(QA);
            }
            return Temp;
        }
        public static QuanAn Get_Node_Data(int index, string key)
        {
            QuanAn QA = new QuanAn();
            XDocument doc = new XDocument();
            doc = XDocument.Load(Path_Data);
            var Elements = from element in doc.Elements("QLQA").Elements("QUANAN")
                           where element.Attribute("Quan").Value == key
                           select element;
            int dem = -1;
            foreach (var node in Elements)
            {
                dem++;
                if (dem == index)
                {
                    QA.Ten = node.Attribute("Ten").Value;
                    QA.DiaDiem.Duong = node.Attribute("Duong").Value;
                    QA.SoBan = Convert.ToInt32(node.Attribute("Soban").Value);
                    QA.DiaDiem.Quan = key;
                    break;
                }
            }
            return QA;
        }
    }
    
}
