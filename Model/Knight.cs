using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    class Knight : Figures
    {
        public Knight(FigureTypes t, bool iw) : base(t, iw)
        {
            
        }


        public override bool CanMove(Table table, Point currentPos, Point endPoint)
        {
            if(table.GetFigures(endPoint.X, endPoint.Y)!=null && table.GetFigures(endPoint.X, endPoint.Y).IsWhite==IsWhite)
            {
                return false;
            }
            else if ((Math.Abs(currentPos.X - endPoint.X) == 2 && Math.Abs(currentPos.Y - endPoint.Y) == 1) || (Math.Abs(currentPos.X - endPoint.X) == 1 && Math.Abs(currentPos.Y - endPoint.Y) == 2))
            {
                return true;
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
            for(int i=currentPoistion.X-2;i<=currentPoistion.X+2;i++)
                for(int j = currentPoistion.Y - 2; j <= currentPoistion.Y + 2; j++)
                {
                    if((i>=0 && i<8 && j >= 0 && j < 8) &&((Math.Abs(i-currentPoistion.X)==2 && Math.Abs(j - currentPoistion.Y) == 1)|| (Math.Abs(i - currentPoistion.X) == 1 && Math.Abs(j - currentPoistion.Y) == 2)))
                    {
                        if (CanMove(table, currentPoistion, new Point(i, j)))
                            points.Add(new Point(i, j));
                    }
                }
            return points;
        }
    }
}
