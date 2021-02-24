using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    class King : Figures
    {
        private bool moved;
        public King(FigureTypes t, bool iw) : base(t, iw)
        {
            Moved = false;
        }

        public bool Moved { get => moved; set => moved = value; }

        public override bool CanMove(Table table, Point currentPos, Point endPoint)
        {
            if (table.GetFigures(endPoint.X, endPoint.Y) != null && table.GetFigures(endPoint.X, endPoint.Y).IsWhite == this.IsWhite)
                return false;
            else if (Math.Abs(currentPos.X - endPoint.X) < 2 && Math.Abs(currentPos.Y - endPoint.Y) < 2)
            {
                return true;
            }
            else if (!this.Moved && endPoint.Y == 2 && table.GetFigures(endPoint.X, 0) != null && table.GetFigures(endPoint.X, 0).Type==FigureTypes.Rook && !(table.GetFigures(endPoint.X, 0) as Rook).Moved)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (table.GetFigures(currentPos.X, i) != null)
                        return false;
                    if (table.CheckCheck(new Point(currentPos.X, i + 1), !this.IsWhite))
                        return false;
                }
                return true;

            }
            else if (!this.Moved && endPoint.Y == 6 && table.GetFigures(endPoint.X, 7)!=null && table.GetFigures(endPoint.X, 7).Type==FigureTypes.Rook && !(table.GetFigures(endPoint.X, 7) as Rook).Moved)
            {
                for (int i = 4; i < 7; i++)
                {
                    if (table.GetFigures(currentPos.X, i) != null && i>4)
                        return false;
                    if (table.CheckCheck(new Point(currentPos.X, i), !this.IsWhite))
                        return false;
                }
                return true;
            }
            return false;


        }

       

        public override void Move(Table table, Point currentPos, Point endPoint)
        {
            if (Math.Abs(currentPos.Y - endPoint.Y) > 1)
            {
                table.DoCastling(currentPos, endPoint);
                table.MoveKing(this.IsWhite, endPoint);
            }
            else
            {
                table.MoveFigure(currentPos, endPoint);
                table.MoveKing(this.IsWhite, endPoint);
            }
           
}

        public override List<Point> PosibleMoves(Table table, Point currentPoistion)
        {
            List<Point> points = new List<Point>();

            for(int i=currentPoistion.X-1;i<=currentPoistion.X+1;i++)
                for (int j = currentPoistion.Y - 1; j <= currentPoistion.Y + 1; j++)
                {
                    if(i>=0 && j>=0 && i<8 && j<8)
                        if (CanMove(table, currentPoistion, new Point(i, j)))
                            points.Add(new Point(i, j));
                }
            if(currentPoistion.X%7==0)
            {
                if (CanMove(table, currentPoistion, new Point(currentPoistion.X, 2)))
                    points.Add(new Point(currentPoistion.X, 2));
                if (CanMove(table, currentPoistion, new Point(currentPoistion.X, 6)))
                    points.Add(new Point(currentPoistion.X, 6));
            }

            return points;
        }
    }

}
