using System.Collections;
using UnityEngine;
using er03;

namespace er03
{
    public class PourDetectorRed : MonoBehaviour
    {
        [Header("Put in bottle game object")]

        public int pourThreshold = 45;
        public Transform origin = null;
        public GameObject streamPrefab = null;
        public AudioSource _liquidoRed;

        //keep track of pouring
        private bool isPouring = false;
        //keep track of current stream
        private RedStream currentStream = null;


        private void Update()
        {

            bool pourCheck = CalculatePourAngle() < pourThreshold;

            if (isPouring != pourCheck)
            {
                //aplly new value to isPouring to execute code
                isPouring = pourCheck;
                if (isPouring)
                {
                    StartPour();
                    _liquidoRed.Play();
                }
                else
                {
                    EndPour();
                    _liquidoRed.Stop();
                }
            }
        }

        private void StartPour()
        {
            print("Start");
            currentStream = CreateStream();
            currentStream.Begin();
        }

        private void EndPour()
        {
            print("End");
            currentStream.End();
            currentStream = null;
        }

        private float CalculatePourAngle()
        {
            //The transform depends on the mesh itself
            return transform.forward.y * Mathf.Rad2Deg;
        }

        private RedStream CreateStream()
        {
            GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);

            return streamObject.GetComponent<RedStream>();
        }



    }
}