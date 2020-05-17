using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortressWar.MessageBox
{
    public partial class GameEndMsgBox : Form
    {
        public GameEndMsgBox()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(255, 86, 48, 32);
        }

        static GameEndMsgBox MsgBox;
        static DialogResult result = DialogResult.No;
        public static DialogResult Show(string text)
        {
            MsgBox = new GameEndMsgBox();
            MsgBox.label2.Text = text;
            MsgBox.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            MsgBox.Close();
        }
    }
}
