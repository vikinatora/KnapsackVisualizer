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
        private Control firstComparedSlot;
        private Control secondComparedSlot;
        private RichTextBox tooltip;
        private bool hasReadBriefing;
        private int currentRow;
        private int currentCol;

        public Vizualizer(int bagCapacity, int[] values, int[] weights)
        {
            this.xBagDimension = bagCapacity + 1;
            this.yBagDimension = values.Length + 1;
            this.bagCapacity = bagCapacity;
            this.values = values;
            this.weights = weights;
            this.itemsStartX = 50;
            this.itemsStartY = 50;
            this.itemsMargin = 35;

            this.renderTables();
            this.Width = 500;
            this.Height = 500;
            this.hasReadBriefing = false;
            InitializeComponent();
        }

        public void Visualize(int capacity, int[] weights, int[] values, int itemsCount)
        {
            if (this.currentBagSlot != null)
            {
                this.currentBagSlot.BackColor = SystemColors.Control;
            }
            if (this.firstComparedSlot != null)
            {
                this.firstComparedSlot.BackColor = SystemColors.Control;
            }
            if (this.secondComparedSlot != null)
            {
                this.secondComparedSlot.BackColor = SystemColors.Control;
            }
            if (this.currentRow == 0 || this.currentCol == 0)
            {
                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.BackColor = Color.Red;
                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.Text = 0.ToString();
                this.tooltip.Text = "When either the row or the column is 0, then the value of the items is also 0";
            }
            else if (weights[this.currentRow - 1] <= this.currentCol)
            {
                this.currentItemSlot = ControlsHelper.GetItemSlot(this.currentRow - 1, this.Controls);
                this.currentItemSlot.BackColor = Color.Blue;
                this.currentWeightSlot = ControlsHelper.GetWeightSlot(this.currentRow - 1, this.Controls);
                this.currentWeightSlot.BackColor = Color.Blue;

                //TODO: Implement tooltips. 
                this.firstComparedSlot = ControlsHelper.GetBagSlot(this.currentRow - 1, this.currentCol - weights[this.currentRow - 1], this.Controls);
                this.secondComparedSlot = ControlsHelper.GetBagSlot(this.currentRow - 1, this.currentCol, this.Controls);
                this.firstComparedSlot.BackColor = Color.Blue;
                this.secondComparedSlot.BackColor = Color.Blue;

                int A = values[this.currentRow - 1] + int.Parse(this.firstComparedSlot.Text);
                int B = int.Parse(this.secondComparedSlot.Text);
                int max = Math.Max(A, B);

                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.BackColor = Color.Red;
                this.currentBagSlot.Text = Math.Max(A, B).ToString();
                this.tooltip.Text = $"In this case the weight of the current item is less than or equal to the capacity of the bag. We have to now figure out what is the biggest value of items can we achieve.\r\n" +
                    $"We take the value of the current item and compare it with itself plus the added most valuable item using the remaining capacity of the bag. \r\n" +
                    $"In our case: the current value of the item is {this.currentItemSlot.Text}\r\n" +
                    $"However the combined value of the current item and the one that can fit in the remaining capacity of {this.currentCol - weights[this.currentRow - 1]} is {this.firstComparedSlot.Text}.\r\n" +
                    $"So we put {max} in the table.";
            }
            else
            {
                this.currentBagSlot = ControlsHelper.GetBagSlot(this.currentRow, this.currentCol, this.Controls);
                this.currentBagSlot.BackColor = Color.Red;
                Control bagSlot = ControlsHelper.GetBagSlot(this.currentRow - 1, this.currentCol, this.Controls);
                this.currentBagSlot.Text = bagSlot.Text;
                this.tooltip.Text = $"The current weight of the item is bigger than the capacity of the bag. That's why we have no other choice than to take the value from the previous row ({bagSlot.Text}).";
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
                this.tooltip.Text = $"After iterating over all the possible combinations, the best possible scenario for us is located on the row that matches the number of items the bag can carry ({itemsCount}) and for the column we use the capacity of the bag({capacity}). This means that the best value we can get from the scenario is {currentItemSlot.Text}";
            }
        }
        private void renderTables()
        {
            this.renderKnapsackTable();
            this.renderItems();
            this.itemsStartY += 45;
            this.renderWeights();

            Button startBtn = ControlsHelper.CreateButton(new Size(100, 50), new Point(550, 20), "startVizualization", "Start visualization", new EventHandler(startVizualization_Click));
            RichTextBox tooltip = ControlsHelper.CreateRichTextbox(new Size(400, 150), new Point(this.itemsStartX * this.yBagDimension + 50  + this.itemsMargin * 3, 100), "tooltip", isReadOnly: true);
            this.tooltip = tooltip;
            tooltip.BackColor = Color.White;
            this.Controls.AddRange(new Control[] { startBtn, tooltip });
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
            if(!this.hasReadBriefing)
            {
                this.tooltip.Text = $"You most likely don't understand anything from these tables and you look here for some kind of explanation. That's why I'm here. I'm the tooltip that will help you understand what is happening as the algorithm goes on. \r\n" +
                    $"Let me give you are brief explanation before jumping in to the algorithm. \r\n " +
                    $"The big table to the left is your bag. It was constructed using the values you provided for the capacity of the bag for the rows and  the number of items it can carry for the columns. \r\n" +
                    "Why did I do it? Because one of the algorithms used to solve the problem uses this kind of table and evaluates out biggest value the bag can carry for every pair of  capacity - number of items. \r\n" +
                    "In the end you just have to look at the value that matches your pair and you're ready!" +
                    "The two rows under the big table represent the items and their respective values so you can understand even better what's happening with every step of the algorithm. \r\n." +
                    "Alles klar? Press the button to go to the first step.";
                this.hasReadBriefing = true;
            }
            else
            {
                this.Visualize(bagCapacity, weights, values, values.Length);
            }

        }

    }
}
