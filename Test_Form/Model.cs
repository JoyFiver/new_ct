using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Form
{
    public class Model
    {
        // propfull +  2tab

        private int I_PosTrackAx, I_PosTrackCor, I_PosTrackSag, NFileDaLeggere = 800, NImmCorSag = 800;
        float ThetaAx = 0, ThetaCor = 0, ThetaSag = 0;
        public int i_PosTrackAx
        {
            get { return I_PosTrackAx; }
            set { I_PosTrackAx = value; }
        }
        public int i_PosTrackCor
        {
            get { return I_PosTrackCor; }
            set { I_PosTrackCor = value; }
        }
        public int i_PosTrackSag
        {
            get { return I_PosTrackSag; }
            set { I_PosTrackSag = value; }
        }
        public int nFileDaLeggere
        {
            get { return NFileDaLeggere; }
            set { NFileDaLeggere = value; }
        }
        public int nImmCorSag
        {
            get { return NImmCorSag; }
            set { NImmCorSag = value; }
        }

        public float thetaAx { get => ThetaAx; set => ThetaAx = value; }
        public float thetaCor { get => ThetaCor; set => ThetaCor = value; }
        public float thetaSag { get => ThetaSag; set => ThetaSag = value; }


    }
}
