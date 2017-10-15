using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assimp;
using  Minecraft_skin_editor.Models;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D10;
using Buffer = SharpDX.Direct3D10.Buffer;

namespace Minecraft_skin_editor.Models
{
    class AssimpModel : IModel
    {
        public AssimpModel(string filename)
        {
            _FileName = filename;
        }

        public string _FileName;
        public PrimitiveTopology PrimitiveTopology { get; set; }
        public int VertexStride { get; set; }
        public int IndexCount { get; set; }
        public Buffer IndexBuffer { get; set; }
        public Buffer VertexBuffer { get; set; }

        public void Create(Device1 device)
        {
            PrimitiveTopology = PrimitiveTopology.TriangleList;
            VertexStride = Marshal.SizeOf<VertexPosColNormTex>();

            var verts = new List<VertexPosColNormTex>();

            var importer = new AssimpContext();
            var s = importer.GetSupportedImportFormats();
            if (!importer.IsImportFormatSupported(Path.GetExtension(_FileName)))
            {
                throw new ArgumentException(
                    "Model format " + Path.GetExtension(_FileName) + " is not supported!  Cannot load {1}", "filename");
            }

            var model = importer.ImportFile(_FileName,
                PostProcessSteps.GenerateSmoothNormals | PostProcessSteps.CalculateTangentSpace | PostProcessSteps.Triangulate);
            foreach (var mesh in model.Meshes)
            {

                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    var pos = new Vector3(mesh.Vertices[i].X, mesh.Vertices[i].Y, mesh.Vertices[i].Z);
                    var color = Color.AliceBlue;
                    var norm = new Vector3(mesh.Normals[i].X, mesh.Normals[i].Y, mesh.Normals[i].Z);
                    var tx = new Vector2(mesh.TextureCoordinateChannels[0][i].X, - mesh.TextureCoordinateChannels[0][i].Y);

                    verts.Add(new VertexPosColNormTex(pos,color, norm, tx));
                }
                var bufferDesc = new BufferDescription
                {
                    Usage = ResourceUsage.Immutable,
                    BindFlags = BindFlags.VertexBuffer,
                    SizeInBytes = VertexStride * verts.Count,
                    CpuAccessFlags = CpuAccessFlags.None,
                    OptionFlags = ResourceOptionFlags.None
                };
                VertexBuffer = new Buffer(device, DataStream.Create(verts.ToArray(), false, false), bufferDesc);

                IndexCount = mesh.GetIndices().Length;
                //buffer creations

                bufferDesc = new BufferDescription
                {
                    Usage = ResourceUsage.Immutable,
                    BindFlags = BindFlags.IndexBuffer,
                    SizeInBytes = sizeof(uint) * IndexCount,
                    CpuAccessFlags = CpuAccessFlags.None,
                    OptionFlags = ResourceOptionFlags.None
                };
                IndexBuffer = new Buffer(device, DataStream.Create(mesh.GetIndices(), false, false), bufferDesc);
            }
        }
    }
}
