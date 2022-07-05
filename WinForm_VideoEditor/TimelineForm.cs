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

    readonly int FirstLayersCount = 4;
    readonly int LayerHeight = 24;

    readonly int 


    MainForm _mainform;
    //TimelineCore _core;

    PictureBox _pictureBox_layers;
    Bitmap _layers_bmp;
    Graphics _layers_gra;

    public List<TLObject> objects {
      get;
      private set;
    }

    public TimelineForm(MainForm mainform) {

      this._mainform = mainform;

      this.init_form();

    }

    ~TimelineForm() {
      this._layers_gra.Dispose();
    }


    public void update() {

    }


    public void add_object(TLObject obj) {
      this.objects.Add(obj);
    }

    private void init_form() {

      this._pictureBox_layers = new PictureBox();
      this._layers_bmp = new Bitmap()



    }





  }
}
