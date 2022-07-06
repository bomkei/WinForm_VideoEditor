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
  public partial class MainForm : Form {
    void drawObject(TLObject obj) {
      throw new NotImplementedException();
    }

    void drawObject(TLVideoObject obj) {

    }

    public void drawPreview(int pos) {
      var objlist = _timeline_form.get_objects_on_position(pos);


    }
  }
}