namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.Target = new System.Windows.Forms.PictureBox();
            this.Cannon = new System.Windows.Forms.PictureBox();
            this.bulletTime = new System.Windows.Forms.Timer(this.components);
            this.Projectile = new System.Windows.Forms.PictureBox();
            this.targetTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cannon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Projectile)).BeginInit();
            this.SuspendLayout();
            // 
            // Target
            // 
            this.Target.BackColor = System.Drawing.Color.DarkRed;
            this.Target.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Target.Location = new System.Drawing.Point(725, 507);
            this.Target.Name = "Target";
            this.Target.Size = new System.Drawing.Size(39, 37);
            this.Target.TabIndex = 0;
            this.Target.TabStop = false;
            // 
            // Cannon
            // 
            this.Cannon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Cannon.Location = new System.Drawing.Point(42, 29);
            this.Cannon.Name = "Cannon";
            this.Cannon.Size = new System.Drawing.Size(50, 50);
            this.Cannon.TabIndex = 1;
            this.Cannon.TabStop = false;
            // 
            // bulletTime
            // 
            this.bulletTime.Enabled = true;
            this.bulletTime.Interval = 10;
            this.bulletTime.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Projectile
            // 
            this.Projectile.BackColor = System.Drawing.Color.Yellow;
            this.Projectile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Projectile.Location = new System.Drawing.Point(59, 44);
            this.Projectile.Name = "Projectile";
            this.Projectile.Size = new System.Drawing.Size(14, 16);
            this.Projectile.TabIndex = 2;
            this.Projectile.TabStop = false;
            // 
            // targetTime
            // 
            this.targetTime.Enabled = true;
            this.targetTime.Interval = 10;
            this.targetTime.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 853);
            this.Controls.Add(this.Projectile);
            this.Controls.Add(this.Cannon);
            this.Controls.Add(this.Target);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cannon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Projectile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Target;
        private System.Windows.Forms.PictureBox Cannon;
        private System.Windows.Forms.Timer bulletTime;
        private System.Windows.Forms.PictureBox Projectile;
        private System.Windows.Forms.Timer targetTime;
    }
}

