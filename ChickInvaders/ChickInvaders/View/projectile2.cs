using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Projectile2
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidthProj = projImage2.Width;
            int imgHeightProj = projImage2.Height;

            // Taille de l'image
            int projSize = 40;
            int projHeight = 40;


            // Faire en sorte que ça soit centré
            //int imgX = _x - foeSize / 2;
            //int imgY = _y - foeHeight / 2;

            int imgX = px;
            int imgY = py;

            drawingSpace.Graphics.DrawImage(projImage2, new Rectangle(imgX, imgY, projSize, projHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, projHitbox2);
        }
    }
}