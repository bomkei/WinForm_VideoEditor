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
    TLObject get_object_from_pos(int pos, int layer) {
      foreach (var obj in objects) {
        if (obj.layer != layer)
          continue;

        if (obj.position <= pos && pos < obj.position + obj.length) {
          return obj;
        }
      }

      return null;
    }

    (int, int) convert_mousepos_to_objpos(int x, int y) {
      y -= frameBarHeight;

      if (x < 0)
        x = 0;

      if (y < 0)
        y = 0;

      return (x + scroll_pos, y / LayerHeight);
    }

    (int, int) convert_objpos_to_mousepos(int x, int y) {
      return (x - scroll_pos, y * LayerHeight);
    }

    bool _is_item_collid(int l, int r, int ll, int rr)
      => l > ll ? _is_item_collid(ll, rr, l, r) : ll <= r;

    TLObject is_exists_obj_in_range(int layer, int pos, int len, TLObject ignore = null) {
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

    TLObject check_obj_collid(TLObject obj) {
      return is_exists_obj_in_range(obj.layer, obj.position, obj.length, obj);
    }

    public List<(TLObject, int)> get_objects_on_position(int pos) {
      var ret = new List<(TLObject, int)>();

      foreach (var obj in objects) {
        if (obj.position <= pos && pos < obj.endpos)
          ret.Add((obj, pos - obj.position));
      }

      return ret.OrderBy(x => x.Item1.layer).ToList();
    }
  }
}