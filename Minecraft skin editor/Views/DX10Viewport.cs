using System.Windows;
using Minecraft_skin_editor.Models;
using DirectxImageControl;
using Microsoft.VisualBasic.Devices;
using Minecraft_skin_editor.Effects;
using SharpDX;
using SharpDX.Direct3D10;
using Format = SharpDX.DXGI.Format;

namespace Minecraft_skin_editor
{
    public class DX10Viewport : IDX10Viewport
    {
        private Device1 _device;
        private RenderTargetView _renderTargetView;
        private DX10RenderCanvas _renderControl;

        public IModel Model { get; set; }
        public IEffect Shader { get; set; }


        private float _turndegrees = 22.5f;
        public float Turndegrees
        {
            get { return _turndegrees; }
            set { _turndegrees = value; }
        }

        private bool _turnOnce = false;
        public bool TurnOnce
        {
            get { return _turnOnce; }
            set { _turnOnce = value; }
        }
        private bool _autoTurn;
        public bool AutoTurn
        {
            get { return _autoTurn; }
            set { _autoTurn = value; }
        }

        private bool _xAss = false;
        public bool XAss
        {
            get { return _xAss; }
            set { _xAss = value; }
        }
        public Device1 Device2
        {
            get { return _device; }
            set { _device = value; }
        }



        private float _modelRotationY;
        private float _modelRotationX;

        public void Initialize(Device1 device, RenderTargetView renderTarget, DX10RenderCanvas canvasControl)
        {
            _device = device;
            _renderTargetView = renderTarget;
            _renderControl = canvasControl;


            //Set Model (IModel)
            // Model = new BoxModel();
            //Model.Create(_device);
            var filepath = System.AppDomain.CurrentDomain.BaseDirectory;
            filepath += "\\Resources\\Model\\MinecraftModel.obj";
            Model = new AssimpModel(filepath);
            Model.Create(_device);
            //Set Shader (IEffect)
            Shader = new PosNormTex();
            Shader.Create(device);
            //Shader.SetTexture("C:\\Users\\NielsR\\Documents\\DAE 2016-2017\\TOOL DEVELOPMENT\\Week_11_-_DirectX_Image_Control\\d\\DirextXFirstProject\\ Minecraft_skin_editor\\scichart-surface-mesh-8x8-3d-300x187.png", _device);
        }

        public void Deinitialize()
        {
            
        }

        public void Update(float deltaT)
        {
            if (Model != null && Shader != null)
            {

                var worldMat = Matrix.Identity;
               
                worldMat *= Matrix.Scaling(2.0f);
                if (_turnOnce)
                {
                    if (_xAss)
                    {
                        _modelRotationX += _turndegrees;
                        _xAss = false;
                    }
                    else
                    {
                        _modelRotationY += _turndegrees;
                    }
                    _turnOnce = false;

                }
                if (_autoTurn)
                {
                    _modelRotationY += MathUtil.PiOverFour * deltaT;
                    //worldMat *= Matrix.RotationY(_modelRotation);
                }
                
                worldMat *= Matrix.RotationY(_modelRotationY);
                worldMat *= Matrix.RotationX(_modelRotationX);


                worldMat *= Matrix.Translation(0.0f, 0.0f, 0.0f);

               var viewMat = Matrix.LookAtLH(new Vector3(0, 10, -25), Vector3.Zero, Vector3.UnitY);
                var projMat = Matrix.PerspectiveFovLH(MathUtil.PiOverFour, (float)_renderControl.ActualWidth / (float)_renderControl.ActualHeight, 0.1f, 1000f);

                Shader.SetWorld(worldMat);
                Shader.SetWorldViewProjection(worldMat*viewMat*projMat);
               

            }
        }

        public void Render(float deltaT)
        {
            if (_device == null)
                return;

            if (Model != null && Shader != null)
            {
                _device.InputAssembler.InputLayout = Shader.InputLayout;
                _device.InputAssembler.PrimitiveTopology = Model.PrimitiveTopology;
                _device.InputAssembler.SetIndexBuffer(Model.IndexBuffer, Format.R32_UInt, 0);
                _device.InputAssembler.SetVertexBuffers(0,
                    new VertexBufferBinding(Model.VertexBuffer, Model.VertexStride, 0));

                for (int i = 0; i < Shader.Technique.Description.PassCount; ++i)
                {
                    Shader.Technique.GetPassByIndex(i).Apply();
                    _device.DrawIndexed(Model.IndexCount, 0, 0);
                }

            }
        }
    }
}
