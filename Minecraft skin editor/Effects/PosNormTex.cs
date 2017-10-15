
using System.Windows.Media;
using  Minecraft_skin_editor.Effects;
using  Minecraft_skin_editor.Models;
using SharpDX;
using SharpDX.D3DCompiler;
using SharpDX.Direct2D1;
using SharpDX.Direct3D10;
using Device1 = SharpDX.Direct3D10.Device1;
using Effect = SharpDX.Direct3D10.Effect;
using Matrix = SharpDX.Matrix;


namespace Minecraft_skin_editor{
    class PosNormTex:IEffect
    {
        public EffectTechnique Technique { get; set; }
        public Effect Effect { get; set; }
        public InputLayout InputLayout { get; set; }
        public void Create(Device1 device)
        {
            var filepath = System.AppDomain.CurrentDomain.BaseDirectory;
            filepath += "\\Resources\\Shaders\\PosNormTex3D.fx";
            var shaderBytecode = ShaderBytecode.CompileFromFile(filepath, "fx_4_0", shaderFlags: ShaderFlags.None);
            Effect = new Effect(device, shaderBytecode);

            Technique = Effect.GetTechniqueByIndex(0);

            var pass = Technique.GetPassByIndex(0);
           // InputLayout = new InputLayout(device, pass.Description.Signature, InputLayouts.PosNormTex);
            InputLayout = new InputLayout(device,pass.Description.Signature,InputLayouts.PosNormColTex);



        }

        public void SetWorld(Matrix world)
        {
            Effect?.GetVariableBySemantic("WORLD").AsMatrix().SetMatrix(world);

        }

        public void SetWorldViewProjection(Matrix wvp)
        {
            Effect?.GetVariableBySemantic("WORLDVIEWPROJECTION").AsMatrix().SetMatrix(wvp);
        }

        public void SetLightDirection(Vector3 dir)
        {
            //Effect?.GetVariableBySemantic("gLightDirection").AsVector().Set(dir);
        }

        public void SetTexture(string path,Device1 device)
        {
            //Texture2D r = Resource.FromFile<Texture2D>(device, path);
            Texture2D fileTexture;

            fileTexture = Texture2D.FromFile<Texture2D>(device, path);
            
          

            ShaderResourceView srv = new ShaderResourceView1(device, fileTexture);
            //fileTexture.FilterTexture();

            Effect?.GetVariableByName("gDiffuseMap").AsShaderResource().SetResource(srv);

        }

    }


}
