using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SGAP.UserControls
{

    public partial class ControlPanel : Panel
    {

        // member variables
        Color mStartColor;
        Color mEndColor;

        public ControlPanel()
        {
            InitializeComponent();
            PaintGradient();
        }
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // GradientPanel
            // 
            ResumeLayout(false);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }


        public Color PageStartColor
        {
            get
            {
                return mStartColor;
            }
            set
            {
                mStartColor = value;
                PaintGradient();
            }
        }


        public Color PageEndColor
        {
            get
            {
                return mEndColor;
            }
            set
            {
                mEndColor = value;
                PaintGradient();
            }
        }


        private void PaintGradient()
        {
            LinearGradientBrush gradBrush;
            gradBrush = new LinearGradientBrush(new Point(0, 0),
            new Point(Width, Height), PageStartColor, PageEndColor);

            Bitmap bmp = new Bitmap(Width, Height);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(gradBrush, new Rectangle(0, 0, Width, Height));
            BackgroundImage = bmp;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

    }
}
