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
    }

    MainForm _mainform;
    //TimelineCore _core;

    PictureBox _pictureBox_layers;
    Bitmap _layers_bmp;
    Graphics _layers_gra;
    Font _font;

    bool _is_mouse_down;
    int _obj_click_diff;
    TLObject _clicked_obj;
    MouseBehaviorKind _mouse_behavior_kind;

    public int seekbar_pos;
    public int scroll_pos;

    int video_FPS;
    double tlScale;

    public List<TLObject> objects {
      get;
      private set;
    }

    public TimelineForm(MainForm mainform) {

      this._mainform = mainform;

      this.init_form();

    }

    ~TimelineForm() {
      this._layers_gra.Dispose();
      this._layers_bmp.Dispose();
      this._font.Dispose();
    }


    public void draw() {

      ref var gra = ref this._layers_gra;
      var layersCount = -1;
      var dy = 0;

      const int bottomBarSize = 24;

      gra.Clear(Color.FromArgb(32, 32, 32));

      // frames ?
      {
        int spos = seekbar_pos;
        int hour = spos / (video_FPS * 60 * 60);
        int min = spos / (video_FPS * 60);
        double sec = (double)spos / (double)video_FPS;

        double blockw = video_FPS * tlScale;
        int incl = 100 / (int)blockw;

        gra.FillRectangle(new SolidBrush(Color.FromArgb(56, 56, 56)), 0, 0, _pictureBox_layers.Width, frameBarHeight);

        for (int i = 0, j = (int)(_pictureBox_layers.Width / video_FPS * tlScale); i <= j; i += incl) {
          int x = i * (int)blockw;

          gra.DrawLine(Pens.White, x, 0, x, frameBarHeight);
        }

        dy += frameBarHeight;
      }

      // Objects
      {
        int objDrawLeave = bottomBarSize;
        int _actual_max = _pictureBox_layers.Height - objDrawLeave;
        int _height = _pictureBox_layers.Height - objDrawLeave - dy;

        foreach (var obj in this.objects) {
          var loc = new Point(obj.position - this.scroll_pos, dy + obj.layer * LayerHeight);

          if (loc.Y > _actual_max || loc.X > _pictureBox_layers.Width) {
            continue;
          }

          if (obj.layer > layersCount) {
            for (; layersCount <= obj.layer; layersCount++) {
              if (layersCount < 0)
                continue;

              var y = dy + layersCount * this.LayerHeight;

              gra.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), 0, y, this._pictureBox_layers.Width, this.LayerHeight);
            }

          }

          gra.FillRectangle(new SolidBrush(obj.color), loc.X, loc.Y, obj.length, this.LayerHeight - 1);
          gra.DrawRectangle(Pens.LightGray, loc.X, loc.Y, obj.length - 1, this.LayerHeight - 1);



        }

        // Seek bar
        {
          var xbar = seekbar_pos - scroll_pos;

          gra.DrawLine(Pens.Red, xbar, dy, xbar, dy + _height);
        }

        dy = _actual_max;
      }


      // bottom bar
      {
        var barw = bottomBarSize;

        gra.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)),
          0, this._pictureBox_layers.Height - barw, this._pictureBox_layers.Width, barw);

        gra.DrawRectangle(Pens.Gray,
          0, this._pictureBox_layers.Height - barw, this._pictureBox_layers.Width - 1, barw - 1);

        gra.DrawString($"Position = {seekbar_pos}",
          _font, Brushes.LightGray, 8, this._pictureBox_layers.Height - barw + 4);
      }

      this._pictureBox_layers.Image = this._layers_bmp;
    }


    public void add_object(TLObject obj) {
      this.objects.Add(obj);
    }

    public TLObject get_object_from_pos(int pos, int layer) {
      foreach (var obj in objects) {
        if (obj.layer != layer)
          continue;

        if (obj.position <= pos && pos < obj.position + obj.length) {
          return obj;
        }
      }

      return null;
    }


    private void init_form() {

      this._pictureBox_layers = new PictureBox();
      this._pictureBox_layers.Dock = DockStyle.Fill;
      this._pictureBox_layers.MouseDown += _pictureBox_layers_MouseDown;
      this._pictureBox_layers.MouseMove += _pictureBox_layers_MouseMove;
      this._pictureBox_layers.MouseUp += _pictureBox_layers_MouseUp;
      this._pictureBox_layers.MouseWheel += _pictureBox_layers_MouseWheel;

      this._layers_bmp = new Bitmap(LayersBitmapSize.Width, LayersBitmapSize.Height);
      this._layers_gra = Graphics.FromImage(this._layers_bmp);
      this._font = new Font("MS Gothic", 10);

      this.objects = new List<TLObject>();

      this.Paint += (object obj, PaintEventArgs e) => { draw(); };
      this.SizeChanged += TimelineForm_SizeChanged;

      this.Controls.Add(this._pictureBox_layers);

      this.video_FPS = 60;
      this.tlScale = 1.0;

    }

    private void TimelineForm_SizeChanged(object sender, EventArgs e) {
      this.draw();
    }

    private (int, int) convert_mousepos_to_objpos(int x, int y) {
      if (x < 0)
        x = 0;

      if (y < 0)
        y = 0;

      return (x + scroll_pos, y / LayerHeight);
    }

    private (int, int) convert_objpos_to_mousepos(int x, int y) {
      return (x - scroll_pos, y * LayerHeight);
    }

    private void _pictureBox_layers_MouseDown(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);


      var obj = get_object_from_pos(ex, ey);

      if (obj == null) {
        _is_mouse_down = true;

        if (e.Button == MouseButtons.Left) {
          _mouse_behavior_kind = MouseBehaviorKind.MoveSeekbar;
          this.seekbar_pos = ex;
        }
      }
      else {
        if (e.Button == MouseButtons.Left) {
          _is_mouse_down = true;
          _mouse_behavior_kind = MouseBehaviorKind.MoveObject;
          _obj_click_diff = obj.position - ex;
          _clicked_obj = obj;
        }
        else if (e.Button == MouseButtons.Right) {
          _mainform.ctxMenuStrip_tlobj.Show(this._pictureBox_layers, e.Location);
        }
      }

      this.draw();

    }

    private void _pictureBox_layers_MouseMove(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!_is_mouse_down)
        return;

      switch (_mouse_behavior_kind) {
        case MouseBehaviorKind.MoveSeekbar:
          this.seekbar_pos = ex;
          break;

        case MouseBehaviorKind.MoveObject:
          _clicked_obj.position = ex + _obj_click_diff;
          break;
      }


      this.draw();
    }

    private void _pictureBox_layers_MouseUp(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!_is_mouse_down) {
        return;
      }

      switch (_mouse_behavior_kind) {
        case MouseBehaviorKind.MoveSeekbar:
          this.seekbar_pos = ex;
          break;

        case MouseBehaviorKind.MoveObject:
          _clicked_obj.position = ex + _obj_click_diff;
          break;
      }

      _is_mouse_down = false;

      this.draw();
    }

    private void _pictureBox_layers_MouseWheel(object sender, MouseEventArgs e) {

      this.scroll_pos -= e.Delta / 4;

      if (this.scroll_pos < 0) {
        this.scroll_pos = 0;
      }

      this.draw();

    }



  }
}