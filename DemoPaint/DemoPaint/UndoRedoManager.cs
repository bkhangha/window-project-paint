using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoPaint
{
    internal abstract class IHanhDong
    {
        public virtual void Undo(Canvas canvas)
        { }

        public virtual void Redo(Canvas canvas)
        { }
    }

    internal class HanhDongThem : IHanhDong
    {
        private UIElement uiElement;

        public HanhDongThem(UIElement uie)
        {
            uiElement = uie;
        }

        public override void Undo(Canvas canvas)
        {
            canvas.Children.Remove(uiElement);
        }

        public override void Redo(Canvas canvas)
        {
            canvas.Children.Add(uiElement);
        }
    }

    internal class HanhDongXoa : IHanhDong
    {
        private UIElement uiElement;

        public HanhDongXoa(UIElement uie)
        {
            uiElement = uie;
        }

        public override void Undo(Canvas canvas)
        {
            canvas.Children.Add(uiElement);
        }

        public override void Redo(Canvas canvas)
        {
            canvas.Children.Remove(uiElement);
        }
    }

    internal class HanhDongChuoi : IHanhDong
    {
        private List<IHanhDong> chuoiHanhDong;

        public HanhDongChuoi(List<IHanhDong> chd)
        {
            chuoiHanhDong = chd;
        }

        public override void Undo(Canvas canvas)
        {
            foreach (IHanhDong hd in chuoiHanhDong)
            {
                hd.Undo(canvas);
            }
        }

        public override void Redo(Canvas canvas)
        {
            foreach (IHanhDong hd in chuoiHanhDong)
            {
                hd.Redo(canvas);
            }
        }
    }

    internal class UndoRedoManager
    {
        private List<IHanhDong> UndoList = new List<IHanhDong>();
        private List<IHanhDong> RedoList = new List<IHanhDong>();

        public void Add(IHanhDong hanhdong)
        {
            UndoList.Add(hanhdong);
            RedoList.Clear();
        }

        public void Undo(Canvas canvas)
        {
            if (UndoList.Count == 0)
            {
                return;
            }
            IHanhDong temp = UndoList.Last();
            UndoList.Remove(temp);
            RedoList.Add(temp);
            temp.Undo(canvas);
        }

        public void Redo(Canvas canvas)
        {
            if (RedoList.Count == 0)
            {
                return;
            }
            IHanhDong temp = RedoList.Last();
            RedoList.Remove(temp);
            UndoList.Add(temp);
            temp.Redo(canvas);
        }
    }
}