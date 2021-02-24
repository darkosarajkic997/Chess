using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    class Rook : Figures
    {
        private bool moved;
        public Rook(FigureTypes t, bool iw) : base(t, iw)
        {
            Moved = false;
        }

        public bool Moved { get => moved; set => moved = value; }

        public override bool CanMove(Table table, Point currentPos, Point endPoint)
        {
            if (currentPos.Y != endPoint.Y && currentPos.X != endPoint.X || (table.GetFigures(endPoint.X, endPoint.Y)!=null && table.GetFigures(endPoint.X, endPoint.Y).IsWhite==this.IsWhite))
                return false;


            else if(currentPos.Y==endPoint.Y)
            {
                int min = Math.Min(currentPos.X, endPoint.X);
                int max = Math.Max(currentPos.X, endPoint.X);
                for (int i = min; i <= max; i++)
                    if (table.GetFigures(i, endPoint.Y) != null && i != currentPos.X && i != endPoint.X) 
                        return false;
            }
            else if(currentPos.X == endPoint.X)
            {
                int min = Math.Min(currentPos.Y, endPoint.Y);
                int max = Math.Max(currentPos.Y, endPoint.Y);
                for (int i = min; i <= max; i++)
                    if (table.GetFigures(endPoint.X, i) != null && i != currentPos.Y && i!=endPoint.Y)
                        return false;
            }

            return true;
        }

       

        public override void Move(Table table, Point currentPos, Point endPoint)
        {
            table.MoveFigure(currentPos, endPoint);
        }

        public override List<Point> PosibleMoves(Table table, Point currentPoistion)
        {
            List<Point> points = new List<Point>();
            for(int i=0;i<8;i++)
            {
                if (CanMove(table, currentPoistion, new Point(i, currentPoistion.Y)))
                    points.Add(new Point(i, currentPoistion.Y));
                if (CanMove(table, currentPoistion, new Point(currentPoistion.X,i)))
                    points.Add(new Point(currentPoistion.X, i));
            }
            return points;
        }
    }
}
