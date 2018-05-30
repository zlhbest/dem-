using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SysKeyPressEventArgs = System.Windows.Forms.KeyPressEventArgs;
using System.Diagnostics;


namespace DemLib
{
    public partial class MyGLControl : GLControl
    {
        private readonly Stopwatch _watch = new Stopwatch();
        private bool _draging;
        private int _frameCount;
        private bool dixing=false, tietu=false;
        public bool yes=false;
        /// <summary>
        ///     标记是否已经加载
        /// </summary>
        private bool _loaded;
        //private SwiftHeightField _heightField;
        public TerrainTile _terrain;
        private float angle = 0.0F;
        private float bounce;
        private float cScale = 4.0F;
        private float lastx, lasty;
        private float xpos = 851.078F;
        private float xrot = 758F;
        private float ypos = 351.594F;
        private float yrot = 238F;
        private float zpos = 381.033F;

        public bool Dixing
        {
            set { dixing = value; }
            get { return dixing; }
        }
        public bool Tietu
        {
            set { tietu = value; }
            get { return tietu; }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            _loaded = true;
            _terrain = new TerrainTile(Dixing, Tietu);
            Application.Idle += Application_Idle;
          
            SetupViewport();
           
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            

            _watch.Start();
        }

        /// <summary>
        ///     创建OpenGL视图
        /// </summary>
        private void SetupViewport() {
            GL.Viewport(ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projMatrix = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                AspectRatio,
                1.0F,
                3000F
                );
            GL.LoadMatrix(ref projMatrix);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (!yes)
            {
                _terrain = new TerrainTile(Dixing, Tietu);
                yes = true;
            }
            while (IsIdle)
            {
               
                Render();
            }
        }

        /// <summary>
        ///     OpenGL 渲染
        /// </summary>
        private void Render() {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            SetupCamera();
            _terrain.Render();
            SwapBuffers();
            _frameCount++;
            if (_watch.ElapsedMilliseconds > 1000) {
                _watch.Reset();
                _watch.Start();
                ParentForm.Text = string.Format("FrameCount: {0}", _frameCount);
                _frameCount = 0;
            }
        }

        private void SetupCamera() {
            GL.MatrixMode(MatrixMode.Modelview);
            var eye = new Vector3d(xpos, ypos, zpos);
            Matrix4d matrix = Matrix4d.LookAt(eye, new Vector3d(64, 0, 64), Vector3d.UnitY);
            GL.LoadMatrix(ref matrix);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            if (!_loaded) {
                return;
            }
            SetupViewport();
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.W) {
                float yrotrad = (yrot / 180 * MathHelper.Pi);
                float xrotrad = (xrot / 180 * MathHelper.Pi);
                xpos += (float)Math.Sin(yrotrad) * cScale;
                zpos -= (float)Math.Cos(yrotrad) * cScale;
                ypos -= (float)Math.Sin(xrotrad);
                bounce += 0.04F;
            }
            if (e.KeyCode == Keys.S) {
                float xrotrad, yrotrad;
                yrotrad = (yrot / 180 * 3.141592654f);
                xrotrad = (xrot / 180 * 3.141592654f);
                xpos -= (float)(Math.Sin(yrotrad)) * cScale;
                zpos += (float)(Math.Cos(yrotrad)) * cScale;
                ypos += (float)(Math.Sin(xrotrad));
                bounce += 0.04F;
            }
            if (e.KeyCode == Keys.D) {
                float yrotrad;
                yrotrad = (yrot / 180 * 3.141592654f);
                xpos += (float)(Math.Cos(yrotrad)) * cScale;
                zpos += (float)(Math.Sin(yrotrad)) * cScale;
            }
            if (e.KeyCode == Keys.A) {
                float yrotrad;
                yrotrad = (yrot / 180 * 3.141592654f);
                xpos -= (float)(Math.Cos(yrotrad)) * cScale;
                zpos -= (float)(Math.Sin(yrotrad)) * cScale;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            _draging = true;
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            _draging = false;
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (!_loaded) {
                return;
            }
            Render();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyGLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.Name = "MyGLControl";
            this.Size = new System.Drawing.Size(256, 220);
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing) {
            _terrain.Dispose();
            base.Dispose(disposing);
        }
    }
}
