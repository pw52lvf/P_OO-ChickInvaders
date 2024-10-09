using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Coeur
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidthProj = coeurImage.Width;
            int imgHeightProj = coeurImage.Height;
            int coeurSize = 30;
            int coeurHeight = 30;


            // Faire en sorte que ça soit centré
            //int imgX = _x - foeSize / 2;
            //int imgY = _y - foeHeight / 2;

            int imgX = cx;
            int imgY = cy;

            drawingSpace.Graphics.DrawImage(coeurImage, new Rectangle(imgX, imgY, coeurSize, coeurHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, coeurHitbox);
        }
    }
}
