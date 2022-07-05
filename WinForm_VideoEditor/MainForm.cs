using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_VideoEditor {
  public partial class MainForm : Form {

    TimelineForm _timeline_form;  // Timeline


    // ---------------------------------------------------------------- //
    //  Constructor
    // ---------------------------------------------------------------- //
    public MainForm() {
      this.init_form();


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
      tl.Location = new Point(0, this.pictureBox_seekBar.Bottom);

      // Size
      tl.Size = new Size(this.Width - 16, this.Height - this.pictureBox_seekBar.Bottom - 38);


      // ------

      var obj = new TLObject(0, 0);

      obj.kind = TLObject.Kind.Video;
      obj.length = 150;
      obj.name = "";
      tl.add_object(obj);

      obj = new TLObject(0, 0);
      obj.kind = TLObject.Kind.Video;
      obj.length = 150;
      obj.layer = 2;
      obj.name = "";
      tl.add_object(obj);

      // ------


      return tl;
    }



    // ---------------------------------------------------------------- //
    //  Initialize MainForm
    // ---------------------------------------------------------------- //
    void init_form() {
      this.InitializeComponent();


      // Create a new timeline instance
      this._timeline_form = init_timeline_inst(this._timeline_form);



      // Add timeline
      this.Controls.Add(this._timeline_form);


      this._timeline_form.Show();


    }

    private void newProjectToolStripMenuItem_Click(object sender, EventArgs e) {

    }

    private void MainForm_Load(object sender, EventArgs e) {

    }
  }
}
