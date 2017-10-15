//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using  Minecraft_skin_editor.Models;
//using SharpDX;
//using SharpDX.Direct3D;
//using SharpDX.Direct3D10;
//using Buffer = SharpDX.Direct3D10.Buffer;

//namespace  Minecraft_skin_editor.Models
//{
//    class BoxModel : IModel
//    {
//        public PrimitiveTopology PrimitiveTopology { get; set; }
//        public int VertexStride { get; set; }
//        public int IndexCount { get; set; }
//        public Buffer IndexBuffer { get; set; }
//        public Buffer VertexBuffer { get; set; }

//        public void Create(Device1 device)
//        {

//            //PrimitiveTopology = PrimitiveTopology.TriangleList;
//            //VertexStride = Marshal.SizeOf<VertexPosColNorm>();

//            //// VertexBuffer

//            //var verts = new List<VertexPosColNorm>();

//            //Color col = Color.Red;
//            //Vector3 norm = new Vector3(0, 0, -1);
//            ////FRONT RED
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, -0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, 0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, -0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, 0.5f, -0.5f), col, norm));

//            ////BACK RED
//            //norm = new Vector3(0, 0, 1);
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, -0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, 0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, -0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, 0.5f, 0.5f), col, norm));

//            ////LEFT GREEN
//            //col = Color.Green;
//            //norm = new Vector3(-1, 0, 0);
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, -0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, 0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, -0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, 0.5f, 0.5f), col, norm));

//            ////RIGHT GREEN
//            //norm = new Vector3(1, 0, 0);
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, -0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, 0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, -0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, 0.5f, 0.5f), col, norm));

//            ////TOP BLUE
//            //col = Color.Blue;
//            //norm = new Vector3(0, 1, 0);
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, 0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, 0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, 0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, 0.5f, -0.5f), col, norm));

//            ////BOTTOM BLUE
//            //norm = new Vector3(0, -1, 0);
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, -0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(-0.5f, -0.5f, -0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, -0.5f, 0.5f), col, norm));
//            //verts.Add(new VertexPosColNorm(new Vector3(0.5f, -0.5f, -0.5f), col, norm));


//            // Buffer creation

//            var bufferDesc = new BufferDescription
//            {
//                Usage = ResourceUsage.Immutable,
//                BindFlags = BindFlags.VertexBuffer,
//                SizeInBytes = VertexStride * verts.Count,
//                CpuAccessFlags = CpuAccessFlags.None,
//                OptionFlags = ResourceOptionFlags.None
//            };
//            VertexBuffer = new Buffer(device,DataStream.Create(verts.ToArray(),false,false),bufferDesc);


//            var indices = new uint[]
//            {
//                0, 1, 2, 2, 1, 3,
//                4, 6, 5, 5, 6, 7,
//                8, 10, 9, 9, 10, 11,
//                12, 13, 14, 14, 13, 15,
//                16, 18, 17, 17, 18, 19,
//                20, 21, 22, 22, 21, 23
//            };
//            IndexCount = indices.Length;

//            //buffer creations

//             bufferDesc = new BufferDescription
//            {
//                Usage = ResourceUsage.Immutable,
//                BindFlags = BindFlags.IndexBuffer,
//                SizeInBytes =sizeof(uint) * IndexCount,
//                CpuAccessFlags = CpuAccessFlags.None,
//                OptionFlags = ResourceOptionFlags.None
//            };

//            IndexBuffer = new Buffer(device, DataStream.Create(indices, false, false), bufferDesc);
//        }

       
//    }
//}
