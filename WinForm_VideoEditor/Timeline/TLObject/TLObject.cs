using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_VideoEditor {
  public partial class TLObject {
    public enum Kind {
      None,
      Text,
      Sound,
      Video
    }

    public Kind kind;
    public string name;

    public int layer;
    public int position;

    public int length;

    public int center {
      get {
        return position + length / 2;
      }
    }

    public int endpos {
      get {
        return position + length;
      }
    }

    public TLObject(int layer, int position) {
      kind = Kind.None;
      name = string.Empty;

      this.layer = layer;
      this.position = position;


    }

    public Color color {
      get {
        switch (kind) {
          case Kind.None: break;
          case Kind.Text: return Color.LightGreen;
          case Kind.Sound: return Color.RoyalBlue;
        }

        return Color.DimGray;
      }
    }
  }
}