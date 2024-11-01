using ChickInvaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChickInvaders
{
    public partial class Foes
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            // Largeur et taille de l'image
            int imgWidth1 = foeImage1.Width;
            int imgHeight1 = foeImage1.Height;

            // Taille de l'image
            int foeSize = 100;
            int foeHeight = 100;

            int imgX = fx;
            int imgY = fy;

            drawingSpace.Graphics.DrawImage(foeImage1, new Rectangle(imgX, imgY, foeSize, foeHeight));
        }
    }
}
