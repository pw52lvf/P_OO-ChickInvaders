using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders.View
{
    public partial class Hitbox
    {
        public int X { get; set; }  // X position of the hitbox (top-left corner)
        public int Y { get; set; }  // Y position of the hitbox (top-left corner)
        public int Width { get; set; }
        public int Height { get; set; }

        public Hitbox(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        // Check if this hitbox intersects with another hitbox
        public bool Intersects(Hitbox other)
        {
            return X < other.X + other.Width &&
                   X + Width > other.X &&
                   Y < other.Y + other.Height &&
                   Y + Height > other.Y;
        }

        // Optional: for debugging purposes, print the hitbox coordinates
        public override string ToString()
        {
            return $"Hitbox(X: {X}, Y: {Y}, Width: {Width}, Height: {Height})";
        }
    }
}
