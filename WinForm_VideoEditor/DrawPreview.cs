using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WinForm_VideoEditor {
  public partial class MainForm : Form {
    bool _preview_drawing;
    static Mutex mtx = new Mutex();

    void drawObject(ref Graphics gra, TLObject obj, int fpos) {

      switch (obj.kind) {
        case TLObject.Kind.Video: {
          var video = (TLVideoObject)obj;
          var mat = new Mat();

          video.vcap.PosFrames = fpos;
          video.vcap.Read(mat);

          var bmp = BitmapConverter.ToBitmap(mat);

          gra.DrawImage(bmp, video.X, video.Y, 640, 360);

          mat.Dispose();
          bmp.Dispose();

          break;
        }
      }
    }

    public void drawPreview(int pos) {
      var t = new Thread(new ThreadStart(() => {
        mtx.WaitOne();
        
        _preview_drawing = true;

        var objlist = _timeline_form.get_objects_on_position(pos);
        ref var gra = ref gra_preview;

        //gra.Clear(Color.Black);

        foreach (var obj in objlist) {
          drawObject(ref gra, obj.Item1, obj.Item2);
        }

        //pictureBox_preview.Image = bmp_preview;

        pictureBox_preview.Image = bmp_preview;

        _preview_drawing = false;
        mtx.ReleaseMutex();

      }));

      if (_preview_drawing) {
        return;
      }
      else if (t.ThreadState != ThreadState.Unstarted) {
        t.Join();
      }

      Console.WriteLine("draw preview");
      t.Start();
      //pictureBox_preview.Image = bmp_preview;

      //if (_preview_drawing || _timeline_form == null) {
      //  return;
      //}

      //Console.WriteLine("draw preview");
      //t.Start();


    }
  }
}