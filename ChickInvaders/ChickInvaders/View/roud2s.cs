using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Round2
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = round2.Width;
            int imgHeight1 = round2.Height;

            // Taille de l'image
            int round2Width = 420;
            int round2Height = 298;

            int imgX = round2X;
            int imgY = round2Y;

            drawingSpace.Graphics.DrawImage(round2, new Rectangle(imgX, imgY, round2Width, round2Height));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, beetleHitbox);
        }
    }
}
