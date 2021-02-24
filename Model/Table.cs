using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah.Model
{
    public class Table
    {
        Figures[,] figures;
        ChessGame form;
        Figures LPawnEnPassant, DPawnEnPassant;
        Point LKing, DKing;

        public Table(ChessGame f)
        {
            form = f;
            figures = new Figures[8, 8];
            
            
            InitializeTable();
        }


        private void InitializeTable()
        {
            for(int i=0;i<8;i++)
            {
                figures[1, i] = new Pawn(FigureTypes.Pawn, false);
                figures[6, i] = new Pawn(FigureTypes.Pawn, true);

                switch(i)
                {
                    case 0:
                    case 7:
                        {
                            figures[0, i] = new Rook(FigureTypes.Rook, false);
                            
                            figures[7, i] = new Rook(FigureTypes.Rook, true);
                           
                            break;
                        }
                    case 1:
                    case 6:
                        {
                            figures[0, i] = new Knight(FigureTypes.Knight, false);
                            figures[7, i] = new Knight(FigureTypes.Knight, true);
                            break;
                        }
                    case 2:
                    case 5:
                        {
                            figures[0, i] = new Bishop (FigureTypes.Bishop, false);
                            figures[7, i] = new Bishop (FigureTypes.Bishop, true);
                            break;
                        }
                    case 3:
                        {
                            figures[0, i] = new Queen(FigureTypes.Queen, false);
                            figures[7, i] = new Queen(FigureTypes.Queen, true);
                            break;
                        }
                    case 4:
                        {
                            figures[0, i] = new King(FigureTypes.King, false);
                            DKing = new Point(0,4);
                            figures[7, i] = new King(FigureTypes.King, true);
                            LKing = new Point(7, 4);
                           
                            break;
                        }


                }
            }
        }

        public Figures GetFigures(int i, int j)
        {
            if(i<8 && i>=0 && j>=0 && j<8)
             return figures[i, j];
            return null;
        }


        public bool MakeMove(Point startSquare, Point endSquare)
        {
            Figures figure = figures[startSquare.X, startSquare.Y];
            if(figure.Moves.Contains(endSquare))
            {
                figure.Move(this, startSquare, endSquare);
                if (figure.Type == FigureTypes.Rook)
                    (figure as Rook).Moved = true;
                if (figure.Type == FigureTypes.King)
                    (figure as King).Moved = true;

                if (figure.Type == FigureTypes.Pawn && Math.Abs(startSquare.X - endSquare.X) == 2)
                    AddEnPassant(figure);
                else
                    RemoveEnPassant(figure);

                if(figure.Type == FigureTypes.Pawn && endSquare.X%7==0)
                {
                    form.RemovePosibleMoves(figure.Moves);
                    Figures f = CreateFigure(form.ChooseReplacement(), figure.IsWhite);
                    figures[endSquare.X, endSquare.Y] = f;
                    form.SetImage(endSquare.X, endSquare.Y, f);
                }
                return true;          
            }
            return false;
        }


        public void AddEnPassant(Figures figures)
        {
            if (figures.IsWhite)
                LPawnEnPassant = figures;
            else
                DPawnEnPassant = figures;
        }

        public void RemoveEnPassant(Figures figures)
        {
            if (figures.IsWhite)
                LPawnEnPassant = null;
            else
                DPawnEnPassant = null;
        }

        public void MoveFigure(Point startP, Point endP)
        {
            Figures fig= GetFigures(startP.X, startP.Y);
            figures[startP.X, startP.Y] = null;
            figures[endP.X, endP.Y] = fig;
            form.MoveFigure(startP, endP);
        }

        public void SetFigure(Figures figure, Point position)
        {
            figures[position.X, position.Y] = figure;
            form.SetImage(position.X, position.Y, figure);
        }

        private Figures CreateFigure(FigureTypes figureTypes, bool isWhite)
        {
            switch(figureTypes)
            {
                case FigureTypes.Queen:
                    {
                        return new Queen(figureTypes, isWhite);
                      
                    }
                case FigureTypes.Rook:
                    {
                        return new Rook(figureTypes, isWhite);

                    }
                case FigureTypes.Bishop:
                    {
                        return new Bishop(figureTypes, isWhite);
                    }
                case FigureTypes.Knight:
                    {
                        return new Knight(figureTypes, isWhite);
                    }
                default:
                    {
                        return new Pawn(figureTypes, isWhite);
                    }
            }
        }

        public void DoCastling(Point startSquare, Point endSquare)
        {
            Figures figure=GetFigures(startSquare.X,startSquare.Y);
            if (endSquare.Y == 2)
            {
                MoveFigure(startSquare, endSquare);
                (figure as King).Moved = true;

                (GetFigures(endSquare.X, 0) as Rook).Moved = true;
                MoveFigure(new Point(endSquare.X, 0), new Point(endSquare.X, 3));
                
                RemoveEnPassant(figure);
            }
            if (endSquare.Y == 6)
            {
                MoveFigure(startSquare, endSquare);
                (figure as King).Moved = true;

                (GetFigures(endSquare.X, 7) as Rook).Moved = true;
                MoveFigure(new Point(endSquare.X, 7), new Point(endSquare.X, 5));

                RemoveEnPassant(figure);
               
            }
        }

        public void DoEnPassant(Point startSquare, Point endSquare)
        {
            Figures figure = GetFigures(startSquare.X, startSquare. Y);
            if (figure.IsWhite)
            {
                MoveFigure(new Point(endSquare.X + 1, endSquare.Y), new Point(endSquare.X, endSquare.Y));
                MoveFigure(startSquare, endSquare);
                RemoveEnPassant(figure);
            }
            else
            {
                MoveFigure(new Point(endSquare.X - 1, endSquare.Y), new Point(endSquare.X, endSquare.Y));
                MoveFigure(startSquare, endSquare);
                RemoveEnPassant(figure);
            }
        }

        public Figures GetEnPassantFigure(bool isWhite)
        {
            if (isWhite)
                return DPawnEnPassant;
            return LPawnEnPassant;
        }

        public bool GenerateAllMoves(bool isWhite)
        {
            bool flag= false;
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    if(this.figures[i,j]!=null && this.figures[i, j].IsWhite==isWhite)
                    {
                        flag |= this.figures[i, j].HasMoves(this,new Point(i,j));
                    }
                }

            return flag;
        }

        public bool CheckCheck(Point position, bool isWhite)
        {
            for(int i=0; i<8;i++)
                for(int j=0;j<8;j++)
                {
                    if (figures[i, j] != null && figures[i, j].IsWhite==isWhite && figures[i, j].CanMove(this,new Point(i,j),position))
                    {
                        return true;
                    }
                }
            return false;
        }

        public void MoveKing(bool isWhite, Point position)
        {
            if (isWhite)
                LKing = position;
            else
                DKing = position;
        }

        public Point GetKing(bool isWhite)
        {
            if (isWhite)
                return LKing;
            else
                return DKing;
        }
    }
}
