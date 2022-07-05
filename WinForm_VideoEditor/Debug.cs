#define __DEBUG__

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_VideoEditor {
  public static partial class Debug {
    static void AlertBase(int n) {
#if __DEBUG__
      var callStack = new StackFrame(n, true);

      var filename = callStack.GetFileName();

      filename = filename.Substring(filename.IndexOf("WinForm_VideoEditor"));
      filename = filename.Substring(filename.IndexOf('\\') + 1);

      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write($"\t#Alert {filename}: {callStack.GetMethod()}: {callStack.GetFileLineNumber()}");
#endif
    }

    public static void Alert() {
      AlertBase(2);
      Console.WriteLine();
      Console.ResetColor();
    }

    public static void Alert(string fmt, params object[] args) {
      AlertBase(2);
      Console.WriteLine(fmt, args);
      Console.ResetColor();
    }
  }
}