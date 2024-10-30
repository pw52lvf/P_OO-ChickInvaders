using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Explosion
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = explosion.Width;
            int imgHeight1 = explosion.Height;

            // Taille de l'image
            int exploWidth = 80;
            int exploHeight = 80;

            int imgX = exploX;
            int imgY = exploY;

            drawingSpace.Graphics.DrawImage(explosion, new Rectangle(imgX, imgY, exploWidth, exploHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, beetleHitbox);
        }
    }
}
