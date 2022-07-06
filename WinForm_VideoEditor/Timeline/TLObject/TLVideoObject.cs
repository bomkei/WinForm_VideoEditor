using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using SharpDX.MediaFoundation;

namespace WinForm_VideoEditor {
  public partial class TLVideoObject : TLObject {
    public string path { get; private set; }

    public VideoCapture vcap;

    public TLVideoObject(string path, int layer, int pos)
      : base(layer, pos) {
      kind = Kind.Video;
      this.path = path;
      this.name = Path.GetFileName(path);

      vcap = new VideoCapture(path);


    }

    ~TLVideoObject() {
      vcap.Dispose();
    }

    //public void open() {
    //  vcap = new VideoCapture(path);
    //}
  }
}