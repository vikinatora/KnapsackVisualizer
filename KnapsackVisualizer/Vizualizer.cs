using KnapsackVisualizer.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KnapsackVisualizer
{
    public partial class Vizualizer : Form
    {
        private int xBagDimension;
        private int yBagDimension;
        private int bagCapacity;
        private int[] values;
        private int[] weights;
        private int itemsStartX;
        private int itemsStartY;
        private int itemsMargin;
        private Control currentBagSlot;
        private Control currentItemSlot;
        private Control currentWeightSlot;
        private int currentRow;
        private int currentCol;
        private int[,] bag;

        public Vizualizer(int bagCapacity, int[] values, int[] weights)
        {
            this.xBagDimension = bagCapacity + 1;
            this.yBagDimension = values.Length + 1;
            this.bag = new int[this.yBagDimension, this.xBagDimension];
            this.bagCapacity = bagCapacity;
            this.values = values;
            this.weights = weights;
            this.itemsStartX = 50;
            this.itemsStartY = 50;
            this.itemsMargin = 35;

            this.renderTables();
            this.Width = 500;
            this.Height = 500;

            InitializeComponent();
        }

        public void Visualize(int capacity, int[] weights, int[] values, int itemsCount)
        {
            if (this.currentBagSlot != null)
            {
                this.currentBagSlot.BackColor = SystemColors.Control;
            }
            if (this.currentRow == 0 || this.currentCol == 0)
            {
                //Here we go through the first row, where everything is 0
                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.BackColor = Color.Red;
                this.bag[this.currentRow, this.currentCol] = 0;
            }
            else if (weights[this.currentRow - 1] <= this.currentCol)
            {
                this.currentItemSlot = ControlsHelper.GetItemSlot(this.currentRow - 1, this.Controls);
                this.currentItemSlot.BackColor = Color.Blue;
                this.currentWeightSlot = ControlsHelper.GetWeightSlot(this.currentRow - 1, this.Controls);
                this.currentWeightSlot.BackColor = Color.Blue;

                //TODO: Track A and B slots. Implement tooltips. 
                int A = values[this.currentRow - 1] + this.bag[this.currentRow - 1, this.currentCol - weights[this.currentRow - 1]];
                int B = this.bag[this.currentRow - 1, this.currentCol];
                int max = Math.Max(A, B);

                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.BackColor = Color.Red;
                this.currentBagSlot.Text = Math.Max(A, B).ToString();
                this.bag[this.currentRow, this.currentCol] = Math.Max(A, B);
            }
            else
            {
                //Here we leave the current item from our collection
                this.bag[this.currentRow, this.currentCol] = this.bag[this.currentRow - 1, this.currentCol];
                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.BackColor = Color.Red;
                this.currentBagSlot.Text = this.bag[this.currentRow, this.currentCol].ToString();
            }

            if (this.currentCol < capacity)
            {
                this.currentCol++;
            } else if(this.currentCol == capacity  && this.currentRow < itemsCount)
            {
                if (this.currentItemSlot != null)
                {
                    this.currentItemSlot.BackColor = SystemColors.Control;
                }
                if (this.currentWeightSlot != null)
                {
                    this.currentWeightSlot.BackColor = SystemColors.Control;
                }

                this.currentRow++;
                this.currentCol = 0;
            } else if(this.currentCol == capacity  && this.currentRow == itemsCount)
            {
                this.currentItemSlot = ControlsHelper.GetBagSlot(itemsCount, capacity, this.Controls);
                this.currentItemSlot.BackColor = Color.Green;
                Console.WriteLine($"Best value we can get is: {this.bag[itemsCount, capacity]}");
            }
        }
        private void renderTables()
        {
            this.renderKnapsackTable();
            this.renderItems();
            this.itemsStartY += 45;
            this.renderWeights();

            var startBtn = new Button();
            startBtn.Name = "startVizualization";
            startBtn.Location = new Point(300, 300);
            startBtn.Click += new EventHandler(startVizualization_Click);
            startBtn.Visible = true;

        }

        private void renderWeights()
        {
            for (int i = 0; i < this.weights.Length; i++)
            {
                Point location = new Point(this.itemsStartX + i * this.itemsMargin, this.itemsStartY + 20);
                Size size = new Size(20, 20);
                string name = $"weight{i}";
                string text = $"{this.weights[i]}";

                TextBox item = ControlsHelper.CreateTextbox(size, location, name, text, HorizontalAlignment.Center, true);
                this.Controls.Add(item);
            }
        }

        private void renderKnapsackTable()
        {
            this.renderItemLabels();
            for (int row = 0; row < yBagDimension; row++)
            {
                for (int column = 0; column < xBagDimension; column++)
                {
                    Point location = new Point(this.itemsStartX + column * this.itemsMargin, this.itemsStartY);
                    Size size = new Size(20, 20);
                    string name = $"tableItem{column}x{row}";
                    Console.WriteLine(name);
                    string text = "0";
                    TextBox item = ControlsHelper.CreateTextbox(size, location, name, text, HorizontalAlignment.Center, true);
                    this.Controls.Add(item);
                }

                this.itemsStartY += 45;
            }
        }

        private void renderItems()
        {
            for (int row = 0; row < this.values.Length; row++)
            {
                Point location = new Point(this.itemsStartX + row * this.itemsMargin, this.itemsStartY + 20);
                Size size = new Size(20, 20);
                string name = $"item{row}";
                string text = $"{this.values[row]}";
                TextBox item = ControlsHelper.CreateTextbox(size, location, name, text, HorizontalAlignment.Center, true);
                this.Controls.Add(item);
            }
        }

        private void renderItemLabels()
        {
            //Maybe a better way would be to capture the location center of the first row/column elements and use that as an anchor?
            for (int i = 0; i < xBagDimension; i++)
            {
                Label item = new Label();
                item.Size = new Size(20, 20);
                item.Location = new Point(this.itemsStartX + item.Size.Width / 4 + i * this.itemsMargin, this.itemsStartY - 30);
                item.Name = $"labelx{i}";
                item.Text = i.ToString();
                this.Controls.Add(item);
            }
            for (int i = 0; i < yBagDimension; i++)
            {
                Label item = new Label();
                item.Size = new Size(35, 20);
                item.Location = new Point(this.itemsStartX - item.Size.Width, this.itemsStartY + i * 45);
                item.Name = $"labelx{i}";
                item.Text = i.ToString();
                this.Controls.Add(item);

            }
        }

        private void startVizualization_Click(object sender, EventArgs e)
        {
            this.Visualize(bagCapacity, weights, values, values.Length);
        }
    }
}
