namespace MarkLocation
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgboxDetectedRec = new Emgu.CV.UI.ImageBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imgboxBinary = new Emgu.CV.UI.ImageBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgboxOriginal = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxDetectedRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxBinary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxOriginal)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imgboxDetectedRec);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.imgboxBinary);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.imgboxOriginal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 685);
            this.panel2.TabIndex = 4;
            // 
            // imgboxDetectedRec
            // 
            this.imgboxDetectedRec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgboxDetectedRec.Location = new System.Drawing.Point(3, 363);
            this.imgboxDetectedRec.Name = "imgboxDetectedRec";
            this.imgboxDetectedRec.Size = new System.Drawing.Size(350, 300);
            this.imgboxDetectedRec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgboxDetectedRec.TabIndex = 6;
            this.imgboxDetectedRec.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Detected Rectangles";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgboxBinary
            // 
            this.imgboxBinary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgboxBinary.Location = new System.Drawing.Point(382, 29);
            this.imgboxBinary.Name = "imgboxBinary";
            this.imgboxBinary.Size = new System.Drawing.Size(350, 300);
            this.imgboxBinary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgboxBinary.TabIndex = 4;
            this.imgboxBinary.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(382, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Binary Image";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgboxOriginal
            // 
            this.imgboxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgboxOriginal.Location = new System.Drawing.Point(3, 29);
            this.imgboxOriginal.Name = "imgboxOriginal";
            this.imgboxOriginal.Size = new System.Drawing.Size(350, 300);
            this.imgboxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgboxOriginal.TabIndex = 2;
            this.imgboxOriginal.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Original Image";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtOutput.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtOutput.Location = new System.Drawing.Point(738, 45);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(526, 685);
            this.txtOutput.TabIndex = 5;
            this.txtOutput.Text = "";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(90, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(238, 21);
            this.txtFileName.TabIndex = 2;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(343, 10);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(48, 23);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image File:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOpenFile);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 45);
            this.panel1.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 730);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "FC_MarkDetector";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgboxDetectedRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxBinary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxOriginal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private Emgu.CV.UI.ImageBox imgboxDetectedRec;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox imgboxBinary;
        private System.Windows.Forms.Label label3;
        private Emgu.CV.UI.ImageBox imgboxOriginal;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

