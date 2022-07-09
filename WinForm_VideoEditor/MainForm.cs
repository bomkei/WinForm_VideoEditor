using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_VideoEditor {
  public partial class MainForm : Form {

    readonly int preview_bitmap_width = 640;
    readonly int preview_bitmap_height= 360;

    TimelineForm _timeline_form;  // Timeline

    Graphics gra_preview;
    Bitmap bmp_preview;
    Bitmap bmp_preview_black;

    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    private static extern bool AllocConsole();
    
    // ---------------------------------------------------------------- //
    //  Constructor
    // ---------------------------------------------------------------- //
    public MainForm() {

      AllocConsole();

      init_form();

      Debug.Alert();

    }

    // ---------------------------------------------------------------- //
    //  Create and Initialize TimelineForm instance
    // ---------------------------------------------------------------- //
    TimelineForm init_timeline_inst(TimelineForm tl) {

      // Create instance
      tl = new TimelineForm(this);

      // Disable 'TopLevel' flag
      tl.TopLevel = false;

      // Set border style
      tl.FormBorderStyle = FormBorderStyle.None;

      // Anchor
      tl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

      // Location on MainForm
      tl.Location = new Point(0, pictureBox_seekBar.Bottom);

      // Size
      tl.Size = new Size(Width - 16, this.ClientSize.Height - pictureBox_seekBar.Bottom);


      // ------


      // ------


      return tl;
    }



    // ---------------------------------------------------------------- //
    //  Initialize MainForm
    // ---------------------------------------------------------------- //
    void init_form() {
      InitializeComponent();

      button1.GotFocus += (object obj, EventArgs e) => { this.ActiveControl = _timeline_form; };

      bmp_preview = new Bitmap(preview_bitmap_width, preview_bitmap_height);
      bmp_preview_black = new Bitmap(preview_bitmap_width, preview_bitmap_height);
      gra_preview = Graphics.FromImage(bmp_preview);

      using (var g = Graphics.FromImage(bmp_preview_black)) {
        g.Clear(Color.Black);
      }

      // Create a new timeline instance
      _timeline_form = init_timeline_inst(_timeline_form);

    }

    private void newProjectToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void MainForm_Load(object sender, EventArgs e) {

      // Add timeline
      Controls.Add(_timeline_form);

      this.ActiveControl = _timeline_form;

    }

    private void MainForm_Shown(object sender, EventArgs e) {

      // Show timeline
      _timeline_form.Show();


    }

    private void consoleToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void MainForm_Paint(object sender, PaintEventArgs e) {

      //drawPreview(_timeline_form.seekbar_pos);

    }

  }
}
