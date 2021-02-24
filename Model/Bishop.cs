using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    class Bishop : Figures
    {

        public Bishop(FigureTypes t, bool iw) : base(t, iw)
        {

        }
        public override bool CanMove(Table table, Point currentPos, Point endPoint)
        {
            if (Math.Abs(currentPos.X - endPoint.X) != Math.Abs(currentPos.Y - endPoint.Y) || (table.GetFigures(endPoint.X, endPoint.Y)!=null && table.GetFigures(endPoint.X,endPoint.Y).IsWhite==this.IsWhite))
                return false;
            else
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

            while (i<8 && j<8)
            {
                if (CanMove(table, currentPoistion, new Point(i, j)))
                    points.Add(new Point(i, j));
                i++;
                j++;
            }

            i = Math.Min(7, (currentPoistion.X + currentPoistion.Y));
            j = Math.Min(7, (currentPoistion.Y + currentPoistion.X)-i);

            while (i >= 0 && j < 8)
            {
                if (CanMove(table, currentPoistion, new Point(i, j)))
                    points.Add(new Point(i, j));
                i--;
                j++;
            }



            return points;
        }
    }
}
