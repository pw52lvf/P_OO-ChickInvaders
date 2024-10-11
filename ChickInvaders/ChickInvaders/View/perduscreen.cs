using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Perdu
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth1 = gameOver.Width;
            int imgHeight1 = gameOver.Height;

            // Taille de l'image
            int perduWidth = 420;
            int perduHeight = 298;

            int imgX = perduX;
            int imgY = perduY;

            drawingSpace.Graphics.DrawImage(gameOver, new Rectangle(imgX, imgY, perduWidth, perduHeight));
            //drawingSpace.Graphics.DrawImage(foeImage2, new Rectangle(imgX, imgY, foeSize, foeHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, beetleHitbox);
        }
    }
}
