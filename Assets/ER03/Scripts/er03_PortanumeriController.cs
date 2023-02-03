using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;
using System.Linq;


namespace er03
{
    public class er03_PortanumeriController : MonoBehaviour
    {

        List<int> numeriCorretti = new List<int>() { 0, 1 ,7 } ; 

        public List<int> numeriPlayer = new List<int>();

        public bool listsAreEqual;

        public GameObject forceField;

        public bool shutDownForceField = false;

        private void Awake()
        {
            if(forceField==null)
            {
                forceField = GameObject.Find("Forcefield");
            }
            Debug.Log(forceField.name);
        }

        private void Start()
        {
            foreach (var x in numeriCorretti)
            {
                Debug.Log("Correct items: " + x.ToString());
            }

            forceField = GameObject.Find("Forcefield");
        }


        private void Update()
        {
            //Chech if player selected 3 numbers and check correctness

            if (numeriPlayer.Count >= 3)
            {
                CheckList();
            }

            if (shutDownForceField==true) 
            {
                
                forceField.SetActive(false);

            }
        }

        private void CheckList()
        {
            //perform correctness check for position and number

            bool areEqual = numeriPlayer.SequenceEqual(numeriCorretti);

            if (areEqual)
            {
                Debug.Log("<color=green> Lists are equal </color>");
                //Shut down force field
                forceField.SetActive(false);
            }
            else
            {
                Debug.Log("<color=red> Lists are NOT equal </color>");
                numeriPlayer.Clear();
            }



            //for (var i = 0; i < numeriCorretti.Count; i++)
            //{
            //    if (numeriPlayer[i] != numeriCorretti[i])
            //    {
            //        listsAreEqual = false;
            //        Debug.Log("Lists are NOT equal " + listsAreEqual);
            //        //reset player list
            //        numeriPlayer.Clear();
            //    }
            //    else
            //    {
            //        listsAreEqual = true;
            //        Debug.Log("Lists are equal " + listsAreEqual);
            //        //spawn key
            //    }
            //}

        }


    }

}
