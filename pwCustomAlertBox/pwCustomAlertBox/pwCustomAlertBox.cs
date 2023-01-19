using pwCustomAlertBox.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pwCustomAlertBox
{
  public partial class pwCustomAlertBox : Form
  {
    private enum enmAction
    {
      wait,
      start,
      close
    }

    public enum TypeAlertBox
    {
      Success,
      Warning,
      Error,
      Info
    }
    private enmAction action;

    private int x, y;

    /// <summary>
    /// Timer used to close the AlertBox
    /// </summary>
    public int TimerValue { get; set; } = 5000;

    public pwCustomAlertBox()
    {
      InitializeComponent();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      switch (this.action)
      {
        case enmAction.wait:
          timer1.Interval = this.TimerValue;
          action = enmAction.close;
          break;
        case enmAction.start:
          this.timer1.Interval = 1;
          this.Opacity += 0.1;
          if (this.x < this.Location.X)
          {
            this.Left--;
          }
          else
          {
            if (this.Opacity == 1.0)
            {
              action = enmAction.wait;
            }
          }
          break;
        case enmAction.close:
          timer1.Interval = 1;
          this.Opacity -= 0.1;

          this.Left -= 3;
          if (base.Opacity == 0.0)
          {
            base.Close();
          }
          break;
      }
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      timer1.Interval = 1;
      action = enmAction.close;
    }

    public void showAlert(string msg, TypeAlertBox type)
    {
      this.Opacity = 0.0;
      this.StartPosition = FormStartPosition.Manual;
      string fname;

      for (int i = 1; i < 10; i++)
      {
        fname = "alert" + i.ToString();
        pwCustomAlertBox frm = (pwCustomAlertBox)Application.OpenForms[fname];

        if (frm == null)
        {
          this.Name = fname;
          this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
          this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
          this.Location = new Point(this.x, this.y);
          break;

        }

      }
      this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

      switch (type)
      {
        case TypeAlertBox.Success:
          this.pictureBox1.Image = Resources.success;
          this.BackColor = Color.SeaGreen;
          break;
        case TypeAlertBox.Error:
          this.pictureBox1.Image = Resources.error;
          this.BackColor = Color.DarkRed;
          break;
        case TypeAlertBox.Info:
          this.pictureBox1.Image = Resources.info;
          this.BackColor = Color.RoyalBlue;
          break;
        case TypeAlertBox.Warning:
          this.pictureBox1.Image = Resources.warning;
          this.BackColor = Color.DarkOrange;
          break;
      }


      this.lblMsg.Text = msg;

      this.Show();
      this.action = enmAction.start;
      this.timer1.Interval = 1;
      this.timer1.Start();
    }

  }
}
