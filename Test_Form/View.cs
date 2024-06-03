using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Form;
using static Test_Form._FormProgramma;

namespace Test_f
{
    public class View
    {

        Rectangle Rect_ContornoAxial;
        Rectangle Rect_ContornoCoronal;
        Rectangle Rect_ContornoSagittal;

        // Bitmap

        #region Bitmap

        //public Bitmap Joy_Axial = new Bitmap(1024, 1024);
        //public Bitmap Joy_Coronal = new Bitmap(1024, 750);
        //public Bitmap Joy_Sagital = new Bitmap(1024, 750);
        public Bitmap Joy_Axial;
        public Bitmap Joy_Coronal;
        public Bitmap Joy_Sagital;

        #endregion

        //Brush e Pen
        #region Brush e Pen

        public Brush _BrushColoreAx = new SolidBrush(Color.Azure);
        public Brush _BrushColoreCor = new SolidBrush(Color.Red);
        public Brush _BrushColoreSag = new SolidBrush(Color.Green);
        public Pen _PenColoreAx = new Pen(Color.Azure,5);
        public Pen _PenColoreCor = new Pen(Color.Red,5);
        public Pen _PenColoreSag = new Pen(Color.Green,5);
        _FormProgramma f;
        Model model;
        #endregion

        //int
        int i_offsetContorni = 5;
        public int i_OriginalForm_Width = 0;
        public int i_OriginalForm_Height = 0;


        //public event EventHandler JoySiSveglia;
        public View(Graphics g,_FormProgramma F,Model m)
        {
            //this.g = g;
            f = F;
            model = m;

            f.Resize += Form2_Resize;
        }

        public void Form2_Resize(object sender, EventArgs e)
        {

            Dynamic_resizeForm();
            //System.Diagnostics.Debug.WriteLine(this.Width);

            if (f.b_image_loaded)
            {
                f.UpdatePivotPoint(ref f._PointPivotAx, f.FlowAxial, model.i_PosTrackSag, model.i_PosTrackCor, model.nImmCorSag, model.nImmCorSag);
                f.UpdatePivotPoint(ref f._PointPivotCor, f.FlowCoronal, model.i_PosTrackSag, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere);
                f.UpdatePivotPoint(ref f._PointPivotSag, f.FlowSaggital, model.i_PosTrackCor, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere);
                //f.CreateGraphics().Clear(Color.Black);
                DisegnaContorni();
            }
            i_OriginalForm_Width = f.Width;
            i_OriginalForm_Height = f.Height;
        }

        //public void Sveglia()
        //{
        //    //JoySiSveglia.Invoke(this, EventArgs.Empty);
        //}


        public static void UpdateSizePos(ref Rectangle r, PictureBox f)
        {
            r.Location = f.Location;
            r.Size = f.Size;
        }

        // imageWidth e Height sono riferiti alle dimensioni originali
        public void DrawInBitmap(ref Bitmap Joy, Byte[] Immagine, int Image_Width, int Image_Height)
        {

            var brush = new SolidBrush(new Color());

            // Lock the bitmap's bits.  

            var bmpData = Joy.LockBits(new Rectangle(0, 0, Image_Width, Image_Height), System.Drawing.Imaging.ImageLockMode.ReadWrite,
                Joy.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            //// Declare an array to hold the bytes of the bitmap.
            int bytes = Immagine.Length;


            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(Immagine, 0, ptr, bytes);

            // Unlock the bits.
            Joy.UnlockBits(bmpData);


        }
        
        /// <summary>
        /// Funzione di disegno
        /// </summary>
        /// <param name="Immagine"> immagine da mostrare a video </param>
        /// <param name="Rect" > posizione rettangolo di appartenenza sullo schermo </param>

        public void DisegnaContorni() //Graphics g,Pen pen
        {
            Rect_ContornoAxial = new Rectangle(f.GetFlowAxial().Location.X, f.GetFlowAxial().Location.Y, f.GetFlowAxial().Width,f.GetFlowAxial().Height);
            Rect_ContornoCoronal = new Rectangle(f.GetFlowCoronal().Location.X, f.GetFlowCoronal().Location.Y, f.GetFlowCoronal().Width, f.GetFlowCoronal().Height);
            Rect_ContornoSagittal = new Rectangle(f.GetFlowSagital().Location.X , f.GetFlowSagital().Location.Y , f.GetFlowSagital().Width,  f.GetFlowSagital().Height);
            f.CreateGraphics().DrawRectangle(_PenColoreAx, Rect_ContornoAxial);
            f.CreateGraphics().DrawRectangle(_PenColoreSag, Rect_ContornoSagittal);
            f.CreateGraphics().DrawRectangle(_PenColoreCor, Rect_ContornoCoronal);
        }
        /*public void DrawPoints(PictureBox flow, Brush brush1, Brush brush2)
        {
            // Cerchio x
            g.DrawEllipse(new Pen(brush1), f.GetMousePoint().X, flow.Location.Y + flow.Height / 2, 10, 10);
            g.FillEllipse(brush1, f.GetMousePoint().X, flow.Location.Y + flow.Height / 2, 10, 10);
            // Cerchio y
            g.DrawEllipse(new Pen(brush2), flow.Location.X + flow.Width / 2, f.GetMousePoint().Y, 10, 10);
            g.FillEllipse(brush2, flow.Location.X + flow.Width / 2, f.GetMousePoint().Y, 10, 10);
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flow"> where to draw </param>
        /// <param name="posTrack1"> param to change </param>
        /// <param name="posTrack2">param to change</param>
        /// <param name="maxIm1">nImm1</param>
        /// <param name="maxIm2">nImm2</param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>

        

        public void DrawInclinedLineOnFlow(Graphics g,PictureBox flow, int posTrack1, int posTrack2, int maxIm1, int maxIm2, Brush color1, Brush color2, double theta, Point PointPivot)
        {
            Point[] _PointLine = new Point[2]; // linea di riferimento Coronale sull'assiale
            /*double[,] rotationMatrix = { {(float)Math.Cos(theta), -(float)Math.Sin(theta)},{ (float)Math.Sin(theta), (float)Math.Cos(theta) } };
            double[,] pos1 = new double[2, 1];
            pos1[0, 0] = newRangeLineX(flow, posTrack1, maxIm1);
            pos1[1,0] = flow.Location.Y + 5;
            double[,] pos2 = new double[2, 1];
            pos2[0, 0] = newRangeLineX(flow, posTrack1, maxIm1);
            pos2[1, 0] = flow.Location.Y + 5 + flow.Height;
            script loadingForm# che fa ruotare 1 punto sapendo l'angolo ed il perno secondo cui ruotare
            double[,] result1 = new double[2,1];
            double[,] result2 = new double[2, 1];
            result2 = f.MultiplyMatrix(rotationMatrix, pos2);
            result1 =   f.MultiplyMatrix(rotationMatrix, pos1);
            f.PointAssign(ref _PointLine[0], (int)result1[0,0],(int)result1[1, 0]); 
            f.PointAssign(ref _PointLine[1], (int)result2[0, 0], (int)result2[1, 0]);*/
            //VerticalLine
            _PointLine[0] = Rotate2DPoint(newRangeLineX(flow, posTrack1, maxIm1), flow.Location.Y - 1000, PointPivot.X, PointPivot.Y, theta);
            _PointLine[1] = Rotate2DPoint(newRangeLineX(flow, posTrack1, maxIm1), flow.Location.Y + flow.Height + 1000, PointPivot.X, PointPivot.Y, theta);
            g.DrawLine(new Pen(color1), _PointLine[0], _PointLine[1]);
            //HorizontalLine
            _PointLine[0] = Rotate2DPoint(flow.Location.X - 1000, newRangeLineY(flow, posTrack2, maxIm2), PointPivot.X, PointPivot.Y, theta);
            _PointLine[1] = Rotate2DPoint(flow.Location.X + flow.Width + 1000, newRangeLineY(flow, posTrack2, maxIm2), PointPivot.X, PointPivot.Y, theta);
            g.DrawLine(new Pen(color2), _PointLine[0], _PointLine[1]);

            if (theta == 0)
            {
                //VerticalLine
                f.PointAssign(ref _PointLine[0], newRangeLineX(flow, posTrack1, maxIm1), flow.Location.Y); //+ Math.Tan(theta) * (flow.Location.Y + flow.Height - PointPivot.Y)
                f.PointAssign(ref _PointLine[1], newRangeLineX(flow, posTrack1, maxIm1), flow.Location.Y + flow.Height); //- Math.Tan(theta) * (flow.Location.Y + flow.Height - PointPivot.Y)
                g.DrawLine(new Pen(color1), _PointLine[0], _PointLine[1]);
                //HorizontalLine
                f.PointAssign(ref _PointLine[0], flow.Location.X + 5,newRangeLineY(flow, posTrack2, maxIm2));
                f.PointAssign(ref _PointLine[1], flow.Location.X + flow.Width - 5, newRangeLineY(flow, posTrack2, maxIm2));
                g.DrawLine(new Pen(color2), _PointLine[0], _PointLine[1]);
            }
            // se pi/2
            else if(Math.Round(theta, 3) == Math.Round(Math.PI / 2, 3))
            {
                f.PointAssign(ref _PointLine[0], newRangeLineX(flow, posTrack1, maxIm1), flow.Location.Y); //+ Math.Tan(theta) * (flow.Location.Y + flow.Height - PointPivot.Y)
                f.PointAssign(ref _PointLine[1], newRangeLineX(flow, posTrack1, maxIm1), flow.Location.Y + flow.Height); //- Math.Tan(theta) * (flow.Location.Y + flow.Height - PointPivot.Y)
                g.DrawLine(new Pen(color1), _PointLine[0], _PointLine[1]);
                //HorizontalLine
                f.PointAssign(ref _PointLine[0], flow.Location.X + 5, newRangeLineY(flow, posTrack2, maxIm2));
                f.PointAssign(ref _PointLine[1], flow.Location.X + flow.Width - 5, newRangeLineY(flow, posTrack2, maxIm2));
                g.DrawLine(new Pen(color2), _PointLine[0], _PointLine[1]);
            }
        }
        public void SmartResize(Control c)
        {
            int space_X = f.Width / 2;
            int space_Y = (f.Height - f.i_heightMenuBar - 20) / 2; // 10 è un offset per non avere la vista assiale e saggitale attaccata alla barra
            int newX = 10;
            int newY = 10 + f.i_heightMenuBar;
            if (c is PictureBox)
            {
                f.i_offset_Button = 100;
                //int newWidth = space_X - this.Width/10;
                int newHeight = space_Y - f.Width / 30; // this.Width / 80 serve per ridurre il quadrato 
                c.Size = new Size(newHeight, newHeight);
                if (c == f.FlowSaggital)
                {
                    //newX = _trackBarAx.Location.X + 10 * space_X/100;
                    newX = f.FlowAxial.Location.X + f.FlowAxial.Width + 10 * space_X / 100;
                    c.Height = newHeight * model.nFileDaLeggere / model.nImmCorSag;
                }
                else if (c == f.FlowCoronal)
                {
                    newY = space_Y + 10;
                    c.Height = newHeight * model.nFileDaLeggere / model.nImmCorSag;
                }
                if (c == f.FlowImage)
                {
                    if (f.WindowState == FormWindowState.Maximized)
                    {
                        newX = f.FlowSaggital.Location.X + f.FlowSaggital.Width + 10;
                        c.Height = space_Y*2;
                        c.Width = f.Width - f.FlowSaggital.Location.X - f.FlowSaggital.Width;
                        c.Visible = true;
                    }

                }
                //int FlowImage_X = this.Width - _trackBarSag.Location.X;
                //loadingForm.Size = new Size(FlowImage_X / 2, FlowImage_X / 2);
            }
            c.Location = new Point(newX, newY);


        }
        public void Dynamic_resizeForm()
        {
            SmartResize(f.FlowAxial);
            SmartResize(f.FlowSaggital);
            SmartResize(f.FlowCoronal);
            SmartResize(f.FlowImage);

        }
        public void PosButton(Control c)
        {
            int newX = f.FlowSaggital.Location.X; //* ((this.Width * this.Height)/(i_OriginalForm_Height * i_OriginalForm_Width)
            int newY = f.FlowSaggital.Location.Y + f.FlowSaggital.Height + f.i_offset_Button;
            c.Location = new Point(newX, newY);
            f.i_offset_Button += 50;
        }

        public void JustAx()
        {
            f.AxialPreparation();
            f.FlowCoronal.Refresh();
            f.FlowSaggital.Refresh();
        }
        public void JustCor()
        {
            //DrawBitmap(Joy_Axial, Rect_Axial);
            //DrawInclinedLineOnFlow(f.FlowAxial, model.i_PosTrackSag, model.i_PosTrackCor, model.nImmCorSag, model.nImmCorSag, _BrushColoreSag, _BrushColoreCor, model.thetaAx);
            //f.CoronalPreparation();
            //DrawInclinedLineOnFlow(f.FlowCoronal, model.i_PosTrackSag, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere, _BrushColoreSag, _BrushColoreAx, model.thetaCor);
            //DrawBitmap(Joy_Sagital, Rect_Sagittal);
            //DrawInclinedLineOnFlow(f.FlowSaggital, model.i_PosTrackCor, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere, _BrushColoreCor, _BrushColoreAx, model.thetaSag);
        }
        public void JustSag()
        {
            //DrawBitmap(Joy_Axial, Rect_Axial);
            //DrawInclinedLineOnFlow(f.FlowAxial, model.i_PosTrackSag, model.i_PosTrackCor, model.nImmCorSag, model.nImmCorSag, _BrushColoreSag, _BrushColoreCor, model.thetaAx);
            //DrawBitmap(Joy_Coronal, Rect_Coronal);
            //DrawInclinedLineOnFlow(f.FlowCoronal, model.i_PosTrackSag, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere, _BrushColoreSag, _BrushColoreAx, model.thetaCor);
            //f.SagittalPreparation();
            //DrawInclinedLineOnFlow(f.FlowSaggital, model.i_PosTrackCor, model.i_PosTrackAx, model.nImmCorSag, model.nFileDaLeggere, _BrushColoreCor, _BrushColoreAx, model.thetaSag);
        }
    }
}
