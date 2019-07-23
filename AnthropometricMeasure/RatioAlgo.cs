using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnthropometricMeasure
{
    public class RatioAlgo
    {
        // W = (Y . X Tranpose ) (X . X Tranpose + Lamba - Identity Matrix)



        BodyMeasurements bodyMeasurements = new BodyMeasurements();

        

        public double[][] matrixwcal() {

            double[][] matrixw, matrixx, matrixy, matrixxtrapose, matrixpart1val, matrixpart2val, matrixpart3val, matrixI;


            matrixx = bodyMeasurements.MatrixCreate(7, 1);

            matrixy = bodyMeasurements.MatrixCreate(7, 1);

            matrixxtrapose = bodyMeasurements.MatrixCreate(1, 7);

            matrixw = bodyMeasurements.MatrixCreate(7, 7);

            matrixpart1val= bodyMeasurements.MatrixCreate(7, 7);

            matrixpart2val = bodyMeasurements.MatrixCreate(7, 7);

            matrixpart3val= bodyMeasurements.MatrixCreate(7, 7);


            matrixI = bodyMeasurements.MatrixCreate(7, 7);

            matrixx[1][1] = 73.275;
            matrixx[2][1] = 73.275;
            matrixx[3][1] = 73.275;
            matrixx[4][1] = 73.275;
            matrixx[5][1] = 73.275;
            matrixx[6][1] = 73.275;
            matrixx[7][1] = 73.275;

            matrixy[1][1] = 73.275;
            matrixy[2][1] = 73.275;
            matrixy[3][1] = 73.275;
            matrixy[4][1] = 73.275;
            matrixy[5][1] = 73.275;
            matrixy[6][1] = 73.275;
            matrixy[7][1] = 73.275;

            matrixxtrapose[1][1] = matrixx[1][1];
            matrixxtrapose[1][2] = matrixx[2][1];
            matrixxtrapose[1][3] = matrixx[3][1];
            matrixxtrapose[1][4] = matrixx[4][1];
            matrixxtrapose[1][5] = matrixx[5][1];
            matrixxtrapose[1][6] = matrixx[6][1];
            matrixxtrapose[1][7] = matrixx[7][1];


            matrixI = bodyMeasurements.MatrixIdentity(7);

            matrixpart1val = bodyMeasurements.MatrixProduct(matrixy, matrixxtrapose);

            matrixpart2val = bodyMeasurements.MatrixProduct(matrixx, matrixxtrapose);

            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++)
                    matrixpart2val[i][ j] = matrixpart2val[i][j] + matrixI[i][j];
            }

            matrixpart3val = bodyMeasurements.MatrixInverse(matrixpart2val);

            matrixw = bodyMeasurements.MatrixProduct(matrixpart1val, matrixpart3val);


            return matrixw;  

        }
       


    }
}