using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Eggs
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidthProj = eggImage.Width;
            int imgHeightProj = eggImage.Height;
            int eggSize = 20;
            int eggHeight = 20;


            // Faire en sorte que ça soit centré
            //int imgX = _x - foeSize / 2;
            //int imgY = _y - foeHeight / 2;

            int imgX = ex;
            int imgY = ey;

            drawingSpace.Graphics.DrawImage(eggImage, new Rectangle(imgX, imgY, eggSize, eggHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, eggHitbox);
        }
    }
}
