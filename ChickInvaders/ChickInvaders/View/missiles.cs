using ChickInvaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChickInvaders
{
    public partial class Missile
    {
        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = missileImage.Width;
            int imgHeight1 = missileImage.Height;

            // Taille de l'image
            int mSize = 100;
            int mHeight = 100;

            int imgX = mx;
            int imgY = my;

            drawingSpace.Graphics.DrawImage(missileImage, new Rectangle(imgX, imgY, mSize, mHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            drawingSpace.Graphics.DrawRectangle(Pens.Red, mHitbox);
        }

        // De manière textuelle
        //public override string ToString()
        //{
        //    return $"{Name} ({((int)((double)_charge / FULLCHARGE * 100)).ToString()}%)";
        //}
    }
}
