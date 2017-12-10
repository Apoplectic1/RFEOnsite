using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;

namespace RFE_OnSite
{
    class Media
    {
        VideoCapture mCapture;
        bool mPauseCapture = false;

        public bool CaptureImageAtLocationMarker()
        {
            if (mCapture == null)
            {
                mCapture = new VideoCapture();
            }

            Mat mat = new Mat();

            mCapture.Read(mat);

            //EmGuImageBox = 



            //CameraCaptureUI captureUI = new CameraCaptureUI();
            //captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            //captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            //StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            //if (photo == null)
            //{
            //    // User cancelled photo capture
            //    return;
            //}
            return true;
        }
    }
}
