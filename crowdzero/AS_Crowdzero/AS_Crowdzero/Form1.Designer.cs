
namespace AS_Crowdzero
{
    partial class Frm_Crowdzero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Crowdzero));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarUtilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verUtilizadoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verUtilizadoresAPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.verUtilizadoresToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criarUtilizadoresToolStripMenuItem});
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            // 
            // criarUtilizadoresToolStripMenuItem
            // 
            this.criarUtilizadoresToolStripMenuItem.Name = "criarUtilizadoresToolStripMenuItem";
            this.criarUtilizadoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.criarUtilizadoresToolStripMenuItem.Text = "Criar Utilizador ";
            this.criarUtilizadoresToolStripMenuItem.Click += new System.EventHandler(this.criarUtilizadoresToolStripMenuItem_Click);
            // 
            // verUtilizadoresToolStripMenuItem1
            // 
            this.verUtilizadoresToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verUtilizadoresAPPToolStripMenuItem});
            this.verUtilizadoresToolStripMenuItem1.Name = "verUtilizadoresToolStripMenuItem1";
            this.verUtilizadoresToolStripMenuItem1.Size = new System.Drawing.Size(99, 20);
            this.verUtilizadoresToolStripMenuItem1.Text = "Ver Utilizadores";
            // 
            // verUtilizadoresAPPToolStripMenuItem
            // 
            this.verUtilizadoresAPPToolStripMenuItem.Name = "verUtilizadoresAPPToolStripMenuItem";
            this.verUtilizadoresAPPToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.verUtilizadoresAPPToolStripMenuItem.Text = "Ver Utilizadores APP";
            this.verUtilizadoresAPPToolStripMenuItem.Click += new System.EventHandler(this.verUtilizadoresAPPToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AS_Crowdzero.Properties.Resources.output_onlinepngtools;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 424);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Crowdzero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Crowdzero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crowdzero";
            this.Load += new System.EventHandler(this.Frm_Crowdzero_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarUtilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verUtilizadoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verUtilizadoresAPPToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

