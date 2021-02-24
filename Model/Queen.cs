using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    class Queen : Figures
    {

        public Queen(FigureTypes t, bool iw) : base(t, iw)
        {

        }

        public override bool CanMove(Table table, Point currentPos, Point endPoint)
        {
            if((table.GetFigures(endPoint.X, endPoint.Y) != null && table.GetFigures(endPoint.X, endPoint.Y).IsWhite == this.IsWhite))
            {
                return false;
            }
            else if (Math.Abs(currentPos.X - endPoint.X) == Math.Abs(currentPos.Y - endPoint.Y))
            {
                int pomX = -1, pomY = -1;
                int startX = currentPos.X, startY = currentPos.Y;
                if (currentPos.X < endPoint.X)
                    pomX = 1;
                if (currentPos.Y < endPoint.Y)
                    pomY = 1;

                while (startX != endPoint.X)
                {
                    if (table.GetFigures(startX, startY) != null && startX != currentPos.X)
                        return false;
                    startX += pomX;
                    startY += pomY;
                }
                return true;
            }
            else if (currentPos.Y == endPoint.Y || currentPos.X == endPoint.X)
            {
                if (currentPos.Y == endPoint.Y)
                {
                    int min = Math.Min(currentPos.X, endPoint.X);
                    int max = Math.Max(currentPos.X, endPoint.X);
                    for (int i = min; i <= max; i++)
                        if (table.GetFigures(i, endPoint.Y) != null && i != currentPos.X && i != endPoint.X)
                            return false;
                    return true;
                }
                else if (currentPos.X == endPoint.X)
                {
                    int min = Math.Min(currentPos.Y, endPoint.Y);
                    int max = Math.Max(currentPos.Y, endPoint.Y);
                    for (int i = min; i <= max; i++)
                        if (table.GetFigures(endPoint.X, i) != null && i != currentPos.Y && i != endPoint.Y)
                            return false;
                    return true;
                }
                
            }
            return false;
        }

       

        public override void Move(Table table, Point currentPos, Point endPoint)
        {
            table.MoveFigure(currentPos, endPoint);
        }

        public override List<Point> PosibleMoves(Table table, Point currentPoistion)
        {
            List<Point> points = new List<Point>();
            int i, j;
            i = Math.Max(0, (currentPoistion.X - currentPoistion.Y));
            j = Math.Max(0, (currentPoistion.Y - currentPoistion.X));

            while (i < 8 && j < 8)
            {
                if (CanMove(table, currentPoistion, new Point(i, j)))
                    points.Add(new Point(i, j));
                i++;
                j++;
            }

            i = Math.Min(7, (currentPoistion.X + currentPoistion.Y));
            j = Math.Min(7, (currentPoistion.Y + currentPoistion.X) - i);

            while (i >= 0 && j < 8)
            {
                if (CanMove(table, currentPoistion, new Point(i, j)))
                    points.Add(new Point(i, j));
                i--;
                j++;
            }
            for (i = 0; i < 8; i++)
            {
                if (CanMove(table, currentPoistion, new Point(i, currentPoistion.Y)))
                    points.Add(new Point(i, currentPoistion.Y));
                if (CanMove(table, currentPoistion, new Point(currentPoistion.X, i)))
                    points.Add(new Point(currentPoistion.X, i));
            }
            
            
            return points;


        }
    }
}
