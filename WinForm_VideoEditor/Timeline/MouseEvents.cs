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
  public partial class TimelineForm {


    private void _pictureBox_layers_MouseDown(object sender, MouseEventArgs e) {
      ref var ctx = ref msBehavContext;
      
      var (ex, ey) =
        (ctx.clickedPos.X, ctx.clickedPos.Y) =
        convert_mousepos_to_objpos(e.X, e.Y);

      Console.WriteLine($"{ex}, {ey}");

      ctx.clicked = get_object_from_pos(ex, ey);
      var clickedIndex = objects.IndexOf(ctx.clicked);

      if (ctx.clicked != null) {
        ctx.collid = check_obj_collid(ctx.clicked);
        //_obj_collid_index = objects.IndexOf(_obj_collid);
      }

      if (ctx.clicked == null) {
        if (e.Button == MouseButtons.Left) {
          ctx.isDown = true;
          ctx.kind = MouseBehaviorKind.MoveSeekbar;
          seekbar_pos = ex;
        }
        else if (e.Button == MouseButtons.Right) {
          ctxMenuStrip_timeline.Show(_pictureBox_layers, e.Location);
        }
      }
      else {
        if (e.Button == MouseButtons.Left) {
          ctx.isDown = true;
          ctx.kind = MouseBehaviorKind.MoveObject;
          ctx.diff = ctx.clicked.position - ex;
        }
        else if (e.Button == MouseButtons.Right) {
          ctxMenuStrip_tlobj.Show(_pictureBox_layers, e.Location);
        }
      }

      draw();

    }

    private void _pictureBox_layers_MouseMove(object sender, MouseEventArgs e) {
      ref var ctx = ref msBehavContext;
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!ctx.isDown)
        return;

      switch (ctx.kind) {
        case MouseBehaviorKind.MoveSeekbar:
          seekbar_pos = ex;
          break;

        case MouseBehaviorKind.MoveObject: {
          ex += ctx.diff;
          var collid = is_exists_obj_in_range(ey, ex, ctx.clicked.length, ctx.clicked);

          if (collid != null) {
            if (collid.center < ex - ctx.diff &&
              is_exists_obj_in_range(ey, collid.endpos, ctx.clicked.length, ctx.clicked) == null) {
              ex = collid.endpos;
            }
            else if (ex - ctx.diff < collid.center &&
              is_exists_obj_in_range(ey, collid.position - ctx.clicked.length, ctx.clicked.length, ctx.clicked) == null) {
              ex = collid.position - ctx.clicked.length;
            }
            else if (is_exists_obj_in_range(ctx.clicked.layer, ex, ctx.clicked.length, ctx.clicked) == null) {
              ey = ctx.clicked.layer;
            }
            else {
              break;
            }

            if (ex < 0) {
              break;
            }
          }

          (ctx.clicked.position, ctx.clicked.layer) = (ex, ey);

          if (ctx.clicked.position < 0)
            ctx.clicked.position = 0;

          if (ctx.clicked != null) {
            ctx.collid = check_obj_collid(ctx.clicked);
            //_obj_collid_index = objects.IndexOf(_obj_collid);
          }

          break;
        }
      }


      draw();
    }

    private void _pictureBox_layers_MouseUp(object sender, MouseEventArgs e) {
      ref var ctx = ref msBehavContext;
      var (ex, ey) = convert_mousepos_to_objpos(e.X, e.Y);

      if (!ctx.isDown) {
        return;
      }

      switch (ctx.kind) {
        case MouseBehaviorKind.MoveSeekbar:
          seekbar_pos = ex;
          break;

        case MouseBehaviorKind.MoveObject:


          break;
      }

      ctx.isDown = false;

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