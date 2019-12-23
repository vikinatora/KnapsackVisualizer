using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnapsackVisualizer.Helpers
{
    public static class ControlsHelper
    {

        public static TextBox CreateTextbox(Size size, Point location, string name, string value = "", HorizontalAlignment textAlign = HorizontalAlignment.Left, bool isReadOnly = false)
        {
            TextBox textBox = new TextBox();
            textBox.Size = size;
            textBox.Location = location;
            textBox.Name = name;
            textBox.Text = value;  
            textBox.TextAlign = textAlign;
            textBox.ReadOnly = isReadOnly;

            return textBox;
        }

        public static RichTextBox CreateRichTextbox(Size size, Point location, string name, string value = "", bool isReadOnly = false)
        {
            RichTextBox textBox = new RichTextBox();
            textBox.Size = size;
            textBox.Location = location;
            textBox.Name = name;
            textBox.Text = value;
            textBox.ReadOnly = isReadOnly;

            return textBox;
        }

        public static Label CreateLabel(Size size, Point location, string name, string value = "", ContentAlignment textAlign = ContentAlignment.MiddleLeft)
        {
            Label label = new Label();
            label.Size = size;
            label.Location = location;
            label.Name = name;
            label.Text = value;
            label.TextAlign = textAlign;

            return label;
        }

        public static Button CreateButton(Size size, Point location, string name, string text, EventHandler eventHandler)
        {
            Button button = new Button();
            button.Size = size;
            button.Name = name;
            button.Text = text;
            button.Location = location;
            button.Click += eventHandler;
            return button;
        }

        public static Control GetBagSlot(int row, int col, Control.ControlCollection controls)
        {
            Control slot = controls.Find($"tableItem{col}x{row}",false)[0];
            return slot;
        }

        internal static Control GetItemSlot(int itemIndex, Control.ControlCollection controls)
        {
            Control slot = controls.Find($"item{itemIndex}", false)[0];
            return slot;

        }

        internal static Control GetWeightSlot(int weightIndex, Control.ControlCollection controls)
        {
            Control slot = controls.Find($"weight{weightIndex}", false)[0];
            return slot;

        }
    }
}
