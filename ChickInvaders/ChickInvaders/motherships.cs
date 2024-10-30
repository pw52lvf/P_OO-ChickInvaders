using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Mothership
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = mothershipImage.Width;
            int imgHeight1 = mothershipImage.Height;

            // Taille de l'image
            int motherWidth= 100;
            int motherHeight = 100;

            int imgX = motherx;
            int imgY = mothery;

            drawingSpace.Graphics.DrawImage(mothershipImage, new Rectangle(imgX, imgY, motherWidth, motherHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, motherHitbox);
        }
    }
}
