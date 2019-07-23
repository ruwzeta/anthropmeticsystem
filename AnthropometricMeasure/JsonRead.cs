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
        
      

        public BodyDistances LoadJson()

        {

            double[][] matrixX;
            double[][] matrixW,matrixY;
            

            BodyMeasurements bodyMeasurements = new BodyMeasurements();

            BodyDistances realmeasurements = new BodyDistances();
            

            using (StreamReader r = new StreamReader(@"c:\Users\Ruwindhu\Desktop\openpose-1.3.0-win64-gpu-binaries\output\test sub 5_keypoints.json"))
            {
                string json = r.ReadToEnd();
                List<BodyPoints> items = JsonConvert.DeserializeObject<List<BodyPoints>>(json);

               

                BodyDistances bodyDistances = new BodyDistances();

                RatioAlgo ratioAlgo = new RatioAlgo();


                for (var i = 0; i < items.Count; i++)
                {
                    

                        // Pythagores used to caluate distance between 2 coordinates 
                        bodyDistances.d1 =  Math.Sqrt(Math.Pow((items[i].x6 - items[i].x3),2) + Math.Pow((items[i].y6 - items[i].y3), 2) ) ;

                        bodyDistances.d2 = Math.Sqrt(Math.Pow((items[i].x4 - items[i].x3), 2) + Math.Pow((items[i].y4 - items[i].y3), 2));

                        bodyDistances.d3 = Math.Sqrt(Math.Pow((items[i].x5 - items[i].x4), 2) + Math.Pow((items[i].y5 - items[i].y4), 2));

                        bodyDistances.d4 = Math.Sqrt(Math.Pow((items[i].x9 - items[i].x3), 2) + Math.Pow((items[i].y9 - items[i].y3), 2));

                        bodyDistances.d5 = Math.Sqrt(Math.Pow((items[i].x9 - items[i].x12), 2) + Math.Pow((items[i].y9 - items[i].y12), 2));

                        bodyDistances.d6 = Math.Sqrt(Math.Pow((items[i].x9 - items[i].x10), 2) + Math.Pow((items[i].y9 - items[i].y10), 2));

                        bodyDistances.d7 = Math.Sqrt(Math.Pow((items[i].x10 - items[i].x11), 2) + Math.Pow((items[i].y10 - items[i].y11), 2));

                    matrixX = bodyMeasurements.MatrixCreate(7, 1);


                    matrixX[1][1] = bodyDistances.d1;
                    matrixX[2][1] = bodyDistances.d2;
                    matrixX[3][1] = bodyDistances.d3;
                    matrixX[4][1] = bodyDistances.d4;
                    matrixX[5][1] = bodyDistances.d5;
                    matrixX[6][1] = bodyDistances.d6;
                    matrixX[7][1] = bodyDistances.d7;


                    matrixW = bodyMeasurements.MatrixCreate(7, 7);

                    matrixW = ratioAlgo.matrixwcal();

                    matrixY = bodyMeasurements.MatrixCreate(7, 1);

                    matrixY = bodyMeasurements.MatrixProduct(matrixW, matrixX);



                    realmeasurements.d1 = matrixY[1][1];
                    realmeasurements.d2 = matrixY[2][1];
                    realmeasurements.d3 = matrixY[3][1];
                    realmeasurements.d4 = matrixY[4][1];
                    realmeasurements.d5 = matrixY[5][1];
                    realmeasurements.d6 = matrixY[6][1];
                    realmeasurements.d7 = matrixY[7][1];


                   

                }

                return realmeasurements;

            }
        }
    }
}