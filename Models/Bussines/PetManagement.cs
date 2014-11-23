using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace MeHazVisto.Models.Bussines
{
    public class PetManagement
    {
        public static void CreateThumbnail(
            string fileName, string filePath,
            int thumbWi, int thumbHi,
            bool maintainAspect)
        {
            var originalFile = Path.Combine(filePath, fileName);
            var source = Image.FromFile(originalFile);
            if (source.Width <= thumbWi && source.Height <= thumbHi)
                return;
            Bitmap thumbnail;
            try
            {
                int wi = thumbWi;
                int hi = thumbHi;
                if (maintainAspect)
                {
                    wi = thumbWi;
                    hi = (int)(source.Height * ((decimal)thumbWi / source.Width));
                }
                else
                {
                    hi = thumbHi;
                    wi = (int)(source.Width * ((decimal)thumbHi / source.Height));
                }
                thumbnail = new Bitmap(wi, hi);
                using (Graphics g = Graphics.FromImage(thumbnail))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(Brushes.Transparent, 0, 0, wi, hi);
                    g.DrawImage(source, 0, 0, wi, hi);
                }
                var thumbnailName = Path.Combine(filePath, "thumbnail_" + fileName);
                thumbnail.Save(thumbnailName);
            }
            catch { 
            }
        }

    }
}