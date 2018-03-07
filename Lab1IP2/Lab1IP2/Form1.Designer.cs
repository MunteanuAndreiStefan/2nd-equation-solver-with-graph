namespace Lab1IP2
{
    partial class Form1
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
            this.pictureGraph = new System.Windows.Forms.PictureBox();
            this.textBoxValueA = new System.Windows.Forms.TextBox();
            this.textBoxValueB = new System.Windows.Forms.TextBox();
            this.textBoxValueC = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.labelValueA = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelValueB = new System.Windows.Forms.Label();
            this.labelValueC = new System.Windows.Forms.Label();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.saveTextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureGraph
            // 
            this.pictureGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureGraph.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureGraph.Location = new System.Drawing.Point(9, 12);
            this.pictureGraph.Name = "pictureGraph";
            this.pictureGraph.Size = new System.Drawing.Size(180, 180);
            this.pictureGraph.TabIndex = 1;
            this.pictureGraph.TabStop = false;
            // 
            // textBoxValueA
            // 
            this.textBoxValueA.Location = new System.Drawing.Point(237, 51);
            this.textBoxValueA.Name = "textBoxValueA";
            this.textBoxValueA.Size = new System.Drawing.Size(97, 20);
            this.textBoxValueA.TabIndex = 2;
            this.textBoxValueA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxValidateInput);
            // 
            // textBoxValueB
            // 
            this.textBoxValueB.Location = new System.Drawing.Point(237, 77);
            this.textBoxValueB.Name = "textBoxValueB";
            this.textBoxValueB.Size = new System.Drawing.Size(97, 20);
            this.textBoxValueB.TabIndex = 3;
            this.textBoxValueB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxValidateInput);
            // 
            // textBoxValueC
            // 
            this.textBoxValueC.Location = new System.Drawing.Point(237, 103);
            this.textBoxValueC.Name = "textBoxValueC";
            this.textBoxValueC.Size = new System.Drawing.Size(97, 20);
            this.textBoxValueC.TabIndex = 4;
            this.textBoxValueC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxValidateInput);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(194, 168);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(140, 24);
            this.calculateButton.TabIndex = 5;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButtonClicked);
            // 
            // labelValueA
            // 
            this.labelValueA.AutoSize = true;
            this.labelValueA.Location = new System.Drawing.Point(196, 54);
            this.labelValueA.Name = "labelValueA";
            this.labelValueA.Size = new System.Drawing.Size(33, 13);
            this.labelValueA.TabIndex = 6;
            this.labelValueA.Text = "val a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "a*x^2+b*x+c";
            // 
            // labelValueB
            // 
            this.labelValueB.AutoSize = true;
            this.labelValueB.Location = new System.Drawing.Point(196, 80);
            this.labelValueB.Name = "labelValueB";
            this.labelValueB.Size = new System.Drawing.Size(36, 13);
            this.labelValueB.TabIndex = 8;
            this.labelValueB.Text = "val b: ";
            // 
            // labelValueC
            // 
            this.labelValueC.AutoSize = true;
            this.labelValueC.Location = new System.Drawing.Point(196, 106);
            this.labelValueC.Name = "labelValueC";
            this.labelValueC.Size = new System.Drawing.Size(36, 13);
            this.labelValueC.TabIndex = 9;
            this.labelValueC.Text = "val c: ";
            // 
            // saveImageButton
            // 
            this.saveImageButton.Location = new System.Drawing.Point(194, 138);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(63, 24);
            this.saveImageButton.TabIndex = 10;
            this.saveImageButton.Text = "Save Img";
            this.saveImageButton.UseVisualStyleBackColor = true;
            this.saveImageButton.Visible = false;
            this.saveImageButton.Click += new System.EventHandler(this.ImageSaveGraph);
            // 
            // saveTextButton
            // 
            this.saveTextButton.Location = new System.Drawing.Point(271, 138);
            this.saveTextButton.Name = "saveTextButton";
            this.saveTextButton.Size = new System.Drawing.Size(63, 24);
            this.saveTextButton.TabIndex = 11;
            this.saveTextButton.Text = "Save txt";
            this.saveTextButton.UseVisualStyleBackColor = true;
            this.saveTextButton.Visible = false;
            this.saveTextButton.Click += new System.EventHandler(this.TextSaveGraph);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 203);
            this.Controls.Add(this.saveTextButton);
            this.Controls.Add(this.saveImageButton);
            this.Controls.Add(this.labelValueC);
            this.Controls.Add(this.labelValueB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelValueA);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.textBoxValueC);
            this.Controls.Add(this.textBoxValueB);
            this.Controls.Add(this.textBoxValueA);
            this.Controls.Add(this.pictureGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Lab1 prob 2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureGraph;
        private System.Windows.Forms.TextBox textBoxValueA;
        private System.Windows.Forms.TextBox textBoxValueB;
        private System.Windows.Forms.TextBox textBoxValueC;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label labelValueA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelValueB;
        private System.Windows.Forms.Label labelValueC;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.Button saveTextButton;
    }
}

