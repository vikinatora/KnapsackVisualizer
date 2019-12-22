using KnapsackVisualizer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnapsackVisualizer
{
    public partial class Form1 : Form
    {
        private int itemsStartX;
        private int itemsStartY;
        private int itemsMargin;

        private List<Control> Items { get; set; }
        private List<Control> Weights { get; set; }
        public Form1()
        {
            this.itemsStartX = 200;
            this.itemsStartY = 100;
            this.itemsMargin = 45;
            this.Items = new List<Control>();
            this.Weights = new List<Control>();
            InitializeComponent();

            //Form vizualizer = new Vizualizer(
            //    values: new int[] { 1, 4, 5, 7 },
            //    weights: new int[] { 1, 3, 4, 5 },
            //    bagCapacity: 7
            //);
            //vizualizer.Show();
            //this.Hide();
        }

        private void setItemsButton_Click(object sender, EventArgs e)
        {
            int count = int.Parse(itemsInput.Text);
            if (count >= 0)
            {
                int previousCount = this.Items.Count;
                if(previousCount > 0)
                {
                    for (int i = 0; i < previousCount; i++)
                    {
                        this.Controls.Remove(this.Items[i]);
                        this.Controls.Remove(this.Weights[i]);
                    }
                    this.Weights.Clear();
                    this.Items.Clear();
                }

                for (int i = 0; i < count; i++)
                {
                    Size size = new Size(35, 20);

                    string itemName = $"item{i}";
                    Point itemlocation = new Point(this.itemsStartX + i * this.itemsMargin, itemsStartY);
                    TextBox item = ControlsHelper.CreateTextbox(size, itemlocation, itemName);

                    string weightName = $"weight{i}";
                    Point weightlocation = new Point(this.itemsStartX + i * this.itemsMargin, itemsStartY + 30);
                    TextBox weight = ControlsHelper.CreateTextbox(size, weightlocation, weightName);

                    this.Controls.AddRange(new Control[] { weight, item });
                    this.Items.Add(item);
                    this.Weights.Add(weight);
                }

                if (count > 0)
                {
                    weightLabel.Show();
                    itemsLabel.Show();
                    this.startButton.Show();
                }
                else
                {
                    weightLabel.Hide();
                    itemsLabel.Hide();
                    this.startButton.Hide();
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Add validation for negative numbers
            int[] values = new int[this.Items.Count];
            int[] weights = new int[this.Weights.Count];
            for (int i = 0; i < this.Items.Count; i++)
            {
                values[i] = int.Parse(this.Items[i].Text);
                weights[i] = int.Parse(this.Weights[i].Text);
            }

            //int xBagDim = int.Parse(xBagDimension.Text);
            //int yBagDim = int.Parse(yBagDimension.Text);
            int bagCap = int.Parse(bagCapacity.Text);

            Form vizualizer = new Vizualizer(bagCap, values, weights);
            vizualizer.Show();
            this.Hide();
        }
    }
}
