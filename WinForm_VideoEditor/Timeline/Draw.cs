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

          int hour = f / (video_FPS * 60 * 60);
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

          gra.FillRectangle(new SolidBrush(Color.DimGray), loc.X, loc.Y, obj.length, LayerHeight - 1);

          if (obj == msBehavContext.clicked) {
            gra.DrawRectangle(Pens.DodgerBlue, loc.X, loc.Y, obj.length - 1, LayerHeight - 1);
          }
          else {
            gra.DrawRectangle(Pens.LightGray, loc.X, loc.Y, obj.length - 1, LayerHeight - 1);
          }

          {
            var drname = obj.name;

            while ((int)gra.MeasureString(drname, _font).Width > obj.length) {
              drname = drname.Substring(0, drname.Length - 1);
            }

            gra.DrawString(drname, _font, Brushes.Black, loc.X, loc.Y + 4);
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
          $"Scrollpos={scroll_pos}, Seekbar={seekbar_pos}," +
          $"Clicked={objects.IndexOf(msBehavContext.clicked)}, Collid={objects.IndexOf(msBehavContext.collid)}",
          _font, Brushes.LightGray, 8, _pictureBox_layers.Height - barw + 4);
      }

      _pictureBox_layers.Image = _layers_bmp;
    }
  }
}