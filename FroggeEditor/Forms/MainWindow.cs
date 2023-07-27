using System;
using System.Drawing;
using System.Windows.Forms;

namespace FroggeEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            Text = "Frogge Editor";
            Size = new Size(1280, 720);
            
            Button button = new Button();
            button.Text = "Test Click";
            button.Location = new Point(10, 10);

            button.Click += (sender, a) =>
            {
                MessageBox.Show("Button Clicked!");
            };
            
            Controls.Add(button);
        }
    }
}
