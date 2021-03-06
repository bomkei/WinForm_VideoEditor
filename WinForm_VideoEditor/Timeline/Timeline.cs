using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinForm_VideoEditor {
  public partial class Timeline {

    readonly int LayerHeight = 24;
    readonly int frameBarHeight = 16;

    readonly Size LayersBitmapSize = new Size(2000, 1100);
    public enum MouseBehaviorKind {
      MoveSeekbar,
      MoveObject,
      ChangeObjectLength_Left,
      ChangeObjectLength_Right,
    }

    public struct MouseBehaviorContext {
      public MouseBehaviorKind kind;
      public bool isDown;
      public int diff;
      public TLObject clicked;
      public TLObject collid;
      public Point clickedPos;

    }

    MainForm _mainform;

    PictureBox _pictureBox_layers;
    Bitmap _layers_bmp;
    Graphics _layers_gra;
    Font _font;

    ContextMenuStrip ctxMenuStrip_tlobj;
    ContextMenuStrip ctxMenuStrip_timeline;

    public MouseBehaviorContext msBehavContext;
    public int seekbar_pos;
    public int scroll_pos;

    int video_FPS;
    double tlScale;

    public List<TLObject> objects {
      get;
      private set;
    }

    public Timeline(MainForm mainform) {

      _mainform = mainform;
      _pictureBox_layers = mainform.pictureBox_timeline;

      init_form();

    }

    public void add_object(TLObject obj) {
      objects.Add(obj);

      // todo: rewrite
      //while (check_obj_collid(obj) != null) {
      //  obj.position++;
      //}
    }

    private void init_form() {

      //_pictureBox_layers = new PictureBox();
      //_pictureBox_layers.Dock = DockStyle.Fill;
      _pictureBox_layers.MouseDown += _pictureBox_layers_MouseDown;
      _pictureBox_layers.MouseMove += _pictureBox_layers_MouseMove;
      _pictureBox_layers.MouseUp += _pictureBox_layers_MouseUp;
      _pictureBox_layers.MouseWheel += _pictureBox_layers_MouseWheel;

      
      ctxMenuStrip_tlobj = new ContextMenuStrip();
      ctxMenuStrip_tlobj.Items.Add("Trim");
      ctxMenuStrip_tlobj.Items.Add(new ToolStripSeparator());
      ctxMenuStrip_tlobj.Items.Add("Hide");
      ctxMenuStrip_tlobj.Items.Add("Show");
      ctxMenuStrip_tlobj.Items.Add(new ToolStripSeparator());
      ctxMenuStrip_tlobj.Items.Add("Delete");

      {
        ctxMenuStrip_timeline = new ContextMenuStrip();

        var item = new ToolStripMenuItem("Add object"); {
          var dropdown = new ToolStripMenuItem("Text");
          item.DropDownItems.Add(dropdown);

          dropdown = new ToolStripMenuItem("Video");
          dropdown.Click += (object sender, EventArgs e) => {
            using (var openf = new OpenFileDialog()) {
              openf.Title = "Load a video file (MP4)";
              openf.Filter = "MP4 File|*.mp4";
              openf.RestoreDirectory = true;

              if (openf.ShowDialog() == DialogResult.OK) {
                var obj = new TLVideoObject(openf.FileName, 0, 0);

                add_object(obj);
              }
            }

            draw();
          };
          item.DropDownItems.Add(dropdown);
        }



        ctxMenuStrip_timeline.Items.Add(item);
      }

      _layers_bmp = new Bitmap(LayersBitmapSize.Width, LayersBitmapSize.Height);
      _layers_gra = Graphics.FromImage(_layers_bmp);
      _font = new Font("Meiryo", 10);

      objects = new List<TLObject>();

      //this.Paint += (object obj, PaintEventArgs e) => { draw(); };
      ////this.SizeChanged += TimelineForm_SizeChanged;

      //this.KeyDown += TimelineForm_KeyDown;
      //this.KeyUp += TimelineForm_KeyUp;

      //Controls.Add(_pictureBox_layers);

      video_FPS = 60;
      tlScale = 1.0;

    }

  }
}