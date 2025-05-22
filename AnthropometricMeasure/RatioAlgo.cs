using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnthropometricMeasure
{
    public class RatioAlgo
    {
        // W = (Y . X Tranpose ) (X . X Tranpose + Lamba - Identity Matrix)



        MatrixCal matrixCal = new MatrixCal();

        // lambda: A regularization parameter (ridge regression parameter) used in the calculation of matrixw.
        // It helps prevent issues with multicollinearity and overfitting when calculating the inverse of (X * X_transpose).
        double lamba = 0.50;

        /// <summary>
        /// Calculates the transformation matrix 'matrixw'.
        /// This matrix is likely used to calibrate or adjust raw measurements obtained from keypoints.
        /// The formula W = (Y * X_transpose) * Inverse(X * X_transpose + lambda * I) resembles
        /// a form of regularized least squares regression, where X and Y are predefined calibration matrices.
        /// </summary>
        public double[][] matrixwcal() {

            double[][] matrixw, matrixx, matrixy, matrixxtrapose, matrixpart1val, matrixpart2val, matrixpart3val, matrixI;


            matrixx = matrixCal.MatrixCreate(7, 1);

            matrixy = matrixCal.MatrixCreate(7, 1);

            matrixxtrapose = matrixCal.MatrixCreate(1, 7);

            matrixw = matrixCal.MatrixCreate(7, 7);

            matrixpart1val= matrixCal.MatrixCreate(7, 7);

            matrixpart2val = matrixCal.MatrixCreate(7, 7);

            matrixpart3val= matrixCal.MatrixCreate(7, 7);


            matrixI = matrixCal.MatrixCreate(7, 7);

            // matrixx: Appears to be a hardcoded set of reference input measurements (e.g., from a specific calibration subject or dataset).
            // These values are used in conjunction with matrixy to calculate the transformation matrix 'matrixw'.
            matrixx[1][1] = 72.597;
            matrixx[2][1] = 61.504;
            matrixx[3][1] = 56.222;
            matrixx[4][1] = 115.277;
            matrixx[5][1] = 45.382;
            matrixx[6][1] = 89.17;
            matrixx[7][1] = 72.683;

            // matrixy: Appears to be a hardcoded set of corresponding true/output measurements for the reference input 'matrixx'.
            // These values are used to calibrate the transformation matrix 'matrixw'.
            matrixy[1][1] = 44;
            matrixy[2][1] = 33;
            matrixy[3][1] = 27;
            matrixy[4][1] = 63;
            matrixy[5][1] = 23;
            matrixy[6][1] = 51;
            matrixy[7][1] = 45;

            matrixxtrapose[1][1] = matrixx[1][1];
            matrixxtrapose[1][2] = matrixx[2][1];
            matrixxtrapose[1][3] = matrixx[3][1];
            matrixxtrapose[1][4] = matrixx[4][1];
            matrixxtrapose[1][5] = matrixx[5][1];
            matrixxtrapose[1][6] = matrixx[6][1];
            matrixxtrapose[1][7] = matrixx[7][1];


            matrixI = matrixCal.MatrixIdentity(7);

            matrixpart1val = matrixCal.MatrixProduct(matrixy, matrixxtrapose);

            matrixpart2val = matrixCal.MatrixProduct(matrixx, matrixxtrapose);

            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++)
                    matrixpart2val[i][ j] = matrixpart2val[i][j] + (lamba *matrixI[i][j]);
            }

            matrixpart3val = matrixCal.MatrixInverse(matrixpart2val);

            matrixw = matrixCal.MatrixProduct(matrixpart1val, matrixpart3val);


            return matrixw;  

        }
       


    }
}