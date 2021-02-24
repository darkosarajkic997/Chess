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
    public partial class ReplacementForm : Form
    {
        public FigureTypes FigureTypes=FigureTypes.Queen;
        public ReplacementForm()
        {
            InitializeComponent();
            rbQueen.Checked = true;
        }

       

        private void rbPawn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                switch (((RadioButton)sender).Text)
                {
                    case "ROOK":
                            FigureTypes = FigureTypes.Rook;
                            break;
                    case "BISHOP":
                            FigureTypes = FigureTypes.Bishop;
                            break;
                    case "KNIGHT":
                            FigureTypes = FigureTypes.Knight;
                            break;
                    default :
                            FigureTypes = FigureTypes.Queen;
                            break;
                }
            }
        }
    }
}
