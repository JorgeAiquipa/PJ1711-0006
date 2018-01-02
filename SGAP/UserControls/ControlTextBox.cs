using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGAP.UserControls
{
    public enum ContAlignment
    {
        Left = ContentAlignment.TopLeft,
        Right = ContentAlignment.TopRight
    }

    public class ControlTextBox : TextBox
    {


        private Rectangle textBorder;
        private string placeholder;
        private Size placeholderTextSize;
        private Point placeholderPosition;
        public string PlaceHolderText
        {
            get { return placeholder; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    placeholder = "Search";
                }
                else
                    placeholder = value;
                placeholderTextSize = TextRenderer.MeasureText(placeholder, Font);
                this.Invalidate();
            }

        }
        private Color placeholdercolor;
        public Color PlaceHolderColor
        {
            get { return placeholdercolor; }
            set
            {
                placeholdercolor = value;
                Invalidate();
            }
        }

        private Image placeholdericon;

        public Image PlaceHolderIcon
        {
            get { return placeholdericon; }
            set
            {
                placeholdericon = value;
                Invalidate();
            }
        }
        private ContAlignment iconAlignment;

        public ContAlignment PlaceHolderIconAlignment
        {
            get { return iconAlignment; }
            set
            {
                iconAlignment = value;
                if (iconAlignment == ContAlignment.Left)
                {
                    placeholderPosition.X = placeholderTextSize.Height;
                    placeholderPosition.Y = 0;
                }
                if (iconAlignment == ContAlignment.Right)
                {
                    placeholderPosition.X = placeholderTextSize.Width + 2;
                    placeholderPosition.Y = 0;
                }
                Invalidate();
            }
        }


        public ControlTextBox()
        {

            PlaceHolderText = "Search";
            placeholdercolor = Color.DarkGray;
            PlaceHolderIcon = Properties.Resources.buscar;
            PlaceHolderIconAlignment = ContAlignment.Right;
            FontChanged += ControlTextBox_FontChanged;
        }

        private void ControlTextBox_FontChanged(object sender, EventArgs e)
        {
            placeholderTextSize = TextRenderer.MeasureText(placeholder, Font);
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (Text.Length > 0)
                base.SetStyle(ControlStyles.UserPaint, false);
            else
            {
                base.SetStyle(ControlStyles.UserPaint, true);

            }
            this.UpdateStyles();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            textBorder = this.DisplayRectangle;
            base.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Text.Length == 0)
            {
                if (placeholdericon != null)
                {
                    switch (iconAlignment)
                    {
                        case ContAlignment.Right:
                            {
                                e.Graphics.DrawImage(placeholdericon, placeholderPosition.X, placeholderPosition.Y, placeholderTextSize.Height, placeholderTextSize.Height);
                                TextRenderer.DrawText(e.Graphics, placeholder, Font, textBorder, placeholdercolor, TextFormatFlags.Left);
                                break;
                            }
                        case ContAlignment.Left:
                            {
                                e.Graphics.DrawImage(placeholdericon, placeholderPosition.X - placeholderTextSize.Height, 0, placeholderTextSize.Height, placeholderTextSize.Height);
                                TextRenderer.DrawText(e.Graphics, placeholder, Font, placeholderPosition, placeholdercolor, TextFormatFlags.Left);
                                break;
                            }
                    }
                }

            }
        }
    }
}
