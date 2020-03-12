using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLearningTest.NetworkCreator;
using QLearningTest.ImageClassifier;

namespace QLearningTest
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(listBox1.SelectedItem);
            Form child = null;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    child = new NetworkCreatorPresentation();
                    break;
                case 1:
                    //child = new BooleanSolverPresentation();
                    break;
                case 2:
                    child = new ImageClassifierPresentation();
                    break;
            }

            if (child == null)
            {
                Close();
                return;
            }

            Hide();
            child.Show();
            child.Disposed += (p1, p2) => Close();
        }
    }
}
