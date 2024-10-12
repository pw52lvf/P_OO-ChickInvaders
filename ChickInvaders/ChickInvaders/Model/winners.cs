using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Winner
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = winner.Width;
            int imgHeight1 = winner.Height;

            // Taille de l'image
            int perduWidth = 420;
            int perduHeight = 298;

            int imgX = winnerX;
            int imgY = winnerY;

            drawingSpace.Graphics.DrawImage(winner, new Rectangle(imgX, imgY, perduWidth, perduHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, beetleHitbox);
        }
    }
}
