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
      var (ex, ey) =
        (msBehavContext.clickedPos.X, msBehavContext.clickedPos.Y) =
        convert_mousepos_to_objpos(e.X, e.Y);

      Console.WriteLine($"{ex}, {ey}");

      msBehavContext.clicked = get_object_from_pos(ex, ey);
      var clickedIndex = objects.IndexOf(msBehavContext.clicked);

      if (msBehavContext.clicked != null) {
        msBehavContext.collid = check_obj_collid(msBehavContext.clicked);
        //_obj_collid_index = objects.IndexOf(_obj_collid);
      }

      if (msBehavContext.clicked == null) {
        if (e.Button == MouseButtons.Left) {
          msBehavContext.isDown = true;
          msBehavContext.kind = MouseBehaviorKind.MoveSeekbar;
          seekbar_pos = ex;
        }
        else if (e.Button == MouseButtons.Right) {
          ctxMenuStrip_timeline.Show(_pictureBox_layers, e.Location);
        }
      }
      else {
        if (e.Button == MouseButtons.Left) {
          msBehavContext.isDown = true;
          msBehavContext.kind = MouseBehaviorKind.MoveObject;
          msBehavContext.diff = msBehavContext.clicked.position - ex;
        }
        else if (e.Button == MouseButtons.Right) {
          ctxMenuStrip_tlobj.Show(_pictureBox_layers, e.Location);
        }
      }

      draw();

    }

    private void _pictureBox_layers_MouseMove(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!msBehavContext.isDown)
        return;

      switch (msBehavContext.kind) {
        case MouseBehaviorKind.MoveSeekbar:
          seekbar_pos = ex;
          break;

        case MouseBehaviorKind.MoveObject: {
          ex += msBehavContext.diff;
          var collid = is_exists_obj_in_range(ey, ex, msBehavContext.clicked.length, msBehavContext.clicked);

          if (collid != null) {
            if (collid.center < ex - msBehavContext.diff &&
              is_exists_obj_in_range(ey, collid.endpos, msBehavContext.clicked.length, msBehavContext.clicked) == null) {
              ex = collid.endpos;
            }
            else if (ex - msBehavContext.diff < collid.center &&
              is_exists_obj_in_range(ey, collid.position - msBehavContext.clicked.length, msBehavContext.clicked.length, msBehavContext.clicked) == null) {
              ex = collid.position - msBehavContext.clicked.length;
            }
            else if (is_exists_obj_in_range(msBehavContext.clicked.layer, ex, msBehavContext.clicked.length, msBehavContext.clicked) == null) {
              ey = msBehavContext.clicked.layer;
            }
            else {
              break;
            }

            if (ex < 0) {
              break;
            }
          }

          (msBehavContext.clicked.position, msBehavContext.clicked.layer) = (ex, ey);

          if (msBehavContext.clicked.position < 0)
            msBehavContext.clicked.position = 0;

          if (msBehavContext.clicked != null) {
            msBehavContext.collid = check_obj_collid(msBehavContext.clicked);
            //_obj_collid_index = objects.IndexOf(_obj_collid);
          }

          break;
        }
      }


      draw();
    }

    private void _pictureBox_layers_MouseUp(object sender, MouseEventArgs e) {
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!msBehavContext.isDown) {
        return;
      }

      switch (msBehavContext.kind) {
        case MouseBehaviorKind.MoveSeekbar:
          seekbar_pos = ex;
          break;

        case MouseBehaviorKind.MoveObject:


          break;
      }

      msBehavContext.isDown = false;

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