using ChickInvaders.Helpers;

namespace ChickInvaders
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Chick
    {
        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            int imgWidth = chickImage.Width;
            int imgHeight = chickImage.Height;

            // Taille de l'image
            int chickSize = 50;
            int chickHeight = 50;



            //if (isFacingLeft)
            //using (Image Flippedfish = Image.FromFile("chick.png"))
            //{
            //    // Flip the image
            //    Flippedfish.RotateFlip(RotateFlipType.RotateNoneFlipX);
            //
            //
            //
            //    drawingSpace.Graphics.TranslateTransform(X, Y); // Déplace l'origine du dessin au centre du poisson
            //    drawingSpace.Graphics.DrawImage(Flippedfish, -Flippedfish.Width / 2, -Flippedfish.Height / 2);
            //    drawingSpace.Graphics.ResetTransform(); // Réinitialise la transformation
            //}

            // Faire en sorte que ça soit centré
            int imgX = _x - chickSize / 2;
            int imgY = _y - chickHeight / 2;

            drawingSpace.Graphics.DrawImage(chickImage, new Rectangle(imgX, imgY, chickSize, chickHeight));
            //drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + imgWidth / 2 + 5, _y - imgHeight / 2);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, chickHitbox);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} ({((int)((double)vie / vieMax * 100)).ToString()}%)";
        }

    }
}
