// From Local Another change

// this is edited on web
﻿using System;
using Android.Graphics;


namespace CustomImageOrCameraChooser
{
    public class BitmapProcessor
    {
        private Bitmap _bitmap;

        public Bitmap getBitmap()
        {
            return this._bitmap;
        }

        public BitmapProcessor(Android.Graphics.Bitmap bitmap)
        {
            this._bitmap = bitmap;
        }

        public BitmapProcessor(Android.Graphics.Bitmap bitmap, int maxWidth, int maxHeight)
        {
            this._bitmap = bitmap;

            this.resizeIfBiggerThan(maxWidth, maxHeight);
        }

        public BitmapProcessor(Android.Graphics.Bitmap bitmap, int maxWidth, int maxHeight, int hue)
        {
            this._bitmap = bitmap;
            this.resizeIfBiggerThan(maxWidth, maxHeight);
            this.adjustHue(hue);
        }


        public Android.Graphics.Bitmap resizeIfBiggerThan(int maxWidth, int maxHeight)
        {
            int originalWidth = this._bitmap.Width;
            int originalHeight = this._bitmap.Height;
            int newWidth = originalWidth;
            int newHeight = originalHeight;
            float ratio = 1.0f;

            if (originalWidth >= maxWidth || originalHeight >= maxHeight)
            {
                if (originalWidth >= maxWidth)
                {
                    ratio = originalWidth / (float)maxWidth;
                    newWidth = maxWidth;
                    newHeight = (int)(originalHeight / ratio);
                }

                if (newHeight >= maxHeight)
                {
                    ratio = newHeight / (float)maxHeight;
                    newHeight = maxHeight;
                    newWidth = (int)(newWidth / ratio);
                    if (newWidth >= maxWidth)
                    {
                        ratio = newWidth / (float)maxWidth;
                        newWidth = maxWidth;
                        newHeight = (int)(newHeight / ratio);
                    }
                }
                this._bitmap = Bitmap.CreateScaledBitmap(this._bitmap, newWidth, newHeight, true);
            }
            return this._bitmap;
        }

        public Bitmap adjustHue(int hue)
        {
            //this._bitmap = this.adjustedHue(this._bitmap, hue);
            return this._bitmap;
        }

        //private Bitmap adjustedHue(Android.Graphics.Bitmap o, int deg)
        //{
        //    Bitmap srca = o;
        //    Bitmap bitmap = srca.Copy(Bitmap.Config.Argb8888, true);
        //    for (int x = 0; x < bitmap.Width; x++)
        //        for (int y = 0; y < bitmap.Height; y++)
        //        {
        //            Color newPixel = Color.ParseColor(hueChange(bitmap.GetPixel(x, y), deg).ToString());
        //            bitmap.SetPixel(x, y, newPixel);
        //        }

        //    return bitmap;
        //}

      

        //private int hueChange(Color startpixel, int deg)
        //{
        //    float[] hsv = new float[3];       //array to store HSV values
        //    Color.ColorToHSV(startpixel, hsv); //get original HSV values of pixel
        //    hsv[0] = hsv[0] + deg;                //add the shift to the HUE of HSV array
        //    hsv[0] = hsv[0] % 360;                //confines hue to values:[0,360]
        //    return Color.HSVToColor(Color.GetAlphaComponent(startpixel), hsv);
        // }
    }
}
