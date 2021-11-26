using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;


namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class FilterTest
    {
        private const string FILE_URI = "C:\\Users\\lacpe\\Pictures\\Mario.png";
        private Bitmap originalBitmap = new Bitmap(FILE_URI);

        [TestMethod]
        public void ApplySwapFilterIsNotNull()
        {
            Bitmap bitmap = ExtBitmap.ApplySwapFilter(originalBitmap);
            Assert.IsNotNull(bitmap);
        }

        [TestMethod]
        public void ApplyCrazyFilterCorrectColors()
        {
            Bitmap bitmapResult = ExtBitmap.ApplyCrazyFilter(originalBitmap); //Keep in a variable the applicated filter on picture
            int alpha = 1;
            int red = 1;
            int blue = 2;
            int green = 1;

            for (int i = 0; i < originalBitmap.Width; i++)
                for (int x = 0; x < originalBitmap.Height; x++)
                {
                    Color cOriginal = originalBitmap.GetPixel(i, x); //Retrieve color from original picture
                    Color cResult = bitmapResult.GetPixel(i, x); //Retrieve color from transformed picture
                    Assert.AreEqual(cResult.A, cOriginal.A / alpha);
                    Assert.AreEqual(cResult.R, cOriginal.R / red);
                    Assert.AreEqual(cResult.B, cOriginal.B / blue);
                    Assert.AreEqual(cResult.G, cOriginal.G / green);
                }
        }

        [TestMethod]
        public void ApplySwapFilterCorrectColors()
        {
            Bitmap resultBitmap = ExtBitmap.ApplyFilterSwap(originalBitmap);
            /*
            int alpha = 1;
            int red = 1;
            int blue = 2;
            int green = 1;
            */

            for (int i = 0; i < originalBitmap.Width; i++)
                for (int x = 0; x < originalBitmap.Height; x++)
                {
                    Color cOriginal = originalBitmap.GetPixel(i, x);
                    Color cResult = resultBitmap.GetPixel(i, x);
                    Assert.AreEqual(cResult.A, cOriginal.A);
                    Assert.AreEqual(cResult.G, cOriginal.G);
                    Assert.AreEqual(cResult.B, cOriginal.B);
                    Assert.AreEqual(cResult.R, cOriginal.R);

                }
        }
    }
}
