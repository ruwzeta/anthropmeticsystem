using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AnthropometricMeasure
{
    public class JsonRead
    {

        

      

        public void LoadJson()

        {

            double[] miu = new double[5];

            using (StreamReader r = new StreamReader(@"c:\Users\Ruwindhu\Desktop\openpose-1.3.0-win64-gpu-binaries\output\test sub 5_keypoints.json"))
            {
                string json = r.ReadToEnd();
                List<BodyPoints> items = JsonConvert.DeserializeObject<List<BodyPoints>>(json);

                Console.WriteLine(items);


                BodyDistances bodyDistances = new BodyDistances();


                for (var i = 0; i < items.Count; i++)
                {
                    if (i == 0) {

                        // Pythagores used to caluate distance between 2 coordinates 
                        bodyDistances.d1 =  Math.Sqrt(Math.Pow((items[i].x6 - items[i].x3),2) + Math.Pow((items[i].y6 - items[i].y3), 2) ) ;

                        bodyDistances.d2 = Math.Sqrt(Math.Pow((items[i].x4 - items[i].x3), 2) + Math.Pow((items[i].y4 - items[i].y3), 2));

                        bodyDistances.d3 = Math.Sqrt(Math.Pow((items[i].x5 - items[i].x4), 2) + Math.Pow((items[i].y5 - items[i].y4), 2));

                        bodyDistances.d4 = Math.Sqrt(Math.Pow((items[i].x9 - items[i].x3), 2) + Math.Pow((items[i].y9 - items[i].y3), 2));

                        bodyDistances.d5 = Math.Sqrt(Math.Pow((items[i].x9 - items[i].x12), 2) + Math.Pow((items[i].y9 - items[i].y12), 2));

                        bodyDistances.d6 = Math.Sqrt(Math.Pow((items[i].x9 - items[i].x10), 2) + Math.Pow((items[i].y9 - items[i].y10), 2));

                        bodyDistances.d7 = Math.Sqrt(Math.Pow((items[i].x10 - items[i].x11), 2) + Math.Pow((items[i].y10 - items[i].y11), 2));


                    }

                }



            

              



            }
        }
    }
}