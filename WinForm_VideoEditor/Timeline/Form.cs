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
  public partial class TimelineForm : Form {

    readonly int LayerHeight = 24;
    readonly int frameBarHeight = 16;

    readonly Size LayersBitmapSize = new Size(2000, 1100);
    enum MouseBehaviorKind {
      MoveSeekbar,
      MoveObject,
      ChangeObjectLength_Left,
      ChangeObjectLength_Right,
    }

    MainForm _mainform;
    //TimelineCore _core;

    PictureBox _pictureBox_layers;
    Bitmap _layers_bmp;
    Graphics _layers_gra;
    Font _font;

    bool _is_mouse_down;
    int _obj_click_diff;
    TLObject _obj_collid;
    int _obj_collid_index;
    int _clicked_obj_index;
    TLObject _clicked_obj;
    MouseBehaviorKind _mouse_behavior_kind;

    ContextMenuStrip ctxMenuStrip_tlobj;

    public int seekbar_pos;
    public int scroll_pos;

    int video_FPS;
    double tlScale;

    public List<TLObject> objects {
      get;
      private set;
    }

    public TimelineForm(MainForm mainform) {

      _mainform = mainform;

      init_form();

    }

    ~TimelineForm() {
      _layers_gra.Dispose();
      _layers_bmp.Dispose();
      _font.Dispose();
    }

    public void add_object(TLObject obj) {
      objects.Add(obj);
    }

    private void init_form() {

      _pictureBox_layers = new PictureBox();
      _pictureBox_layers.Dock = DockStyle.Fill;
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


      _layers_bmp = new Bitmap(LayersBitmapSize.Width, LayersBitmapSize.Height);
      _layers_gra = Graphics.FromImage(_layers_bmp);
      _font = new Font("Meiryo", 10);

      objects = new List<TLObject>();

      this.Paint += (object obj, PaintEventArgs e) => { draw(); };
      this.SizeChanged += TimelineForm_SizeChanged;

      this.KeyDown += TimelineForm_KeyDown;
      this.KeyUp += TimelineForm_KeyUp;

      Controls.Add(_pictureBox_layers);

      video_FPS = 60;
      tlScale = 1.0;

    }

  }
}