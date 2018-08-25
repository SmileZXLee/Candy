namespace LittleCat
{
    partial class LittleCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LittleCat));
            this.imgShowPB = new System.Windows.Forms.PictureBox();
            this.animateTimer = new System.Windows.Forms.Timer(this.components);
            this.operateTimer = new System.Windows.Forms.Timer(this.components);
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.candyNI = new System.Windows.Forms.NotifyIcon(this.components);
            this.myMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.偏好设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgShowPB)).BeginInit();
            this.myMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgShowPB
            // 
            this.imgShowPB.Location = new System.Drawing.Point(108, 74);
            this.imgShowPB.Name = "imgShowPB";
            this.imgShowPB.Size = new System.Drawing.Size(112, 98);
            this.imgShowPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgShowPB.TabIndex = 0;
            this.imgShowPB.TabStop = false;
            this.imgShowPB.Click += new System.EventHandler(this.imgShowPB_Click);
            this.imgShowPB.DragDrop += new System.Windows.Forms.DragEventHandler(this.imgShowPB_DragDrop);
            this.imgShowPB.MouseEnter += new System.EventHandler(this.imgShowPB_MouseEnter);
            // 
            // animateTimer
            // 
            this.animateTimer.Tick += new System.EventHandler(this.animateTimer_Tick);
            // 
            // operateTimer
            // 
            this.operateTimer.Interval = 1;
            this.operateTimer.Tick += new System.EventHandler(this.operateTimer_Tick);
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 1000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // candyNI
            // 
            this.candyNI.Icon = ((System.Drawing.Icon)(resources.GetObject("candyNI.Icon")));
            this.candyNI.Text = "Candy";
            this.candyNI.Visible = true;
            this.candyNI.Click += new System.EventHandler(this.candyNI_Click);
            this.candyNI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.candyNI_MouseDown);
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.偏好设置ToolStripMenuItem,
            this.关于我ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(166, 112);
            // 
            // 偏好设置ToolStripMenuItem
            // 
            this.偏好设置ToolStripMenuItem.Name = "偏好设置ToolStripMenuItem";
            this.偏好设置ToolStripMenuItem.Size = new System.Drawing.Size(165, 36);
            this.偏好设置ToolStripMenuItem.Text = "设置";
            this.偏好设置ToolStripMenuItem.Click += new System.EventHandler(this.偏好设置ToolStripMenuItem_Click);
            // 
            // 关于我ToolStripMenuItem
            // 
            this.关于我ToolStripMenuItem.Name = "关于我ToolStripMenuItem";
            this.关于我ToolStripMenuItem.Size = new System.Drawing.Size(165, 36);
            this.关于我ToolStripMenuItem.Text = "关于我";
            this.关于我ToolStripMenuItem.Click += new System.EventHandler(this.关于我ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(165, 36);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // LittleCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 231);
            this.Controls.Add(this.imgShowPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LittleCat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LittleCat_FormClosing);
            this.Load += new System.EventHandler(this.LittleCat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgShowPB)).EndInit();
            this.myMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgShowPB;
        private System.Windows.Forms.Timer animateTimer;
        private System.Windows.Forms.Timer operateTimer;
        private System.Windows.Forms.Timer delayTimer;
        private System.Windows.Forms.NotifyIcon candyNI;
        private System.Windows.Forms.ContextMenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem 偏好设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

