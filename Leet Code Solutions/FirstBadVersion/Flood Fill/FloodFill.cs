using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Flood_Fill
{
    class FloodFill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            Fill(image, sr, sc, image[sr][sc], newColor);
            return image;
        }

        private void Fill(int[][] image, int row, int col, int color, int newColor)
        {
            if (row < 0 || row >= image.Length || col < 0 || col >= image[row].Length || color == newColor || image[row][col] != color)
                return;

            var currentColor = image[row][col];
            image[row][col] = newColor;

            Fill(image, row - 1, col, currentColor, newColor);
            Fill(image, row, col + 1, currentColor, newColor);
            Fill(image, row + 1, col, currentColor, newColor);
            Fill(image, row, col - 1, currentColor, newColor);
        }
    }
}
