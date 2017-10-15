using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Minecraft_skin_editor.Effects;
using  Minecraft_skin_editor.Models;
using SharpDX;
using SharpDX.D3DCompiler;
using SharpDX.Direct3D10;

namespace Minecraft_skin_editor.Effects
{
    class PosColNormEffect:IEffect
    {
        public EffectTechnique Technique { get; set; }
        public Effect Effect { get; set; }
        public InputLayout InputLayout { get; set; }
        public void Create(Device1 device)
        {
           var shaderBytecode = ShaderBytecode.CompileFromFile("Resources\\PosNormTex3D.fx", "fx_4_0", shaderFlags:ShaderFlags.None);
            Effect = new Effect(device,shaderBytecode);

            Technique = Effect.GetTechniqueByIndex(0);

            var pass = Technique.GetPassByIndex(0);
            InputLayout = new InputLayout(device, pass.Description.Signature, InputLayouts.PosNormColTex);
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
            Effect?.GetVariableBySemantic("gLightDirection").AsVector().Set(dir);
        }

        public void SetTexture(string path, Device1 device)
        {
            
        }

    }
}
