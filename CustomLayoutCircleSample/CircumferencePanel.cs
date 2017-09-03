using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomLayoutCircleSample
{
   public  class CircumferencePanel :  Panel
    {
        public Thickness Padding { get; set; }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach(UIElement elem in Children)
            {
                elem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            }
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0) return finalSize;
            double currentAngle = 90 * (Math.PI / 180);
            double radiansPerElement = (360 / Children.Count) * (Math.PI / 180.0);
            double radiusX = finalSize.Width / 2.0 - Padding.Left;
            double radiusY = finalSize.Height / 2.0 - Padding.Top;
            foreach (UIElement elem in Children)
            {
                Point childPoint = new Point(Math.Cos(currentAngle) * radiusX, -Math.Sin(currentAngle) * radiusY);
                Point centerdChildPoint = new Point(
                    childPoint.X + finalSize.Width / 2 - elem.DesiredSize.Width / 2,
                    childPoint.Y + finalSize.Height / 2 - elem.DesiredSize.Height / 2);
                Rect boundingBox = new Rect(centerdChildPoint, elem.DesiredSize);
                elem.Arrange(boundingBox);
                currentAngle -= radiansPerElement;
            }
            return finalSize;
        }
    }
}
