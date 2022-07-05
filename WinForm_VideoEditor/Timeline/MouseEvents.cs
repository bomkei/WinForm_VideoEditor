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


    private void _pictureBox_layers_MouseDown(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      _clicked_obj = get_object_from_pos(ex, ey);
      _clicked_obj_index = objects.IndexOf(_clicked_obj);

      if (_clicked_obj != null) {
        _obj_collid = check_obj_collid(_clicked_obj);
        _obj_collid_index = objects.IndexOf(_obj_collid);
      }

      if (_clicked_obj == null) {
        if (e.Button == MouseButtons.Left) {
          _is_mouse_down = true;
          _mouse_behavior_kind = MouseBehaviorKind.MoveSeekbar;
          seekbar_pos = ex;
        }
      }
      else {
        if (e.Button == MouseButtons.Left) {
          _is_mouse_down = true;
          _mouse_behavior_kind = MouseBehaviorKind.MoveObject;
          _obj_click_diff = _clicked_obj.position - ex;
        }
        else if (e.Button == MouseButtons.Right) {
          ctxMenuStrip_tlobj.Show(_pictureBox_layers, e.Location);
        }
      }

      draw();

    }

    private void _pictureBox_layers_MouseMove(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!_is_mouse_down)
        return;

      switch (_mouse_behavior_kind) {
        case MouseBehaviorKind.MoveSeekbar:
          seekbar_pos = ex;
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


      draw();
    }

    private void _pictureBox_layers_MouseUp(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!_is_mouse_down) {
        return;
      }

      switch (_mouse_behavior_kind) {
        case MouseBehaviorKind.MoveSeekbar:
          seekbar_pos = ex;
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

      draw();
    }

    private void _pictureBox_layers_MouseWheel(object sender, MouseEventArgs e) {

      scroll_pos -= e.Delta / 4;

      if (scroll_pos < 0) {
        scroll_pos = 0;
      }

      draw();

    }



  }
}