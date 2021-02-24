using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    public enum FigureTypes
    {
        Pawn,
        Bishop,
        Rook,
        King,
        Queen,
        Knight
    }
    public abstract class Figures
    {
        private FigureTypes type;
        private bool isWhite;
        private List<Point> moves;

        public Figures(FigureTypes t, bool iw)
        {
            Type = t;
            IsWhite = iw;
            moves = new List<Point>();
        }

        
        public bool IsWhite { get => isWhite; set => isWhite = value; }
        public FigureTypes Type { get => type; set => type = value; }
        public List<Point> Moves { get => moves; set => moves = value; }

        public abstract List<Point> PosibleMoves(Table table, Point currentPoistion);
        public abstract bool CanMove(Table table, Point currentPos, Point endPoint);
        public abstract void Move(Table table, Point currentPos, Point endPoint);
        public bool HasMoves(Table table, Point currentPos)
        {
            List<Point> posibleMoves = new List<Point>();
            posibleMoves = this.PosibleMoves(table, currentPos);
            return this.CheckMoves(table, currentPos, posibleMoves);
        }

        public bool CheckMoves(Table table, Point currentPos, List<Point> posibleMoves)
        {
            bool flag = false;
            Figures tmp, tmp2=null;
            this.Moves.Clear();
            Point position;


            foreach (Point pm in posibleMoves)
            {
                tmp = table.GetFigures(pm.X, pm.Y);

                if (this.Type == FigureTypes.King)
                {
                    position = pm;
                    table.MoveKing(this.IsWhite, pm);
                }
                else
                {
                    position = table.GetKing(this.IsWhite);
                }

                table.MoveFigure(currentPos, pm);

                if(this.Type==FigureTypes.King && Math.Abs(currentPos.Y-pm.Y)>1)
                {
                    if (pm.Y == 2)
                    {
                        tmp2 = table.GetFigures(pm.X, 0);
                        table.MoveFigure(new Point(currentPos.X, 0), new Point(currentPos.X, 3));
                    }

                    else
                    {
                        tmp2 = table.GetFigures(pm.X, 7);
                        table.MoveFigure(new Point(currentPos.X, 7), new Point(currentPos.X, 5));
                    }
                }

                if (!table.CheckCheck(position, !this.isWhite))
                {
                    this.Moves.Add(pm);
                    flag = true;
                }

                table.MoveFigure(pm, currentPos);
                table.SetFigure(tmp, pm);
                if (this.Type == FigureTypes.King && Math.Abs(currentPos.Y - pm.Y) > 1)
                {
                    if (pm.Y == 2)
                    {
                        table.SetFigure(tmp2, new Point(currentPos.X, 0));
                        table.SetFigure(null, new Point(currentPos.X, 3));
                    }
                    else
                    {
                        table.SetFigure(tmp2, new Point(currentPos.X, 7));
                        table.SetFigure(null, new Point(currentPos.X, 5));
                    }
                }
                if (this.Type == FigureTypes.King)
                {
                    table.MoveKing(this.IsWhite, currentPos);
                }

            }
            return flag;
        }
       
    }
}
