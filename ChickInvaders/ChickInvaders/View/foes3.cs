using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Foes3
    {
        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth3 = foeImage3.Width;
            int imgHeight3 = foeImage3.Height;

            // Taille de l'image
            int foeSize = 100;
            int foeHeight = 100;

            int imgX = fx;
            int imgY = fy;

            drawingSpace.Graphics.DrawImage(foeImage3, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, foeHitbox1);
        }

        // De manière textuelle
        //public override string ToString()
        //{
        //    return $"{Name} ({((int)((double)_charge / FULLCHARGE * 100)).ToString()}%)";
        //}
    }
}
