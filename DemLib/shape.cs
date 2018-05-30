using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using System.Drawing;

namespace DemLib
{

    public abstract class shape
    {
       
        public Vector3[] Vertices { get; protected set; }

        public Vector3[] Normals { get; protected set; }

        public Vector2[] Texcoords { get; protected set; }

        public uint[] Indices { get; protected set; }

        public Color[] Colors { get; protected set; }
    }
}
