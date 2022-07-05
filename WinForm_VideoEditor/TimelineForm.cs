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
    TLObject _obj_collid;
    int _obj_collid_index;
    int _clicked_obj_index;
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

    [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
    static extern bool AllocConsole();

    public TimelineForm(MainForm mainform) {

      AllocConsole();

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
        

        double blockw = video_FPS * tlScale;
        int incl = 150 / (int)blockw;

        gra.FillRectangle(new SolidBrush(Color.FromArgb(56, 56, 56)), 0, 0, _pictureBox_layers.Width, frameBarHeight);

        for (int f = 0, i = 0, j = (int)((_pictureBox_layers.Width + scroll_pos) / video_FPS * tlScale); i <= j; i += incl, f += incl * video_FPS) {
          int x = (int)(i * blockw - scroll_pos * tlScale);

          if (x < 0)
            continue;

          int hour = f/ (video_FPS * 60 * 60);
          int min = f / (video_FPS * 60);
          double sec = (double)f / (double)video_FPS;

          gra.DrawLine(Pens.White, x, 0, x, frameBarHeight);
          gra.DrawString($"{hour}:{min}:{sec}", _font, Brushes.Gray, x, 2);
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

          if (obj.layer >= layersCount) {
            for (; layersCount <= obj.layer; layersCount++) {
              if (layersCount < 0)
                continue;

              var y = dy + layersCount * this.LayerHeight;

              gra.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), 0, y, this._pictureBox_layers.Width, this.LayerHeight);
            }

          }

          if (loc.Y > _actual_max || loc.X > _pictureBox_layers.Width) {
            continue;
          }

          gra.FillRectangle(new SolidBrush(obj.color), loc.X, loc.Y, obj.length, this.LayerHeight - 1);

          if (obj == _clicked_obj) {
            gra.DrawRectangle(Pens.DodgerBlue, loc.X, loc.Y, obj.length - 1, this.LayerHeight - 1);
          }
          else {
            gra.DrawRectangle(Pens.LightGray, loc.X, loc.Y, obj.length - 1, this.LayerHeight - 1);
          }



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

        gra.DrawString(
          $"Scrollpos={scroll_pos}, Seekbar={seekbar_pos}, Clicked={objects.IndexOf(_clicked_obj)}, Collid={_obj_collid_index}",
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
      y -= frameBarHeight;

      if (x < 0)
        x = 0;

      if (y < 0)
        y = 0;

      return (x + scroll_pos, y / LayerHeight);
    }

    private (int, int) convert_objpos_to_mousepos(int x, int y) {
      return (x - scroll_pos, y * LayerHeight);
    }

    private bool _is_item_collid(int l, int r, int ll, int rr)
      => l > ll ? _is_item_collid(ll, rr, l, r) : ll <= r;

    private TLObject is_exists_obj_in_range(int layer, int pos, int len, TLObject ignore = null) {
      foreach (var obj in objects) {
        if (obj == ignore || obj.layer != layer)
          continue;

        if (pos <= obj.position && obj.position < pos + len)
          return obj;

        if (pos <= obj.endpos - 1 && obj.endpos - 1 < pos + len)
          return obj;

        if (obj.position <= pos && pos + len <= obj.position + obj.length)
          return obj;
      }

      return null;
    }

    private TLObject check_obj_collid(TLObject obj) {
      return is_exists_obj_in_range(obj.layer, obj.position, obj.length, obj);
    }

    private void _pictureBox_layers_MouseDown(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);


      _clicked_obj = get_object_from_pos(ex, ey);
      _clicked_obj_index = objects.IndexOf(_clicked_obj);

      if (_clicked_obj != null) {
        _obj_collid = check_obj_collid(_clicked_obj);
        _obj_collid_index = objects.IndexOf(_obj_collid);
      }

      if (_clicked_obj == null) {
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
          _obj_click_diff = _clicked_obj.position - ex;
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

        case MouseBehaviorKind.MoveObject: {
          ex += _obj_click_diff;
          var collid = is_exists_obj_in_range(ey, ex, _clicked_obj.length, _clicked_obj);

          if (collid != null) {
            if (collid.center < ex - _obj_click_diff &&
              is_exists_obj_in_range(ey, collid.endpos, _clicked_obj.length, _clicked_obj) == null) {
              ex = collid.endpos;
            }
            else if (ex - _obj_click_diff < collid.center &&
              is_exists_obj_in_range(ey, collid.position - _clicked_obj.length, _clicked_obj.length, _clicked_obj) == null) {
              ex = collid.position - _clicked_obj.length;
            }
            else if (is_exists_obj_in_range(_clicked_obj.layer, ex, _clicked_obj.length, _clicked_obj) == null) {
              ey = _clicked_obj.layer;
            }
            else {
              break;
            }

            if (ex < 0) {
              break;
            }

          }

          (_clicked_obj.position, _clicked_obj.layer) = (ex, ey);

          if (_clicked_obj.position < 0)
            _clicked_obj.position = 0;

          if (_clicked_obj != null) {
            _obj_collid = check_obj_collid(_clicked_obj);
            _obj_collid_index = objects.IndexOf(_obj_collid);
          }

          break;
        }
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
          var collid = is_exists_obj_in_range(ey, ex + _obj_click_diff, _clicked_obj.length, _clicked_obj);

          if (collid != null) {
            break;
          }

          (_clicked_obj.position, _clicked_obj.layer) = (ex + _obj_click_diff, ey);

          if (_clicked_obj.position < 0)
            _clicked_obj.position = 0;

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