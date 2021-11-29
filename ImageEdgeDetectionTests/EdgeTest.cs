using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;


namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class EdgeTest
    {
        private Bitmap originalBitmap = ImageEdgeDetectionTests.Properties.Resources.Mario;

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

        [TestMethod]
        public void ApplyLaplacian5x5FilterCorrectEdges()
        {
            Bitmap bitmapResult = ExtBitmap.Laplacian5x5Filter(originalBitmap);
            originalBitmap = ExtBitmap.ConvultionFilterTest(originalBitmap, Matrix.Laplacian5x5, 1.0, 0, true);

            CheckPixels(originalBitmap, bitmapResult);
        }

        [TestMethod]
        public void ApplyLaplacianOfGaussianFilterCorrectEdges()
        {
            Bitmap bitmapResult = ExtBitmap.LaplacianOfGaussianFilter(originalBitmap);
            originalBitmap = ExtBitmap.ConvultionFilterTest(originalBitmap, Matrix.LaplacianOfGaussian, 1.0, 0, true);

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


        public static Bitmap LaplacianOfGaussianFilter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                  Matrix.LaplacianOfGaussian, 1.0, 0, true);

            return resultBitmap;
        }
        
         */


    }
}
