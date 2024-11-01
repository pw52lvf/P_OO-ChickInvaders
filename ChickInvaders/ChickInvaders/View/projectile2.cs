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
            // Largeur et taille de l'image
            int imgWidthProj = projImage2.Width;
            int imgHeightProj = projImage2.Height;

            // Taille de l'image
            int projSize = 40;
            int projHeight = 40;

            int imgX = px;
            int imgY = py;

            drawingSpace.Graphics.DrawImage(projImage2, new Rectangle(imgX, imgY, projSize, projHeight));
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, projHitbox2);
        }
    }
}