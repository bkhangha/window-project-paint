using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace DemoPaint
{
    internal class DoActionEventArgs
    {
        public IHanhDong hanhdong;
    }

    internal delegate void DoActionHandler(object sender, DoActionEventArgs e);

    internal class VeAbstract
    {
        public event DoActionHandler ActionCreated;

        protected Point? startPoint;
        protected Adorner currAdnr;

        protected AdornerLayer adnrLayer;
        protected Canvas MyCanvas;
        protected ThuocTinhVe thuocTinhVe;

        public void NotifyActionCreated(IHanhDong hd)
        {
            if (ActionCreated != null)
            {
                ActionCreated(this, new DoActionEventArgs() { hanhdong = hd });
            }
        }

        public VeAbstract(Canvas canvas, ThuocTinhVe ttv)
        {
            MyCanvas = canvas;
            adnrLayer = AdornerLayer.GetAdornerLayer(canvas);
            thuocTinhVe = ttv;
        }

        public virtual void XuLiMouseDown()
        {
            startPoint = Mouse.GetPosition(MyCanvas);
        }

        public virtual void XuLiMouseMove()
        { }

        public virtual void XuLiMouseUp()
        {
            startPoint = null;
        }

        public virtual void Cut()
        { }

        public virtual void Copy()
        { }

        public virtual void Paste()
        { }

        public virtual void Delete()
        { }
    }
}