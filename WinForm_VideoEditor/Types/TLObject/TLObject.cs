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
    public object data;

    public int Layer;
    public int Position;

    public TLObject(int layer, int position) {
      this.kind = Kind.None;
      this.name = string.Empty;
      this.data = null;

      this.Layer = layer;
      this.Position = position;


    }



  }

}