using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    class Pawn : Figures
    {
        
        public Pawn(FigureTypes t, bool iw):base(t,iw)
        {
           
        }

        public override bool CanMove(Table table, Point startSquare, Point endSquare)
        {
            if((table.GetFigures(endSquare.X, endSquare.Y) != null && table.GetFigures(endSquare.X, endSquare.Y).IsWhite == this.IsWhite))
            {
                return false;
            }
            //Streight move
            else if ((startSquare.X - endSquare.X) == 2 && (startSquare.Y == endSquare.Y) && IsWhite && table.GetFigures(startSquare.X - 1, startSquare.Y) == null && table.GetFigures(startSquare.X - 2, startSquare.Y) == null && startSquare.X == 6)
            {
                return true;
            }
            else if ((startSquare.X - endSquare.X) == 1 && (startSquare.Y == endSquare.Y) && IsWhite && table.GetFigures(startSquare.X - 1, startSquare.Y) == null)
            {
                return true;
            }
            else if ((startSquare.X - endSquare.X) == -2 && (startSquare.Y == endSquare.Y) && !IsWhite && table.GetFigures(startSquare.X + 1, startSquare.Y) == null && table.GetFigures(startSquare.X + 2, startSquare.Y) == null && startSquare.X == 1)
            {
                return true;
            }
            else if ((startSquare.X - endSquare.X) == -1 && (startSquare.Y == endSquare.Y) && !IsWhite && table.GetFigures(startSquare.X + 1, startSquare.Y) == null)
            {
                return true;
            }
            //Attack
            else if ((startSquare.X - endSquare.X) == 1 && Math.Abs(startSquare.Y - endSquare.Y) == 1 && IsWhite && table.GetFigures(endSquare.X, endSquare.Y) != null && !table.GetFigures(endSquare.X, endSquare.Y).IsWhite)
            {
                return true;
            }
            else if ((startSquare.X - endSquare.X) == -1 && Math.Abs(startSquare.Y - endSquare.Y) == 1 && !IsWhite && table.GetFigures(endSquare.X, endSquare.Y) != null && table.GetFigures(endSquare.X, endSquare.Y).IsWhite)
            {
                return true;
            }
            else if (table.GetEnPassantFigure(this.IsWhite)!=null && (table.GetEnPassantFigure(this.IsWhite) == table.GetFigures(endSquare.X + 1, endSquare.Y) && startSquare.X == 3) || (table.GetEnPassantFigure(this.IsWhite) != null && table.GetEnPassantFigure(this.IsWhite) == table.GetFigures(endSquare.X - 1, endSquare.Y) && startSquare.X == 4))
            {
                return true;
            }
            return false;
            
        }

      

        public override void Move(Table table, Point currentPos, Point endPoint)
        {
           if(table.GetFigures(endPoint.X,endPoint.Y)==null && endPoint.Y!=currentPos.Y)
                    table.DoEnPassant(currentPos, endPoint);
           else
                    table.MoveFigure(currentPos, endPoint);
        }

        public override List<Point> PosibleMoves(Table table, Point currentPoistion)
        {
            List<Point> points = new List<Point>();
            int pom=1;
            if(this.IsWhite)
            {
                pom = -1;
            }
            if ((currentPoistion.X+pom>=0) && (currentPoistion.X + pom < 8) && CanMove(table, currentPoistion, new Point(currentPoistion.X + pom, currentPoistion.Y)))
                points.Add(new Point(currentPoistion.X + pom, currentPoistion.Y));
            if ((currentPoistion.X+2*pom>=0) && (currentPoistion.X + pom < 8) && CanMove(table, currentPoistion, new Point(currentPoistion.X + 2*pom, currentPoistion.Y)))
                points.Add(new Point(currentPoistion.X + 2*pom, currentPoistion.Y));
            if ((currentPoistion.X + pom >= 0) && (currentPoistion.X + pom < 8) && (currentPoistion.Y + pom >= 0) && (currentPoistion.Y + pom < 8) && CanMove(table, currentPoistion, new Point(currentPoistion.X + pom, currentPoistion.Y+pom)))
                points.Add(new Point(currentPoistion.X + pom, currentPoistion.Y+pom));
            if ((currentPoistion.X + pom >= 0) && (currentPoistion.X + pom < 8) && (currentPoistion.Y - pom >= 0) && (currentPoistion.Y - pom < 8) && CanMove(table, currentPoistion, new Point(currentPoistion.X + pom, currentPoistion.Y - pom)))
                points.Add(new Point(currentPoistion.X + pom, currentPoistion.Y-pom));
            return points;

        }
    }
}
