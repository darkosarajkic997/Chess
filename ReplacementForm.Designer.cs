namespace Sah
{
    partial class ReplacementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.rbPawn = new System.Windows.Forms.RadioButton();
            this.rbBishop = new System.Windows.Forms.RadioButton();
            this.rbKnight = new System.Windows.Forms.RadioButton();
            this.rbQueen = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sah.Properties.Resources.darkRook;
            this.pictureBox1.Location = new System.Drawing.Point(182, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sah.Properties.Resources.darkKnight;
            this.pictureBox2.Location = new System.Drawing.Point(182, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Sah.Properties.Resources.darkQueen;
            this.pictureBox3.Location = new System.Drawing.Point(182, 287);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(84, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Sah.Properties.Resources.darkBishop;
            this.pictureBox5.Location = new System.Drawing.Point(182, 201);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(84, 80);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // rbPawn
            // 
            this.rbPawn.AutoSize = true;
            this.rbPawn.Location = new System.Drawing.Point(71, 58);
            this.rbPawn.Name = "rbPawn";
            this.rbPawn.Size = new System.Drawing.Size(70, 21);
            this.rbPawn.TabIndex = 10;
            this.rbPawn.TabStop = true;
            this.rbPawn.Text = "ROOK";
            this.rbPawn.UseVisualStyleBackColor = true;
            this.rbPawn.CheckedChanged += new System.EventHandler(this.rbPawn_CheckedChanged);
            // 
            // rbBishop
            // 
            this.rbBishop.AutoSize = true;
            this.rbBishop.Location = new System.Drawing.Point(71, 236);
            this.rbBishop.Name = "rbBishop";
            this.rbBishop.Size = new System.Drawing.Size(80, 21);
            this.rbBishop.TabIndex = 11;
            this.rbBishop.TabStop = true;
            this.rbBishop.Text = "BISHOP";
            this.rbBishop.UseVisualStyleBackColor = true;
            this.rbBishop.CheckedChanged += new System.EventHandler(this.rbPawn_CheckedChanged);
            // 
            // rbKnight
            // 
            this.rbKnight.AutoSize = true;
            this.rbKnight.Location = new System.Drawing.Point(71, 152);
            this.rbKnight.Name = "rbKnight";
            this.rbKnight.Size = new System.Drawing.Size(81, 21);
            this.rbKnight.TabIndex = 12;
            this.rbKnight.TabStop = true;
            this.rbKnight.Text = "KNIGHT";
            this.rbKnight.UseVisualStyleBackColor = true;
            this.rbKnight.CheckedChanged += new System.EventHandler(this.rbPawn_CheckedChanged);
            // 
            // rbQueen
            // 
            this.rbQueen.AutoSize = true;
            this.rbQueen.Location = new System.Drawing.Point(71, 318);
            this.rbQueen.Name = "rbQueen";
            this.rbQueen.Size = new System.Drawing.Size(78, 21);
            this.rbQueen.TabIndex = 13;
            this.rbQueen.TabStop = true;
            this.rbQueen.Text = "QUEEN";
            this.rbQueen.UseVisualStyleBackColor = true;
            this.rbQueen.CheckedChanged += new System.EventHandler(this.rbPawn_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(92, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 64);
            this.button1.TabIndex = 14;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbKnight);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.rbQueen);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.rbBishop);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.rbPawn);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 394);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // ReplacementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ReplacementForm";
            this.Text = "ReplacementForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton rbPawn;
        private System.Windows.Forms.RadioButton rbBishop;
        private System.Windows.Forms.RadioButton rbKnight;
        private System.Windows.Forms.RadioButton rbQueen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}