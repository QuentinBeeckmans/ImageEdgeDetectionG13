using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;


namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class EdgeTest
    {
        private const string FILE_URI = "C:\\Users\\lacpe\\Pictures\\Mario.png";

        private Bitmap originalBitmap = new Bitmap(FILE_URI);

        [TestMethod]
        public void Laplacian3x3FilterNotNull()
        {
            Bitmap bitmapResult = ExtBitmap.Laplacian3x3Filter(originalBitmap);
            Assert.IsNotNull(bitmapResult);
        }


        [TestMethod]
        public void ApplyLaplacian3x3FilterCorrectEdges()
        {
            Bitmap bitmapResult = ExtBitmap.Laplacian3x3Filter(originalBitmap);
            originalBitmap = ExtBitmap.ConvultionFilterTest(originalBitmap, Matrix.Laplacian3x3, 1.0, 0, true);

            CheckPixels(originalBitmap, bitmapResult);
        }

        private void CheckPixels(Bitmap originalBitmap, Bitmap bitmapResult)
        {
            for (int i = 0; i < originalBitmap.Width; i++)
                for (int x = 0; x < originalBitmap.Height; x++)
                {
                    Color cOriginal = originalBitmap.GetPixel(i, x);
                    Color cResult = bitmapResult.GetPixel(i, x);
                    Assert.AreEqual(cResult, cOriginal);
                }
        }

        /*
         
        public static Bitmap Laplacian3x3Filter(this Bitmap sourceBitmap, 
                                                    bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                    Matrix.Laplacian3x3, 1.0, 0, grayscale);

            return resultBitmap;
        }

        public static Bitmap Laplacian5x5Filter(this Bitmap sourceBitmap, 
                                                    bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                    Matrix.Laplacian5x5, 1.0, 0, grayscale);

            return resultBitmap;
        }

        public static Bitmap LaplacianOfGaussianFilter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                  Matrix.LaplacianOfGaussian, 1.0, 0, true);

            return resultBitmap;
        }*/


    }
}
