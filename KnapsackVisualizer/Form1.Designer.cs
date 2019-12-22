namespace KnapsackVisualizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.itemsInput = new System.Windows.Forms.TextBox();
            this.setItemsButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.bagCapacity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Items";
            // 
            // itemsInput
            // 
            this.itemsInput.Location = new System.Drawing.Point(12, 35);
            this.itemsInput.Name = "itemsInput";
            this.itemsInput.Size = new System.Drawing.Size(60, 22);
            this.itemsInput.TabIndex = 3;
            // 
            // setItemsButton
            // 
            this.setItemsButton.Location = new System.Drawing.Point(12, 64);
            this.setItemsButton.Name = "setItemsButton";
            this.setItemsButton.Size = new System.Drawing.Size(98, 23);
            this.setItemsButton.TabIndex = 4;
            this.setItemsButton.Text = "Set items";
            this.setItemsButton.UseVisualStyleBackColor = true;
            this.setItemsButton.Click += new System.EventHandler(this.setItemsButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(321, 219);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(133, 46);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start visualization!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Visible = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // itemsLabel
            // 
            this.itemsLabel.AllowDrop = true;
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Location = new System.Drawing.Point(141, 123);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(101, 17);
            this.itemsLabel.TabIndex = 6;
            this.itemsLabel.Text = "Value of items:";
            this.itemsLabel.Visible = false;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(141, 161);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(109, 17);
            this.weightLabel.TabIndex = 7;
            this.weightLabel.Text = "Weight of items:";
            this.weightLabel.Visible = false;
            // 
            // bagCapacity
            // 
            this.bagCapacity.Location = new System.Drawing.Point(103, 35);
            this.bagCapacity.Name = "bagCapacity";
            this.bagCapacity.Size = new System.Drawing.Size(65, 22);
            this.bagCapacity.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bag capacity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 277);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bagCapacity);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.itemsLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.setItemsButton);
            this.Controls.Add(this.itemsInput);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemsInput;
        private System.Windows.Forms.Button setItemsButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.TextBox bagCapacity;
        private System.Windows.Forms.Label label4;
    }
}

