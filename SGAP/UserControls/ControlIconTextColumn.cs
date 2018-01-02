using System.Drawing;
using System.Windows.Forms;

namespace SGAP.UserControls
{
    public class ControlIconTextColumn : DataGridViewTextBoxColumn
    {
        private Image imageValue;
        private Size imageSize;

        public ControlIconTextColumn()
        {
            CellTemplate = new TextAndImageCell();
        }

        public override object Clone()
        {
            ControlIconTextColumn c = base.Clone() as ControlIconTextColumn;
            c.imageValue = imageValue;
            c.imageSize = imageSize;
            return c;
        }

        public Image Image
        {
            get { return this.imageValue; }
            set
            {
                if (Image != value)
                {
                    imageValue = value;
                    imageSize = value.Size;

                    if (InheritedStyle != null)
                    {
                        Padding inheritedPadding = InheritedStyle.Padding;
                        DefaultCellStyle.Padding = new Padding(imageSize.Width,
                     inheritedPadding.Top, inheritedPadding.Right,
                     inheritedPadding.Bottom);
                    }
                }
            }
        }
        private TextAndImageCell TextAndImageCellTemplate
        {
            get { return CellTemplate as TextAndImageCell; }
        }
        internal Size ImageSize
        {
            get { return imageSize; }
        }
    }

    public class TextAndImageCell : DataGridViewTextBoxCell
    {
        private Image imageValue;
        private Size imageSize;

        public override object Clone()
        {
            TextAndImageCell c = base.Clone() as TextAndImageCell;
            c.imageValue = imageValue;
            c.imageSize = imageSize;
            return c;
        }

        public Image Image
        {
            get
            {
                if (OwningColumn == null ||  OwningTextAndImageColumn == null)
                {

                    return imageValue;
                }
                else if (imageValue != null)
                {
                    return imageValue;
                }
                else
                {
                    return OwningTextAndImageColumn.Image;
                }
            }
            set
            {
                if (imageValue != value)
                {
                    imageValue = value;
                    imageSize = value.Size;

                    Padding inheritedPadding = InheritedStyle.Padding;
                    Style.Padding = new Padding(imageSize.Width,
                    inheritedPadding.Top, inheritedPadding.Right,
                    inheritedPadding.Bottom);
                }
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds,
        Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
        object value, object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
               value, formattedValue, errorText, cellStyle,
               advancedBorderStyle, paintParts);

            if (Image != null)
            {
                System.Drawing.Drawing2D.GraphicsContainer container =
                graphics.BeginContainer();

                graphics.SetClip(cellBounds);
                graphics.DrawImageUnscaled(Image, cellBounds.Location);

                graphics.EndContainer(container);
            }
        }

        private ControlIconTextColumn OwningTextAndImageColumn
        {
            get { return OwningColumn as ControlIconTextColumn; }
        }
    }
}
