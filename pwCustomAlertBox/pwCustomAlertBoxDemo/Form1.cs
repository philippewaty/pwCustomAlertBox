using System;
using System.Windows.Forms;

namespace pwCustomAlertBoxDemo
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    public void Alert(string msg, pwCustomAlertBox.pwCustomAlertBox.TypeAlertBox type)
    {
      pwCustomAlertBox.pwCustomAlertBox frm = new pwCustomAlertBox.pwCustomAlertBox();
      frm.TimerValue = 5000;
      frm.showAlert(msg, type);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Alert("Success Alert", pwCustomAlertBox.pwCustomAlertBox.TypeAlertBox.Success);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Alert("Warning Alert", pwCustomAlertBox.pwCustomAlertBox.TypeAlertBox.Warning);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.Alert("Error Alert", pwCustomAlertBox.pwCustomAlertBox.TypeAlertBox.Error);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      this.Alert("Info Alert", pwCustomAlertBox.pwCustomAlertBox.TypeAlertBox.Info);
    }
  }
}
