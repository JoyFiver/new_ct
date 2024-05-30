using FBP;
using System.Numerics;
using static System.Math;
using Test_f;
using static System.Windows.Forms.DataFormats;
using System.Drawing.Drawing2D;

namespace Test_Form
{
    public partial class _FormProgramma : Form
    {

        



        // Penne di disegno
        #region Penne di disegno


        Brush brush;

        #endregion Penne di disegno


        // Cursor

        //Cursor cursorRotate = new Cursor(Properties.Resources.); //nomeFileCursore.GetHicon()

        // Points

        public Point _PointMousePos;


        //Byte

        #region Byte

        //byte[][] bArr_Img = new byte[2][];

        byte[] bArr_ImgRes = new byte[2];
        byte[] bArr_Coronal = new byte[2];
        byte[] _bArr_ImgResAx = new byte[2];
        byte[] _bArr_ImgResSag = new byte[2];
        byte[] _bArr_ImgResCor = new byte[2];

        #endregion Byte

        // Interi
        #region Int

        int i_LimiteSup = 14000;
        int i_Limiteinf = 0;
        //public int model.i_PosTrackAx, model.i_PosTrackCor, model.i_PosTrackSag;
        public int i_offset_Button = 100; //(px)
        public int i_heightMenuBar;
        int[,] i_matriceImm = new int[2, 2];
        int i_Image_Width = 1024, i_Image_Height = 1024;
        public Point _PointPivotAx, _PointPivotCor, _PointPivotSag;


        Int16[][] iArr_VolImgInt16 = new Int16[2][]; // array immagine 16 Bit
        Int16[,,] MatrixArr_VolImgInt16 = new Int16[1,1,1];

        Int16[] iArr_Axial = new Int16[2]; // array immagine 16 Bit
        Int16[] iArr_Coronal = new Int16[2];
        Int16[] iArr_Sagital = new Int16[2];
        Int16 min = 0, max = 0;

        #endregion int

        // Booleani

        #region Bool

        public bool b_image_loaded = false;
        bool b_ArraysagittalePreparato = false;
        bool b_ArraycoronalePreparato = false;


        bool b_Scroll = false;
        bool b_Move = false;
        bool b_Rotate = false;

        #endregion

        // flat

        //double

        //stringe

        #region string

        string[] sArr_FilePathExam = new string[2];

        #endregion string

        #region controls

        ProgressBar progBMainPanel = new ProgressBar();

        #endregion

        #region Form

        Caricamento loadingForm= new Caricamento();
        AlfanumericComparator alphacomp = new AlfanumericComparator();
        Test_f.View view;
        Model model = new Model();

        #endregion

        public _FormProgramma()
        {
            progBMainPanel = (ProgressBar)loadingForm.Get_loadingBar();
            InitializeComponent();
            DoubleBuffered = true;
            //graphics = this.CreateGraphics();
            //this.Size = this.MaximumSize;
            view = new Test_f.View(this.CreateGraphics(), this, model);
            this.MouseWheel += new MouseEventHandler(MouseeWheel);

            //var asdf = new View(this.CreateGraphics());

             
      

        //asdf.JoySiSveglia += Asdf_JoySiSveglia;
    }

        public PictureBox GetFlowAxial()
        {
            return FlowAxial;
        }
        public PictureBox GetFlowCoronal()
        {
            return FlowCoronal;
        }
        public PictureBox GetFlowSagital()
        {
            return FlowSaggital;
        }

        public Point GetMousePoint()
        {
            return _PointMousePos;
        }

        private void _FormProgramma_Resize(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //fitFormSize();
            this.MaximumSize = this.Size;
            // update current form size
            view.i_OriginalForm_Width = this.Width;
            view.i_OriginalForm_Height = this.Height;
            i_heightMenuBar = _menuBar.Height;
            view.Dynamic_resizeForm();
            view.DisegnaContorni();
            lbl1.Text = "";
        }

        /// <summary>
        /// Aggiorno le posizioni dei posti dove vengono mostrate le immagini
        /// </summary>

        public void PointAssign(ref Point p, int x, int y)
        {
            p.X = x;
            p.Y = y;
        }

        /// <summary>
        /// Conversione byte array in Int16 con shift
        /// </summary>
        /// <param name="bArr"> byte array to convert </param>
        /// <returns></returns>
        private Int16[] byte_to_Int16(byte[] bArr)
        {
            Int16[] bArr_Int16 = new Int16[bArr.Length / 2];
            for (int j = 0; j < bArr_Int16.Length; j++)
            {
                bArr_Int16[j] = (Int16)(bArr[j * 2] | bArr[j * 2 + 1] << 8);
            }
            return bArr_Int16;
        }


        public string[] ArraytoSort(string[] sArray)
        {

            Array.Sort(sArray, new AlfanumericComparator());

            return sArray;
        }


        public void apriToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            softOpenFile();

            view.Form2_Resize(sender,e);

        }


        private void softOpenFile()
        {
            //byte a = 3;
            //byte b = 5;
             // | fa un confronto dei numeri binari e dove se c'è 1 in uno dei due mette 1
            //System.Diagnostics.Debug.WriteLine(a | b);
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {

                sArr_FilePathExam = Directory.GetFiles(fbd.SelectedPath);
                sArr_FilePathExam = ArraytoSort(sArr_FilePathExam);

                model.nFileDaLeggere = sArr_FilePathExam.Length;
                //bArr_Img = new byte[model.nFileDaLeggere][];
                progBMainPanel.Minimum = 0;
                progBMainPanel.Maximum = model.nFileDaLeggere;
                loadingForm.Show();

                iArr_VolImgInt16 = new Int16[model.nFileDaLeggere][]; // array immagine 16 Bit

                MatrixArr_VolImgInt16 = new Int16[model.nFileDaLeggere,1,1];

                byte[] bArr_Img;

                //Leggo i byte dalle immagini
                for (int i = 0; i < model.nFileDaLeggere; i++)
                {


                    progBMainPanel.Value = i;

                    bArr_Img = File.ReadAllBytes(sArr_FilePathExam[i]);

                    iArr_VolImgInt16[i] = new Int16[bArr_Img.Length / 2]; // array immagine 16 Bit

                    Buffer.BlockCopy(bArr_Img, 0, iArr_VolImgInt16[i], 0, bArr_Img.Length);

                    model.nImmCorSag = (int)Sqrt(bArr_Img.Length / 2);
                }

                loadingForm.Close();

                _bArr_ImgResAx = new byte[model.nImmCorSag * model.nImmCorSag * 4];
                _bArr_ImgResCor = new byte[model.nImmCorSag * model.nFileDaLeggere * 4];
                _bArr_ImgResSag = new byte[model.nImmCorSag * model.nFileDaLeggere * 4];

                model.i_PosTrackAx = model.nFileDaLeggere / 2;
                model.i_PosTrackCor = model.nImmCorSag / 2;
                model.i_PosTrackSag = model.nImmCorSag / 2;

                UpdatePivotPoint(ref _PointPivotAx, FlowAxial, model.i_PosTrackCor, model.i_PosTrackSag, model.nImmCorSag, model.nImmCorSag);
                UpdatePivotPoint(ref _PointPivotCor, FlowCoronal, model.i_PosTrackSag, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere);
                UpdatePivotPoint(ref _PointPivotSag, FlowSaggital, model.i_PosTrackCor, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere);

                lbl1.Text = "";

                VisteInclinate(model.thetaAx);
                //AxialPreparation();
                //SagittalPreparation();
                //CoronalPreparation();
                view.DisegnaContorni();

                Application.DoEvents();
            }

        }

        private Rectangle FlowToRect(PictureBox f)
        {
            Rectangle r = new Rectangle(f.Location, f.Size);
            return r;
        }

        private void scalaDiGrigiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void Setup_trackbar(System.Windows.Forms.TrackBar trackbar, int nfile)
        //{
        //    trackbar.Minimum = 0;
        //    trackbar.Maximum = nfile - 1;
        //    trackbar.Visible = true;
        //}


        /// <summary>
        /// Prepara le assiali per essere visualizzate
        /// </summary>
        /// <param name="Immagine"> Array Immagine di Byte da visualizzare </param>
        public void AxialPreparation()
        {
            b_image_loaded = true;
            i_Image_Height = 1024;


            shortArrayToByteFullContrast(iArr_VolImgInt16[model.i_PosTrackAx], _bArr_ImgResAx);

            view.DrawInBitmap(ref view.Joy_Axial, _bArr_ImgResAx, i_Image_Width, i_Image_Height);
            FlowAxial.Refresh();
            //view.DrawBitmap(view.Joy_Axial, view.rect_Axial);
        }



        /// <summary>
        /// Prepara le assiali per essere visualizzate
        /// </summary>
        /// <param name="Immagine"> Array Immagine di Byte da visualizzare </param>
        public void SagittalPreparation()
        {
            //System.Diagnostics.Debug.WriteLine();
            //if (down)
            //{
            b_image_loaded = true;
            i_Image_Height = model.nFileDaLeggere;

            if (!b_ArraysagittalePreparato)
            {
                iArr_Sagital = new Int16[model.nImmCorSag * model.nFileDaLeggere];
                b_ArraysagittalePreparato = true;
            }

            //int ind0 = 0;
            //int ind1 = 0;
            //int ind3 = model.nImmCorSag - Pos;

            Parallel.For(0, model.nFileDaLeggere, iZ =>
            {
                int ind0 = model.nImmCorSag * iZ;
                int ind2 = model.nImmCorSag - model.i_PosTrackSag;

                for (int iX = 0; iX < model.nImmCorSag; iX++)
                {

                    int ind1 = ind0 + iX;
                    int ind3 = model.nImmCorSag * (model.nImmCorSag - iX) - ind2;
                    iArr_Sagital[ind1] = iArr_VolImgInt16[iZ][ind3];

                }
            });
            //File.WriteAllBytes(@"C:\test\sagittal.raw", iArr_Sagital.SelectMany(t => BitConverter.GetBytes(t)).ToArray());
            shortArrayToByteFullContrast(iArr_Sagital, _bArr_ImgResSag);
            view.DrawInBitmap(ref view.Joy_Sagital, _bArr_ImgResSag, i_Image_Width, i_Image_Height);
            FlowSaggital.Refresh();
        }


        /// <summary>
        /// Prepara le assiali per essere visualizzate
        /// </summary>
        /// <param name="Immagine"> Array Immagine di Byte da visualizzare </param>
        public void CoronalPreparation()
        {
            //if (down)
            //{
            b_image_loaded = true;
            i_Image_Height = model.nFileDaLeggere;

            if (!b_ArraycoronalePreparato)
            {
                iArr_Coronal = new Int16[model.nImmCorSag*model.nFileDaLeggere];
                b_ArraycoronalePreparato = true;

            }

            Parallel.For(0, model.nFileDaLeggere, iZ =>
            {
                {
                    int indZ = 1024 * iZ;

                    for (int iX = 0; iX < 1024; iX++)
                    {
                        //iArr_Sagital[1024 * iZ + iX] = iArr_VolImgInt16[iZ][Pos + (1024 * iX)]; // Giusto ma riflesso

                        int ind1 = indZ + iX;

                        int ind2 = (1024 - model.i_PosTrackCor) * 1024 - 1024 + iX;

                        iArr_Coronal[ind1] = iArr_VolImgInt16[iZ][ind2];
                    }
                }
            });
            //}
            shortArrayToByteFullContrast(iArr_Coronal,_bArr_ImgResCor);
            view.DrawInBitmap(ref view.Joy_Coronal, _bArr_ImgResCor, i_Image_Width, i_Image_Height);
            FlowCoronal.Refresh();
            //view.DrawBitmap(view.Joy_Coronal, view.rect_Coronal);
            //File.WriteAllBytes(@"C:\test\coronal.raw", iArr_Coronal.SelectMany(t => BitConverter.GetBytes(t)).ToArray());
            //}
        }

        private void VisteInclinate(float theta)
        {
            //eq piano: ax + by + cz + d = 0;
            //normal : a,b,loadingForm
            float a = 0;
            float b = 1;
            float c = 0;
            float d = 0;
            Vector4 plane = new Vector4(a, b, c, d);
            FromPlaneToImage(iArr_VolImgInt16, model.nImmCorSag, model.nImmCorSag, model.nFileDaLeggere, a, b, c, d);
            Vector4 Newplane;
            Matrix4x4 RotationMatrix = Matrix4x4.CreateRotationZ(theta);
            //Plane plane = new Plane(a, b, loadingForm, d);
            Newplane = Vector4.Transform(plane, RotationMatrix);
        }
        public void FromPlaneToImage(Int16[][] iArr_VolImgInt16, int width, int height, int depth, float a, float b, float c, float d)
        {
            Int16[,] planeImage = new Int16[width, depth]; //            Int16[,] planeImage = new Int16[width,depth];
            Vector3 pos;
            Vector3 plane = new Vector3(a, b, c);

            for (pos.Z = 0; pos.Z < depth; pos.Z++)
            {
                for (pos.Y = 0; pos.Y < height; pos.Y++)
                {
                    for (pos.X = 0; pos.X < width; pos.X++)
                    {
                        // Verifica se il punto (x, y, z) soddisfa l'equazione del piano
                        //Math.Abs(a * x + b * y + c * z + d) < 1
                        if (Vector3.Dot(pos,plane) + d == 0) 
                        {
                            try
                            {
                                planeImage[(int)pos.X, (int)pos.Z] = CoordsToPixel((int)pos.X, (int)pos.Y, (int)pos.Z);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                    }
                }
            }
            shortArrayToByteFullContrast(MultiDimToJagged(planeImage), _bArr_ImgResCor);
            view.DrawInBitmap(ref view.Joy_Coronal, _bArr_ImgResCor, width, depth);
            File.WriteAllBytes(@"C:\test\coronal.raw", iArr_Coronal.SelectMany(t => BitConverter.GetBytes(t)).ToArray());
            FlowCoronal.Refresh();
        }
        private Int16 CoordsToPixel(int x, int y, int z) 
        {
            if((x<=model.nImmCorSag && y<= model.nImmCorSag && z<= model.nFileDaLeggere) && (x>=0 && y>=0 && z >=0))
            {
                return iArr_VolImgInt16[z][y* model.nImmCorSag + x];
            }
            else
            {
                return 0;
            }
        }
        
        private Int16[] MultiDimToJagged(Int16[,] arr)
        {
            int lengthX = arr.GetLength(0);
            int lengthY = arr.GetLength(1);
            Int16[] array = new Int16[lengthX * lengthY];
            for (int x = 0; x < lengthX; x++)
            {
                for (int y = 0; y < lengthY; y++)
                {
                    array[y + x * lengthY] = arr[x, y];
                }
            }
            return array;
        }

        void shortArrayToByteFullContrast(short[] shortArray, byte[] byteArray)
        {
            int max = shortArray.Max();
            int min = shortArray.Min();

            Int16 new_max = (Int16)(max - min); // perchè il min è negativo
            if (new_max == 0)
            {
                new_max = 1;
            }

            int l = shortArray.Length;
            if (byteArray.Length/4 != l)
                throw new Exception("ho fatto casino con le dimensioni");

            Parallel.For(0, l, j=>
                { 
            //for (int j = 0; j < l; j++)
            //{
                //effettuo le proporzioni
                short tmp = (Int16)(((shortArray[j] - min) * 255) / new_max);

                byte Val = (byte)tmp;

                byteArray[j * 4] = Val;
                byteArray[j * 4 + 1] = Val;
                byteArray[j * 4 + 2] = Val;
                byteArray[j * 4 + 3] = 255;

            });
        }

        private void _button1_Click(object sender, EventArgs e)
        {
           
        }

        #region DrawLine

        


        #endregion
        
        

        private void FlowLAxial_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(view.Joy_Axial, 0,0, FlowAxial.Width, FlowAxial.Height);
            view.DrawInclinedLineOnFlow(e.Graphics, FlowAxial, model.i_PosTrackSag, model.i_PosTrackCor, model.nImmCorSag, model.nImmCorSag, view._BrushColoreSag, view._BrushColoreCor, model.thetaAx, _PointPivotAx);
            //e.Graphics.DrawEllipse(new Pen(Color.Red), _PointPivotAx.X - 5, _PointPivotAx.Y - 5, 10, 10);
            //e.Graphics.FillEllipse(new SolidBrush(Color.Red), _PointPivotAx.X-5, _PointPivotAx.Y-5, 10, 10);
        }
        private void FlowSaggital_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(view.Joy_Sagital, 0, 0, FlowSaggital.Width, FlowSaggital.Height);
            view.DrawInclinedLineOnFlow(e.Graphics, FlowSaggital, model.i_PosTrackCor, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere, view._BrushColoreCor, view._BrushColoreAx, model.thetaSag, _PointPivotSag);
        }

        private void FlowCoronal_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(view.Joy_Coronal, 0, 0, FlowCoronal.Width, FlowCoronal.Height);
            view.DrawInclinedLineOnFlow(e.Graphics, FlowCoronal, model.i_PosTrackSag, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere, view._BrushColoreSag, view._BrushColoreAx, model.thetaCor, _PointPivotCor);
            //e.Graphics.DrawEllipse(new Pen(Color.Red), _PointPivotCor.X - 5, _PointPivotCor.Y - 5, 10, 10);
            //e.Graphics.FillEllipse(new SolidBrush(Color.Red), _PointPivotCor.X-5, _PointPivotCor.Y-5, 10, 10);
        }

        /*protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
        }*/


        public void NewPose(Rectangle r,Control c)
        {
            int newX = 0;
            int newY = 0;
            c.Location = new Point(newX, newY);
        }

        //from stackImg to formWidth
        public static int newRangeLineX(PictureBox flow,int value,int numImm) 
        {
            int NewValue = (value * (flow.Width) / numImm); 
            return NewValue;
        }
        //from stackImg to formHeight
        public static int newRangeLineY(PictureBox flow, int value, int numImm)
        {
            int NewValue = (value * flow.Height / numImm); 
            return NewValue;
        }
        
        //mouse coords to img coords
        public static int newRangeX(PictureBox flow, int posMouse, int nImm)
        {
            int NewValue = posMouse *nImm / flow.Width;
            if (NewValue < 0)
            {
                NewValue = 0;
            }
            else if (NewValue > nImm)
            {
                NewValue = nImm - 1;
            }
            return NewValue;
        }
        public static int newRangeY(PictureBox flow, int posMouse, int nImm)
        {
            int NewValue = posMouse * nImm / flow.Height;
            if (NewValue < 0)
            {
                NewValue = 0;
            }
            else if (NewValue > nImm)
            {
                NewValue = nImm - 1;
            }
            return NewValue;
        }

        #region Mouse

        int quadratoMove = 30;

        private void MuoviRuotaScorriCheck(PictureBox flow,Point PointPivot,MouseEventArgs e)
        {
            //

            if ((_PointMousePos.X < PointPivot.X + quadratoMove && _PointMousePos.X > PointPivot.X - quadratoMove) && (_PointMousePos.Y < PointPivot.Y + quadratoMove && _PointMousePos.Y > PointPivot.Y - quadratoMove))
            {
                if (!inUse && down)
                {
                    inUse = true;
                    b_Move = true;
                }
                else if (!down)
                {
                    Cursor.Current = Cursors.Hand;
                }
            }
            // Ruota
            else if (CheckNearLines(e, PointPivot))
            {
                if (!inUse && down)
                {
                    inUse = true;
                    b_Rotate = true;
                }
                else if (!down)
                {
                    Cursor.Current = Cursors.PanNorth;
                }
            }
            // Scorri immagini
            else
            {
                if (!inUse && down)
                {
                    inUse = true;
                    b_Scroll = true;
                }
                else if (!down)
                {
                    Cursor.Current = Cursors.Cross;
                }
            }
        }
        private Point CoordsToCenterPivot(Point point, Point PointPivot)
        {
            point.X -= PointPivot.X; //flow.Location.X + flow.Width / 2; 
            point.Y -= PointPivot.Y;// flow.Location.Y + flow.Height/2; 

            return point;
        }

        public Point UpdatePivotPoint(ref Point PointPivot, PictureBox flow, int posTrack1, int posTrack2, int maxIm1, int maxIm2)
        {
            PointPivot.X = newRangeLineX(flow, posTrack1, maxIm1);
            PointPivot.Y = newRangeLineY(flow, posTrack2, maxIm2);
            //g.DrawEllipse(new Pen(Color.Red), PointPivot.X-5, PointPivot.Y-5, 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Red), PointPivot.X-5, PointPivot.Y-5, 10, 10);
            return PointPivot;
        }


        bool down = false;
        bool inUse = false;
        int difference,previousLocation = 0;
        Point posizioneRelForm;

        private void _FormProgramma_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            b_Move = false;
            b_Rotate = false;
            b_Scroll = false;
            inUse = false;

            //debug
            //model.thetaAx = 0;
            //this.MouseMove -= _FormProgramma_MouseMoveOnHold;
        }


        private void _FormProgramma_KeyDown(object sender, KeyEventArgs e)
        {
            //ruoto di 1 grado lungo vista assiale
            //theta += 1;
            //label2.Text = theta.ToString();
            //if (e.KeyCode == Keys.R) {
            //    CoordsToPixel((int)(Math.Cos(theta) * model.nImmCorSag), (int)(Math.Sin(theta) * model.nImmCorSag),1);
            //}

        }

        private void MouseeWheel(object sender, MouseEventArgs e)
        {
            // Scrolled up > 0
            int step = 10;
            if (e.Delta <= 0)
            {
            //    if (b_AxialBox)
            //    {
            //        if (model.i_PosTrackAx < model.nFileDaLeggere - step)
            //        {
            //            model.i_PosTrackAx += step;
            //            view.JustAx();
            //            //label2.Text = model.i_PosTrackAx.ToString();
            //        }
            //    }
            //    else if (b_CoronalBox)
            //    {
            //        if (model.i_PosTrackCor < model.nImmCorSag - step)
            //        {
            //            model.i_PosTrackCor += step;
            //            view.JustCor();
            //        }
            //    }
            //    else if (b_SagittalBox)
            //    {
            //        if (model.i_PosTrackSag < model.nImmCorSag - step)
            //        {
            //            model.i_PosTrackSag += step;
            //            view.JustSag();
            //        }
            //    }
            //}
            //// Scrolled down
            //else
            //{
            //    if (b_AxialBox)
            //    {
            //        if (model.i_PosTrackAx > step)
            //        {
            //            model.i_PosTrackAx -= step;
            //            view.JustAx();
            //        }
            //    }
            //    else if (b_CoronalBox)
            //    {
            //        if (model.i_PosTrackCor > step)
            //        {
            //            model.i_PosTrackCor -= step;
            //            view.JustCor();
            //        }
            //    }
            //    else if (b_SagittalBox)
            //    {
            //        if (model.i_PosTrackSag > step)
            //        {
            //            model.i_PosTrackSag -= step;
            //            view.JustSag();
            //        }
            //    }
            }
        }

        private void FlowAxial_MouseMove(object sender, MouseEventArgs e)
        {
            difference = e.Y - previousLocation;
            _PointMousePos.X = e.X;
            _PointMousePos.Y = e.Y;
            //Sposta
            posizioneRelForm = CoordsToCenterPivot(new Point(_PointMousePos.X, _PointMousePos.Y), _PointPivotAx);

            MuoviRuotaScorriCheck(FlowAxial,_PointPivotAx, e);
            //label2.Text = _PointPivotAx.ToString() + " " + _PointMousePos.ToString();
            if (b_Scroll)
            {
                //label2.Text = "SCORRI";
                if (model.i_PosTrackAx + difference <= model.nFileDaLeggere && model.i_PosTrackAx + difference > 0)
                {
                    model.i_PosTrackAx += difference;
                }
                view.JustAx();
            }
            else if (b_Move)
            {
                model.i_PosTrackSag = newRangeX(FlowAxial, _PointMousePos.X, model.nImmCorSag); //_PointMousePos.X * model.nImmCorSag / FlowAxial.Width
                model.i_PosTrackCor = newRangeY(FlowAxial, _PointMousePos.Y, model.nImmCorSag); //newRangeY(FlowAxial, mouseCoordsToFlowY, model.nImmCorSag)
                //view.RefleshFlow(FlowAxial);
                FlowAxial.Refresh();
                UpdatePivotPoint(ref _PointPivotAx, FlowAxial, model.i_PosTrackSag, model.i_PosTrackCor, model.nImmCorSag, model.nImmCorSag);
                CoronalPreparation();
                SagittalPreparation();
                Application.DoEvents();
            }
            else if (b_Rotate)
            {
                model.thetaAx = (float)Math.Atan2(posizioneRelForm.Y, posizioneRelForm.X);
                label2.Text = Math.Round(180 / Math.PI * model.thetaAx,2).ToString();
                FlowAxial.Refresh();
                FlowCoronal.Refresh();
                FlowSaggital.Refresh();
            }
            previousLocation = e.Location.Y;
        }

        private void FlowCoronal_MouseMove(object sender, MouseEventArgs e)
        {
            difference = e.Y - previousLocation;
            MuoviRuotaScorriCheck(FlowCoronal,_PointPivotCor, e);
            if (b_Scroll)
            {
                //label2.Text = "SCORRI";
                if (model.i_PosTrackCor + difference <= model.nFileDaLeggere && model.i_PosTrackCor + difference > 0)
                {
                    model.i_PosTrackCor += difference;
                }
                view.JustCor();
            }
            else if (b_Move)
            {
                model.i_PosTrackSag = newRangeX(FlowCoronal, _PointMousePos.X, model.nImmCorSag);
                model.i_PosTrackAx = newRangeY(FlowCoronal, _PointMousePos.Y, model.nFileDaLeggere);
                //view.RefleshFlow(FlowCoronal);
                UpdatePivotPoint(ref _PointPivotCor, FlowCoronal, model.i_PosTrackSag, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere);
                FlowCoronal.Refresh();
                AxialPreparation();
                SagittalPreparation();
                Application.DoEvents();
                //label2.Text = "SPOSTA";
            }
            else if (b_Rotate)
            {
                model.thetaCor = (float)Math.Atan2(posizioneRelForm.Y, posizioneRelForm.X);
                FlowAxial.Refresh();
                FlowCoronal.Refresh();
                FlowSaggital.Refresh();
            }
        }

        private void FlowSaggital_MouseMove(object sender, MouseEventArgs e)
        {
            posizioneRelForm = CoordsToCenterPivot(_PointMousePos, _PointPivotAx);

            MuoviRuotaScorriCheck(FlowSaggital,_PointPivotCor, e);
            Cursor.Current = Cursors.Hand;
            if (b_Scroll)
            {
                //label2.Text = "SCORRI";
                if (model.i_PosTrackSag + difference <= model.nImmCorSag && model.i_PosTrackSag + difference > 0)
                {
                    model.i_PosTrackSag += difference;
                }
                view.JustSag();
            }
            else if (b_Move)
            {
                model.i_PosTrackCor = newRangeX(FlowSaggital, _PointMousePos.X, model.nImmCorSag);
                model.i_PosTrackAx = newRangeY(FlowSaggital, _PointMousePos.Y, model.nFileDaLeggere);
                //view.RefleshFlow(FlowSaggital); ;
                FlowSaggital.Refresh();
                UpdatePivotPoint(ref _PointPivotSag, FlowSaggital, model.i_PosTrackCor, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere);
                CoronalPreparation();
                AxialPreparation();
                Application.DoEvents();
                //label2.Text = "SPOSTA";
            }
            else if (b_Rotate)
            {
                //label2.Text = "RUOTA";
                model.thetaCor += difference;
            }
            previousLocation = e.Location.Y;
        }

        private void FlowAxial_MouseDown(object sender, MouseEventArgs e)
        {
            if (b_image_loaded)
            {
                down = true;
                FlowAxial_MouseMove(sender, e);
            }
        }

        private void FlowAxial_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            b_Move = false;
            b_Rotate = false;
            b_Scroll = false;
            inUse = false;
        }

        private void _FormProgramma_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void _FormProgramma_MouseMoveOnHold(object? sender, MouseEventArgs e)
        {

        }
        private void _FormProgramma_MouseEnter(object sender, EventArgs e)
        {
            b_Move = false;
            b_Rotate = false;
            b_Scroll = false;
            inUse = false;
        }
        private void _FormProgramma_MouseHover(object sender, EventArgs e)       
        {
        }
        private void _FormProgramma_MouseLeave(object sender, EventArgs e)
        {
            
        }

        bool CheckNearLines(MouseEventArgs e,Point posLine)
        {
            int tolleranza = 20;
            _PointMousePos.X = e.X;
            _PointMousePos.Y = e.Y;
            //se sono lontano dalle linee
            if(_PointMousePos.X < posLine.X + tolleranza && _PointMousePos.X > posLine.X - tolleranza)
            {
                return true;
            }
            if (_PointMousePos.Y < posLine.Y + tolleranza && _PointMousePos.Y > posLine.Y - tolleranza)
            {
                return true;
            }
            return false;
        }


        #endregion Mouse


    }
}