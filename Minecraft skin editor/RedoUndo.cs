using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace Minecraft_skin_editor
{
    //public class URTracker<T>
    //{
    //    public Func<T> Get;
    //    public Action<T> Set;
    //    public URTracker(Func<T> @get, Action<T> @set, T value, int batchSize = 1)
    //    {
    //        Get = @get;
    //        Set = @set;
    //        MyValue = value;
    //        BatchSize = batchSize;
    //    }

    //    public T Value
    //    {
    //        get { return Get(); }
    //        set { Set(value); }
    //    }
    //    public T MyValue;
    //    public int BatchSize;
    //}
    public class UndoRedoStack<T>
    {
        private static Stack<Bitmap> _undoStack = new Stack<Bitmap>();
        private static Stack<Bitmap> _redoStack = new Stack<Bitmap>();

        public static bool BusyUndo = false;
        public void Add(Bitmap bmp)
        {
            _undoStack.Push(bmp);
            _redoStack.Clear();
        }

        public void ResetUndo(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                _undoStack.Pop();
            }
        }

        public Bitmap Undo()
        {
            if (_undoStack.Count <= 0)
                return null;
            BusyUndo = true;
            Bitmap bmp = _undoStack.Pop();
            _redoStack.Push(new Bitmap(bmp));
            //ExecuteTracker(ref cmd);
            BusyUndo = false;
            if (_undoStack.Count <= 0)
                return null;
            return _undoStack.Peek();


        }

        public Bitmap Redo()
        {
            if (_redoStack.Count <= 0)
                return null;
            var b = _redoStack.Pop();
            _undoStack.Push(b);
            return b;

        }

        //private void ExecuteTracker(ref Bitmap cmd)
        //{
        //    cmd.Value = cmd.MyValue;
        //}

        public void Reset()
        {
            _undoStack = new Stack<Bitmap>();
            _redoStack = new Stack<Bitmap>();
        }
    }
}