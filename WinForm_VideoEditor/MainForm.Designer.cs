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
      this.menuBar = new System.Windows.Forms.MenuStrip();
      this.あいうえおToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openProjectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pictureBox_preview = new System.Windows.Forms.PictureBox();
      this.pictureBox_seekBar = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.environmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
      // newProjectToolStripMenuItem
      // 
      this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
      this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.newProjectToolStripMenuItem.Text = "New Project";
      this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.openToolStripMenuItem.Text = "Open";
      // 
      // openProjectFileToolStripMenuItem
      // 
      this.openProjectFileToolStripMenuItem.Name = "openProjectFileToolStripMenuItem";
      this.openProjectFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.openProjectFileToolStripMenuItem.Text = "Open Project File";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.saveToolStripMenuItem.Text = "Save";
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.saveAsToolStripMenuItem.Text = "Save as ...";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem,
            this.environmentToolStripMenuItem});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // aToolStripMenuItem
      // 
      this.aToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.aToolStripMenuItem.Name = "aToolStripMenuItem";
      this.aToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.aToolStripMenuItem.Text = "Editor";
      // 
      // debugToolStripMenuItem
      // 
      this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.consoleToolStripMenuItem});
      this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
      this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
      this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.debugToolStripMenuItem.Text = "Debug";
      // 
      // controlToolStripMenuItem
      // 
      this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
      this.controlToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.controlToolStripMenuItem.Text = "Control ";
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
      this.pictureBox_seekBar.Size = new System.Drawing.Size(589, 28);
      this.pictureBox_seekBar.TabIndex = 3;
      this.pictureBox_seekBar.TabStop = false;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(590, 384);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(50, 28);
      this.button1.TabIndex = 5;
      this.button1.Text = "再生";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // consoleToolStripMenuItem
      // 
      this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
      this.consoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.consoleToolStripMenuItem.Text = "console";
      this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
      // 
      // editorToolStripMenuItem
      // 
      this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
      this.editorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.editorToolStripMenuItem.Text = "Editor";
      // 
      // environmentToolStripMenuItem
      // 
      this.environmentToolStripMenuItem.Name = "environmentToolStripMenuItem";
      this.environmentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.environmentToolStripMenuItem.Text = "Environment";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
      this.ClientSize = new System.Drawing.Size(949, 624);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.pictureBox_seekBar);
      this.Controls.Add(this.pictureBox_preview);
      this.Controls.Add(this.menuBar);
      this.MainMenuStrip = this.menuBar;
      this.Name = "MainForm";
      this.Text = "Video Editor";
      this.Load += new System.EventHandler(this.MainForm_Load);
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
    private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem environmentToolStripMenuItem;
  }
}

