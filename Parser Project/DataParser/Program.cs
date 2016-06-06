using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionLogParser parse = new ActionLogParser();

            parse.logType = 20;

            string printme = parse.parseEField("Heading:213.048182923301");

            Console.WriteLine(printme);

            
            //ActionLogParser actionLogParser = new ActionLogParser();
            //String[] files = Directory.GetFiles("C:\\Users\\SELAB\\Documents\\Calgary Tornado 9_Master_Copy2");
            //foreach (String file in files)
            //{
            //    if (file.Contains("HICON_2016-05-24.14.06.150_1"))
            //    {
            //        XmlTextReader reader = new XmlTextReader(file);
            //        reader.Read();
            //        reader.Read();
            //        while (reader.Read() && (reader.NodeType != XmlNodeType.None))
            //        {
            //            while ((reader.NodeType != XmlNodeType.EndElement || reader.Name != "tblActionLog") && reader.NodeType != XmlNodeType.None)
            //            {
            //                reader.Read();

            //                if (reader.NodeType == XmlNodeType.Whitespace)
            //                    break;

            //                actionLogParser.parseInnerElement(reader);
            //            }

            //        }

            //        //int count = 0;
            //        //foreach (string split in splits)
            //        //{          
            //        //    var entity = new ActionLogField();
            //        //    //entity.ActionDetail =
            //        //    //entity.ActionLogType = 
            //        //    //entity.LogIndex = 
            //        //    //entity.SourceAssetID =
            //        //    //entity.TargetAssestID =
            //        //    //entity.TimeStamp = 
            //        //    Console.Out.WriteLine(split);
            //        //    rows.InsertOnSubmit(entity);
            //        //    count++;
            //        //    if (count % 100 == 0)
            //        //    {

            //        //        table.SubmitChanges();
            //        //    }
            //        //}


            //    }
            //}

        }
    }
}
