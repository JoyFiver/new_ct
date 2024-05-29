using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Form
{
    internal class FlowLayout_Base:Model
    {
        public FlowLayout_Base() { }

        private int nImm, posTrack,theta;
        Int16[] iArr = new Int16[2];
        private Bitmap Joy;
        private Brush brush;
        private Pen Pen;
        private Rectangle Rect;
        private Point PointPivot;

        public int NImm { get => nImm; set => nImm = value; }
        public int PosTrack { get => posTrack; set => posTrack = value; }
        public int Theta { get => theta; set => theta = value; }
        public short[] IArr { get => iArr; set => iArr = value; }
        public Bitmap Joy1 { get => Joy; set => Joy = value; }
        public Brush Brush { get => brush; set => brush = value; }
        public Pen Pen1 { get => Pen; set => Pen = value; }
        public Rectangle Rect1 { get => Rect; set => Rect = value; }
        public Point PointPivot1 { get => PointPivot; set => PointPivot = value; }
    }

    class FlowAxial : FlowLayout_Base
    {
        public FlowAxial() { }
    }
    class FlowCoronal : FlowLayout_Base
    {
        public FlowCoronal() { }

        public void CoronalPreparation()
        {

            //b_image_loaded = true;
            //i_Image_Height = model.nFileDaLeggere;

            //if (!b_ArraicoronalePreparato)
            //{
            //    iArr_Coronal = new Int16[NImm * model.nFileDaLeggere];
            //    b_ArraicoronalePreparato = true;
            //}

            //Parallel.For(0, model.nFileDaLeggere, iZ =>
            //{
            //    {
            //        int indZ = 1024 * iZ;

            //        for (int iX = 0; iX < 1024; iX++)
            //        {
            //            //iArr_Sagital[1024 * iZ + iX] = iArr_VolImgInt16[iZ][Pos + (1024 * iX)]; // Giusto ma riflesso

            //            int ind1 = indZ + iX;

            //            int ind2 = (1024 - i_PosTrackCor) * 1024 - 1024 + iX;

            //            iArr_Coronal[ind1] = iArr_VolImgInt16[iZ][ind2];
            //        }
            //    }
            //});
            ////}
            //shortArrayToByteFullContrast(iArr_Coronal, _bArr_ImgResCor);
            //view.DrawInBitmap(ref view.Joy_Coronal, _bArr_ImgResCor, i_Image_Width, i_Image_Height);
            //view.DrawBitmap(view.Joy_Coronal, view.rect_Coronal);
            ////File.WriteAllBytes(@"C:\test\coronal.raw", iArr_Coronal.SelectMany(t => BitConverter.GetBytes(t)).ToArray());
            ////}
        }
    }
    class FlowSagital : FlowLayout_Base
    {
        public FlowSagital() { }
    }
}
