using Sah.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah
{
    public partial class ChessGame : Form
    {

        private Table table;
        private Button[,] buttons;
        private bool isFirstSquare;
        private Point firstSquare;
        private bool isWhitePlayer;
        private int time;
        

        public ChessGame()
        {
            InitializeComponent();
            table = new Table(this);
            buttons = new Button[8, 8];
            isFirstSquare = true;
            isWhitePlayer = false;
            time = 60;
            lblTimer.Text = time.ToString();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    buttons[i, j] = createButton(i, j, flpTabla.Width / 8);
                    flpTabla.Controls.Add(buttons[i, j]);
                }
            SetAllImages();
            this.ChangePLayer();
            timer1.Enabled = true;
        }

        private Button createButton(int i, int j, int size)
        {
            Button button = new Button();
            button.Name = i +" "+j ;
            if ((i - j) % 2 == 0)
                button.BackColor = Color.Moccasin;
            else
                button.BackColor = Color.Sienna;
            button.Width = size;
            button.Height = size;
            button.Margin = new Padding(0);
            button.Click += new EventHandler(this.buttonClick);
            button.FlatAppearance.BorderColor = Color.Green;
            button.FlatAppearance.BorderSize = 2;

            return button;
        }

        private void SetImage(Button button, Figures figures)
        {
            if(figures!=null)
            switch(figures.Type)
            {
                case FigureTypes.Pawn:
                    {
                        if (figures.IsWhite)
                            button.Image = Properties.Resources.lightPawn;
                        else
                            button.Image = Properties.Resources.darkPawn;
                        break;
                    }
                case FigureTypes.Rook:
                    {
                        if (figures.IsWhite)
                            button.Image = Properties.Resources.lightRook;
                        else
                            button.Image = Properties.Resources.darkRook;
                        break;
                    }
                case FigureTypes.Knight:
                    {
                        if (figures.IsWhite)
                            button.Image = Properties.Resources.lightKnight;
                        else
                            button.Image = Properties.Resources.darkKnight;
                        break;
                    }
                case FigureTypes.Bishop:
                    {
                        if (figures.IsWhite)
                            button.Image = Properties.Resources.lightBishop;
                        else
                            button.Image = Properties.Resources.darkBishop;
                        break;
                    }
                case FigureTypes.King:
                    {
                        if (figures.IsWhite)
                            button.Image = Properties.Resources.lightKing;
                        else
                            button.Image = Properties.Resources.darkKing;
                        break;
                    }
                case FigureTypes.Queen:
                    {
                        if (figures.IsWhite)
                            button.Image = Properties.Resources.lightQueen;
                        else
                            button.Image = Properties.Resources.darkQueen;
                        break;
                    }


            }
        }
        private void SetAllImages()
        {
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    SetImage(buttons[i, j], table.GetFigures(i, j));
                }
        }


        private void buttonClick(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            Point point = new Point((int)Char.GetNumericValue(name[0]), (int)Char.GetNumericValue(name[2]));
            if (isFirstSquare)
            {

                if (table.GetFigures(point.X, point.Y) == null || table.GetFigures(point.X, point.Y).IsWhite != isWhitePlayer)
                {
                    return;
                }
                else
                {
                    firstSquare = point;
                    isFirstSquare = false;
                    buttons[point.X, point.Y].FlatStyle = FlatStyle.Flat;
                    SetPosibleMoves(table.GetFigures(point.X, point.Y).Moves);

                }
            }
            else if(table.GetFigures(point.X, point.Y) != null && table.GetFigures(point.X, point.Y).IsWhite == isWhitePlayer)
            {
                buttons[firstSquare.X, firstSquare.Y].FlatStyle = FlatStyle.Standard;
                RemovePosibleMoves(table.GetFigures(firstSquare.X, firstSquare.Y).Moves);
                SetPosibleMoves(table.GetFigures(point.X, point.Y).Moves);
                firstSquare = point;
                isFirstSquare = false;
                buttons[point.X, point.Y].FlatStyle = FlatStyle.Flat;
            }
            else if(table.GetFigures(point.X, point.Y) == null || table.GetFigures(point.X, point.Y).IsWhite != isWhitePlayer)
            {
                if (table.MakeMove(firstSquare, point))
                {
                    RemovePosibleMoves(table.GetFigures(point.X, point.Y).Moves);
                    if (!this.ChangePLayer())
                    {
                        timer1.Enabled = false;
                        if(isWhitePlayer)
                        {
                            if(table.CheckCheck(table.GetKing(isWhitePlayer),!isWhitePlayer))
                            {
                                MessageBox.Show("Game ended next player have no moves. Winner is BLACK PLAYER");
                            }
                            else
                                MessageBox.Show("Game ended next player have no moves. Draw");
                        }
                        else
                        {
                            if (table.CheckCheck(table.GetKing(isWhitePlayer),!isWhitePlayer))
                            {
                                MessageBox.Show("Game ended next player have no moves. Winner is WHITE PLAYER");
                            }
                            else
                                MessageBox.Show("Game ended next player have no moves. Draw");
                        }
                    }
                }
                else
                {
                    RemovePosibleMoves(table.GetFigures(firstSquare.X, firstSquare.Y).Moves);

                }
                isFirstSquare = true;
                buttons[firstSquare.X, firstSquare.Y].FlatStyle = FlatStyle.Standard;
            }
            
        }

        public Button GetButton(int i, int j)
        {
            return buttons[i, j];
        }

        public void MoveFigure(Point startSquare, Point endSquare)
        {
            buttons[endSquare.X, endSquare.Y].Image = buttons[startSquare.X, startSquare.Y].Image;
            buttons[startSquare.X, startSquare.Y].Image = null;
        }

        public FigureTypes ChooseReplacement()
        {
            ReplacementForm replacementForm = new ReplacementForm();
            if(replacementForm.ShowDialog()==DialogResult.OK)
            {
                return replacementForm.FigureTypes;
            }

            return FigureTypes.Pawn;
        }

        public void SetImage(int x, int y, Figures figures)
        {
            SetImage(buttons[x, y], figures);
        }

        private void SetPosibleMoves(List<Point> points)
        {
            foreach(Point p in points)
            {
                buttons[p.X,p.Y].FlatStyle = FlatStyle.Flat;
            }
        }

        public void RemovePosibleMoves(List<Point> points)
        {
            foreach (Point p in points)
            {
                buttons[p.X, p.Y].FlatStyle = FlatStyle.Standard;
            }
           
        }

        private bool ChangePLayer()
        {
            isWhitePlayer = !isWhitePlayer;
            time = 60;
            lblTimer.BackColor = Color.Gainsboro;
            lblTimer.Text = time.ToString();
            return table.GenerateAllMoves(isWhitePlayer);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if(time==0)
            {
                timer1.Enabled = false;
                if(isWhitePlayer)
                    MessageBox.Show("Time has expired. Winner is Black Player");
                else
                    MessageBox.Show("Time has expired. Winner is White Player");
            }
            if (time <= 10)
                lblTimer.BackColor = Color.OrangeRed;
            else
                lblTimer.BackColor = Color.Gainsboro;

            lblTimer.Text = time.ToString();
        }
    }
}
