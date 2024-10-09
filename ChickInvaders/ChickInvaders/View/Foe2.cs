using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Foes2
    {
        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth2 = foeImage2.Width;
            int imgHeight2 = foeImage2.Height;

            // Taille de l'image
            int foeSize = 100;
            int foeHeight = 100;



            // Faire en sorte que ça soit centré
            //int imgX = _x - foeSize / 2;
            //int imgY = _y - foeHeight / 2;

            int imgX = fx;
            int imgY = fy;

            drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, foeHitbox2);
        }

        // De manière textuelle
    }
}
