using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Minecraft_skin_editor.Annotations;
using Minecraft_skin_editor.Commands;
using SharpDX.Direct2D1;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using DirectxImageControl;
using Bitmap = System.Drawing.Bitmap;
using Brush = System.Windows.Media.Brush;
using Image = System.Windows.Controls.Image;
using ImageSource = System.Windows.Media.ImageSource;


namespace Minecraft_skin_editor.ViewModels
{
    public class ViewModel: INotifyPropertyChanged
    {


        //init
        public ViewModel()
        {
            _brushColorPick = Colors.MediumSeaGreen;
        }

        private UndoRedoStack<Bitmap> _undoRedoBitmap = new UndoRedoStack<Bitmap>();

        public UndoRedoStack<Bitmap> UndoRedoBitmap
        {
            get { return _undoRedoBitmap; }
            set { _undoRedoBitmap = value; }
        }

        //3d model viewport 
        private IDX10Viewport _viewport = new DX10Viewport();
        public IDX10Viewport Viewport
        {
            get { return _viewport; }
            set { _viewport = value; }
        }

        //namen lijst voor aftehalen van url
        private BindingList<ListBoxItem> _namesDownloaded = new BindingList<ListBoxItem>();
        public BindingList<ListBoxItem> NamesDownloaded
        {
            get
            {
                return _namesDownloaded;

            }
            set
            {
                
                _namesDownloaded = value;
                OnPropertyChanged("NamesDownloaded");

            }
        }

        //painte met brush
        private bool _enabledBrush;
        public bool EnabledBrush
        {
            get { return _enabledBrush; }
            set { _enabledBrush = value; }
        }
        //skin bitmap die op het model staat
        private Bitmap _skin ;
        public Bitmap Skin
        {
            get { return _skin; }
            set
            {
                _skin = value;
                OnPropertyChanged("Skin");
                
            }
        }
         //skin image dat je ziet in de view
        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
                _skin.Save("LocalTexture.png");
                var v = _viewport as DX10Viewport;
                v.Shader.SetTexture("LocalTexture.png", v.Device2);
            }
        }

        //text van textbox voor online skin af te halen
        private string _nameOfSkin = "";
        public string NameOfSkin
        {
            get { return _nameOfSkin; }
            set
            {
                _nameOfSkin = value;
                OnPropertyChanged("NameOfSkin");

            }
        }
        //selected item
        private ListBoxItem _selecteListItem;

        public ListBoxItem SelecteListItem
        {
            get { return _selecteListItem; }
            set
            {
                _selecteListItem = value;
                OnPropertyChanged("SelecteListItem");
            }
        }

        //colors
        private System.Windows.Media.Color _brushColorPick ;
        public System.Windows.Media.Color BrushColorPick
        {
            get { return _brushColorPick; }
            set
            {
                _brushColorPick = value;
                OnPropertyChanged("BrushColorPick");
            }
        }

        private bool _setColorPicker;
        public bool SetColorPicker
        {
            get
            {
                return _setColorPicker;
            }
            set
            {
                _setColorPicker = value;
                OnPropertyChanged("SetColorPicker");
            }
        }

        //bool mousemove
        private bool _isMouseDown = false;
        public bool IsMouseDown
        {
            get { return _isMouseDown; }
            set
            {
                _isMouseDown = value;
                OnPropertyChanged("IsMouseDown");
            }
        }
        //bool use Pen
        private bool _usePen;
        public bool UsePen
        {
            get { return _usePen; }
            set
            {
                _usePen = value;
                OnPropertyChanged("IsMouseDown");
            }
        }

        //commands
        public BrushCommand BrushCommand { get; set; } = new BrushCommand();
        public EraserCommand EraserCommand { get; set; } = new EraserCommand();
        public PaintCommand PaintCommand { get; set; } = new PaintCommand();
        public EmptyCommand EmptyCommand { get; set; } = new EmptyCommand();
        public AddSkinToList AddSkinToList { get; set; } = new AddSkinToList();

        public ApplyTextureToSkin ApplyTextureToSkin { get; set; } = new ApplyTextureToSkin();

        public DeleteSkinFromList DeleteSkinFromList { get; set; } = new DeleteSkinFromList();
        public UndoCommand UndoCommand { get; set; } = new UndoCommand();
        public RedoCommand RedoCommand { get; set; } = new RedoCommand();

        public LeftTurn LeftTurn { get; set; } = new LeftTurn();
        public RightTurn RightTurn { get; set; } = new RightTurn();
        public Up Up { get; set; } = new Up();
        public Down Down { get; set; } = new Down();
        public AutoTurn AutoTurn { get; set; } = new AutoTurn();
        public SaveNamesCommand SaveNamesCommand { get; set; } = new SaveNamesCommand();
        public LoadNamesCommand LoadNamesCommand { get; set; } = new LoadNamesCommand();
        public RandomColorCommand RandomColorCommand { get; set; } = new RandomColorCommand();
        public SaveSkinCommand SaveSkinCommand { get; set; } = new SaveSkinCommand();
        public LoadSkinCommand LoadSkinCommand { get; set; } = new LoadSkinCommand();
        public PenPixelDownCommand PenPixelDownCommand { get; set; } = new PenPixelDownCommand();

        public ButtonColorPickerCommand ButtonColorPickerCommand { get; set; } = new ButtonColorPickerCommand();
        public PaintMoveCommand PaintMoveCommand { get; set; } = new PaintMoveCommand();

        public MouseUpCommand MouseUpCommand { get; set; } = new MouseUpCommand();

       


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
