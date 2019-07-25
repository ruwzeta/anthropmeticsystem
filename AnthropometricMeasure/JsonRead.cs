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
        
      

        public MeasurementModel LoadJson()

        {

            double[][] matrixX;
            double[][] matrixW,matrixY;
            

            MatrixCal matrixCal = new MatrixCal();

            DistanceAlgo distanceAlgo = new DistanceAlgo();

            MeasurementModel realmeasurements = new MeasurementModel();
            

            using (StreamReader r = new StreamReader(@"c:\Users\Ruwindhu\Desktop\openpose-1.3.0-win64-gpu-binaries\output\test sub 5_keypoints.json"))
            {
                string json = r.ReadToEnd();
                List<BodyPoints> items = JsonConvert.DeserializeObject<List<BodyPoints>>(json);


                BodyDistances bodyDistances = new BodyDistances();

                RatioAlgo ratioAlgo = new RatioAlgo();


                for (var i = 0; i < items.Count; i++)
                {


                    // Pythagoras used to caluate distance between 2 coordinates 
                    

                        bodyDistances.d1 = distanceAlgo.distanceBetweenPoints(items[i].x6, items[i].y6, items[i].x3, items[i].y3);

                        bodyDistances.d2 = distanceAlgo.distanceBetweenPoints(items[i].x4, items[i].y4, items[i].x3, items[i].y3);

                        bodyDistances.d3 = distanceAlgo.distanceBetweenPoints(items[i].x4, items[i].y4, items[i].x5, items[i].y5);

                        bodyDistances.d4 = distanceAlgo.distanceBetweenPoints(items[i].x9, items[i].y9, items[i].x3, items[i].y3);

                        bodyDistances.d5 = distanceAlgo.distanceBetweenPoints(items[i].x9, items[i].y9, items[i].x12, items[i].y12);

                        bodyDistances.d6 = distanceAlgo.distanceBetweenPoints(items[i].x9, items[i].y9, items[i].x10, items[i].y10);

                        bodyDistances.d7 = distanceAlgo.distanceBetweenPoints(items[i].x10, items[i].y10, items[i].x11, items[i].y11);



                    matrixX = matrixCal.MatrixCreate(7, 1);


                    matrixX[1][1] = bodyDistances.d1;
                    matrixX[2][1] = bodyDistances.d2;
                    matrixX[3][1] = bodyDistances.d3;
                    matrixX[4][1] = bodyDistances.d4;
                    matrixX[5][1] = bodyDistances.d5;
                    matrixX[6][1] = bodyDistances.d6;
                    matrixX[7][1] = bodyDistances.d7;


                    matrixW = matrixCal.MatrixCreate(7, 7);

                    matrixW = ratioAlgo.matrixwcal();

                    matrixY = matrixCal.MatrixCreate(7, 1);

                    matrixY = matrixCal.MatrixProduct(matrixW, matrixX);



                    realmeasurements.shoulderlength = matrixY[1][1];
                    realmeasurements.upperArmLegth = matrixY[2][1];
                    realmeasurements.lowerArmLegth = matrixY[3][1];
                    realmeasurements.shouldertoHip = matrixY[4][1];
                    realmeasurements.hipCrossLength = matrixY[5][1];
                    realmeasurements.kneelegth = matrixY[6][1];
                    realmeasurements.kneetoToeLength = matrixY[7][1];

                }

                return realmeasurements;

            }
        }
    }
}