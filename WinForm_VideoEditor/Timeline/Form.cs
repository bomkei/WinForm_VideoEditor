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

      _mainform = mainform;

      init_form();

    }

    ~TimelineForm() {
      _layers_gra.Dispose();
      _layers_bmp.Dispose();
      _font.Dispose();
    }


    public void draw() {

      ref var gra = ref _layers_gra;
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

        foreach (var obj in objects) {
          var loc = new Point(obj.position - scroll_pos, dy + obj.layer * LayerHeight);

          if (obj.layer >= layersCount) {
            for (; layersCount <= obj.layer; layersCount++) {
              if (layersCount < 0)
                continue;

              var y = dy + layersCount * LayerHeight;

              gra.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), 0, y, _pictureBox_layers.Width, LayerHeight);
            }

          }

          if (loc.Y > _actual_max || loc.X > _pictureBox_layers.Width) {
            continue;
          }

          gra.FillRectangle(new SolidBrush(obj.color), loc.X, loc.Y, obj.length, LayerHeight - 1);

          if (obj == _clicked_obj) {
            gra.DrawRectangle(Pens.DodgerBlue, loc.X, loc.Y, obj.length - 1, LayerHeight - 1);
          }
          else {
            gra.DrawRectangle(Pens.LightGray, loc.X, loc.Y, obj.length - 1, LayerHeight - 1);
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
          0, _pictureBox_layers.Height - barw, _pictureBox_layers.Width, barw);

        gra.DrawRectangle(Pens.Gray,
          0, _pictureBox_layers.Height - barw, _pictureBox_layers.Width - 1, barw - 1);

        gra.DrawString(
          $"Scrollpos={scroll_pos}, Seekbar={seekbar_pos}, Clicked={objects.IndexOf(_clicked_obj)}, Collid={_obj_collid_index}",
          _font, Brushes.LightGray, 8, _pictureBox_layers.Height - barw + 4);
      }

      _pictureBox_layers.Image = _layers_bmp;
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

      _layers_bmp = new Bitmap(LayersBitmapSize.Width, LayersBitmapSize.Height);
      _layers_gra = Graphics.FromImage(_layers_bmp);
      _font = new Font("MS Gothic", 10);

      objects = new List<TLObject>();

      Paint += (object obj, PaintEventArgs e) => { draw(); };
      SizeChanged += TimelineForm_SizeChanged;

      Controls.Add(_pictureBox_layers);

      video_FPS = 60;
      tlScale = 1.0;

    }

  }
}