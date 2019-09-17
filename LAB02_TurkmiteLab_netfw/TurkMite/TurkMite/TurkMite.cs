using OpenCvSharp;
using System;

namespace TurkMite
{
    public class Turkmite
    {
        private int x = 100;
        private int y = 100;
        private int direction = 0;  // 0 up, 1 right, 2 down, 3 left
        public readonly Vec3b Black = new Vec3b(0, 0, 0);
        public readonly Vec3b White = new Vec3b(255, 255, 255);

        public Mat Image { get; }
        private Mat.Indexer<Vec3b> indexer;

        public Turkmite()
        {
            Image = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            indexer = Image.GetGenericIndexer<Vec3b>();

        }
        public void Run()
        {
            for (int i = 0; i < 13000; i++)
            {
                Vec3b currentColor = indexer[y, x];

                (int dd, Vec3b nc) = Step(currentColor);
                direction += dd;
                indexer[y, x] = nc;

                direction = (direction + 4) % 4;

                var delta = new (int x, int y)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };
                x += delta[direction].x;
                y += delta[direction].y;

                x = Math.Max(0, Math.Min(x, Image.Cols - 1));
                y = Math.Max(0, Math.Min(y, Image.Rows - 1));
            }
        }
            public (int deltaDirection, Vec3b newColor) Step(Vec3b currentColor)
            {
                if (currentColor == Black)
                {
                    return (1, White);
                }
                else
                {
                    return (-1, Black);
                }
            }
        }
    }

