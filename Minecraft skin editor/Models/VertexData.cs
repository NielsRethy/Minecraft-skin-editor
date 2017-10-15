using SharpDX;
using SharpDX.Direct3D10;
using SharpDX.DXGI;

namespace Minecraft_skin_editor.Models
{
    public struct VertexPosColNormTex
    {
        public Vector3 Position;
        public Vector4 Color;
        public Vector3 Normal;
        public Vector2 TexCoord;

        public VertexPosColNormTex(Vector3 pos, Color col, Vector3 norm, Vector2 tx)
        {
            Position = pos;
            Color = col.ToVector4();
            Normal = norm;
            TexCoord = tx;
        }
    }

    public static class InputLayouts
    {
        //public static readonly InputElement[] PosNormCol = {
        //    new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0, InputClassification.PerVertexData, 0),
        //    new InputElement("COLOR", 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0),
        //    new InputElement("NORMAL", 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0)
        //};
        //public static readonly InputElement[] PosNormTex = {
        //    new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0, InputClassification.PerVertexData, 0),
        //    new InputElement("NORMAL", 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0),
        //    new InputElement("TEXCOORD", 0, Format.R32G32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0)
        //};
            public static readonly InputElement[] PosNormColTex = new InputElement[4] {
                   new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0, InputClassification.PerVertexData, 0),
                    new InputElement("NORMAL", 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0),
                    new InputElement("COLOR", 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0),
                new InputElement("TEXCOORD", 0, Format.R32G32_Float, InputElement.AppendAligned, 0, InputClassification.PerVertexData, 0) };
    }
}
