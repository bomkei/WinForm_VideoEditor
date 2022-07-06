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
  public partial class TLVideoObject : TLObject {
    string __path;

    public string path {
      get {
        return __path;
      }
      set {
        name = System.IO.Path.GetFileName(value);

        __path = value;
      }
    }

    public TLVideoObject(int layer, int pos)
      : base(layer, pos) {
      kind = Kind.Video;
    }
  }
}