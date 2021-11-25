using System.Drawing;
using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const string FILE_URI = "C:\\img\\orca.png";
        private Bitmap originalBitmap = new Bitmap(FILE_URI);

        [TestMethod]
        public void ApplyCrazyFilterIsNotNull()
        {
            Bitmap bitmap = ExtBitmap.ApplySwapFilter(originalBitmap);
            Assert.IsNotNull(bitmap);
        }

        [TestMethod]
        public void ApplyCrazyFilterCorrectColors()
        {
            Bitmap bitmapResult = ExtBitmap.ApplyCrazyFilter(originalBitmap);
            int alpha = 1;
            int red = 1;
            int blue = 2;
            int green = 1;

            for (int i = 0; i < originalBitmap.Width; i++)
                for (int x = 0; x < originalBitmap.Height; x++)
                {
                    Color cOriginal = originalBitmap.GetPixel(i, x);
                    Color cResult = bitmapResult.GetPixel(i, x);
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
