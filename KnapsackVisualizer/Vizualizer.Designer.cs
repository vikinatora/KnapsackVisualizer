namespace KnapsackVisualizer
{
    partial class Vizualizer
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
            this.components = new System.ComponentModel.Container();
            this.startVizualization = new System.Windows.Forms.Button();
            this.vizualizerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vizualizerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vizualizerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vizualizerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // startVizualization
            // 
            this.startVizualization.Location = new System.Drawing.Point(459, 112);
            this.startVizualization.Name = "startVizualization";
            this.startVizualization.Size = new System.Drawing.Size(75, 23);
            this.startVizualization.TabIndex = 0;
            this.startVizualization.Text = "Go!";
            this.startVizualization.UseVisualStyleBackColor = true;
            this.startVizualization.Click += new System.EventHandler(this.startVizualization_Click);
            // 
            // vizualizerBindingSource
            // 
            this.vizualizerBindingSource.DataSource = typeof(KnapsackVisualizer.Vizualizer);
            // 
            // vizualizerBindingSource1
            // 
            this.vizualizerBindingSource1.DataSource = typeof(KnapsackVisualizer.Vizualizer);
            // 
            // Vizualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 573);
            this.Controls.Add(this.startVizualization);
            this.Name = "Vizualizer";
            this.Text = "Vizualizer";
            ((System.ComponentModel.ISupportInitialize)(this.vizualizerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vizualizerBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource vizualizerBindingSource;
        private System.Windows.Forms.BindingSource vizualizerBindingSource1;
        private System.Windows.Forms.Button startVizualization;
    }
}