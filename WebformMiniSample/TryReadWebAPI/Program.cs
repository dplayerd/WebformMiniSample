using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace TryReadWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            AClass aClass = new AClass();
            aClass.Name = "Tim";
            aClass.Age = 28;


            // JSON 序列化： 把記憶體中的物件轉為文字
            string jsonText = 
                Newtonsoft.Json.JsonConvert.SerializeObject(aClass);
            /* {
                  "Name": "Tim",
                  "Age": 28
             }
            */

            // JSON 反序列化： 把文字轉為記憶體中的物件
            AClass obj = 
                Newtonsoft.Json.JsonConvert.DeserializeObject<AClass>(jsonText);

            obj.Name = "Time";
            obj.Age = 28;


            ////Console.WriteLine(jsonText);
            //Console.ReadLine();
        }

        public static void WriteName(AClass aClass)
        {
            Console.WriteLine(aClass.Name);
        }


        public class AClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
