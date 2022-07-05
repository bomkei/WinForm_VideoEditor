namespace WinForm_VideoEditor {
  partial class MainForm {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.menuBar = new System.Windows.Forms.MenuStrip();
      this.あいうえおToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openProjectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.pictureBox_preview = new System.Windows.Forms.PictureBox();
      this.pictureBox_seekBar = new System.Windows.Forms.PictureBox();
      this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuStrip_timeline = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.menuBar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox_seekBar)).BeginInit();
      this.SuspendLayout();
      // 
      // menuBar
      // 
      this.menuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.あいうえおToolStripMenuItem,
            this.aToolStripMenuItem,
            this.debugToolStripMenuItem});
      this.menuBar.Location = new System.Drawing.Point(0, 0);
      this.menuBar.Name = "menuBar";
      this.menuBar.Size = new System.Drawing.Size(949, 24);
      this.menuBar.TabIndex = 0;
      this.menuBar.Text = "menuStrip1";
      // 
      // あいうえおToolStripMenuItem
      // 
      this.あいうえおToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.openProjectFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
      this.あいうえおToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.あいうえおToolStripMenuItem.Name = "あいうえおToolStripMenuItem";
      this.あいうえおToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.あいうえおToolStripMenuItem.Text = "&File";
      // 
      // aToolStripMenuItem
      // 
      this.aToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.aToolStripMenuItem.Name = "aToolStripMenuItem";
      this.aToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.aToolStripMenuItem.Text = "Editor";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.openToolStripMenuItem.Text = "Open";
      // 
      // openProjectFileToolStripMenuItem
      // 
      this.openProjectFileToolStripMenuItem.Name = "openProjectFileToolStripMenuItem";
      this.openProjectFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.openProjectFileToolStripMenuItem.Text = "Open Project File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.saveToolStripMenuItem.Text = "Save";
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.saveAsToolStripMenuItem.Text = "Save as ...";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
      // 
      // pictureBox_preview
      // 
      this.pictureBox_preview.BackColor = System.Drawing.Color.Black;
      this.pictureBox_preview.Location = new System.Drawing.Point(0, 24);
      this.pictureBox_preview.Name = "pictureBox_preview";
      this.pictureBox_preview.Size = new System.Drawing.Size(640, 360);
      this.pictureBox_preview.TabIndex = 1;
      this.pictureBox_preview.TabStop = false;
      // 
      // pictureBox_seekBar
      // 
      this.pictureBox_seekBar.BackColor = System.Drawing.Color.Gray;
      this.pictureBox_seekBar.Location = new System.Drawing.Point(0, 384);
      this.pictureBox_seekBar.Name = "pictureBox_seekBar";
      this.pictureBox_seekBar.Size = new System.Drawing.Size(640, 28);
      this.pictureBox_seekBar.TabIndex = 3;
      this.pictureBox_seekBar.TabStop = false;
      // 
      // debugToolStripMenuItem
      // 
      this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem});
      this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
      this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.debugToolStripMenuItem.Text = "Debug";
      // 
      // controlToolStripMenuItem
      // 
      this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
      this.controlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.controlToolStripMenuItem.Text = "Control ";
      // 
      // ctxMenuStrip_timeline
      // 
      this.ctxMenuStrip_timeline.Name = "ctxMenuStrip_timeline";
      this.ctxMenuStrip_timeline.Size = new System.Drawing.Size(61, 4);
      // 
      // newProjectToolStripMenuItem
      // 
      this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
      this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.newProjectToolStripMenuItem.Text = "New Project";
      this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
      this.ClientSize = new System.Drawing.Size(949, 582);
      this.Controls.Add(this.pictureBox_seekBar);
      this.Controls.Add(this.pictureBox_preview);
      this.Controls.Add(this.menuBar);
      this.MainMenuStrip = this.menuBar;
      this.Name = "MainForm";
      this.Text = "c";
      this.menuBar.ResumeLayout(false);
      this.menuBar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox_seekBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuBar;
    private System.Windows.Forms.ToolStripMenuItem あいうえおToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openProjectFileToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.PictureBox pictureBox_preview;
    private System.Windows.Forms.PictureBox pictureBox_seekBar;
    private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip ctxMenuStrip_timeline;
    private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
  }
}

