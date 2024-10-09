using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChickInvaders
{
    public partial class Beetle
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = beetleImage.Width;
            int imgHeight1 = beetleImage.Height;

            // Taille de l'image
            int beetleWidth = 100;
            int beetleHeight = 100;

            int imgX = bx;
            int imgY = by;

            drawingSpace.Graphics.DrawImage(beetleImage, new Rectangle(imgX, imgY, beetleWidth, beetleHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, beetleHitbox);
        }
    }
}
