namespace Project_Data_Logger
{
    partial class LoggerUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.txtAccess = new System.Windows.Forms.TextBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.tmrControl = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardCode
            // 
            this.txtCardCode.Location = new System.Drawing.Point(12, 43);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(125, 27);
            this.txtCardCode.TabIndex = 0;
            this.txtCardCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardCode_KeyPress);
            // 
            // txtAccess
            // 
            this.txtAccess.Location = new System.Drawing.Point(295, 43);
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.Size = new System.Drawing.Size(31, 27);
            this.txtAccess.TabIndex = 1;
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(12, 20);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(40, 20);
            this.lblCard.TabIndex = 3;
            this.lblCard.Text = "Card";
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(233, 46);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(56, 20);
            this.lblAccess.TabIndex = 5;
            this.lblAccess.Text = "Access:";
            // 
            // tmrControl
            // 
            this.tmrControl.Interval = 3000;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(694, 409);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblAccess);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.txtAccess);
            this.Controls.Add(this.txtCardCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtCardCode;
        private TextBox txtAccess;
        private Label lblCard;
        private Label lblAccess;
        private System.Windows.Forms.Timer tmrControl;
        private Button btnExit;
    }
}