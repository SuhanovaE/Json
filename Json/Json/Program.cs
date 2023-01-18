using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Json
{
    public class PointMap
    {
        public double coor_x { get; set;}
        public double coor_y { get; set; }
        public string Name_place { get; set; }

        public PointMap() { }

        public PointMap(double _x, double _y, string name) 
        {
            coor_x= _x;
            coor_y = _y;
            Name_place = name;
        }

    }
    class Program
    {
        static void Main(string[] args) 
        {
            List<PointMap> pointMaps= new List<PointMap>();

            //1
            //PointMap point = new PointMap(37.21313, 48.2140044, "Магазин");

            //string JsonObject = JsonConvert.SerializeObject(point);

            //Console.WriteLine(JsonObject);

            //PointMap point3 = JsonConvert.DeserializeObject<PointMap>(JsonObject);

            //Console.WriteLine(point3.coor_x + " " + point3.coor_y + " " + point3.Name_place);


            //2
            PointMap point0 = new PointMap(37.11, 48.11, "Магазин");
            PointMap point1 = new PointMap(37.22, 48.22, "Больница");
            PointMap point2 = new PointMap(37.33, 48.33, "Аптека");
            PointMap point3 = new PointMap(37.44, 48.44, "Остановка");
            pointMaps.Add(point0);
            pointMaps.Add(point1);
            pointMaps.Add(point2);
            pointMaps.Add(point3);

            File.WriteAllText("input.json", string.Empty);
            for (int i = 0; i < pointMaps.Count; i++)
                File.AppendAllText("input.json", JsonConvert.SerializeObject(pointMaps[i]));



            //File.AppendAllText("input.json", JsonConvert.SerializeObject(point0));

            //3
            //pointMaps.Clear();
            JsonReader reader = new JsonTextReader(new StreamReader("input.json"));
            reader.SupportMultipleContent= true;
            while (true)
            {
                if(!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer= new JsonSerializer();
                PointMap temp_point = serializer.Deserialize<PointMap>(reader);

                pointMaps.Add(temp_point);
            }

            Console.ReadKey();
        }
    }
    
}
