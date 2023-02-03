using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;


namespace er03
{
    public class er03_NumeroSette : MonoBehaviour
    {
        er03_PortanumeriController _portaNumeri;

        private void Awake()
        {
            //Setup reference to PortaNumeri
            _portaNumeri = GameObject.Find("er03_PortaNumeri").GetComponent<er03_PortanumeriController>();
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    //detect correct object collision
        //    if (gameObject.tag == "er03_Portanumeri7")
        //    {
        //        //add number if not already present
        //        if (!_portaNumeri.numeriPlayer.Contains(7))
        //        {
        //            _portaNumeri.numeriPlayer.Add(7);
        //            Debug.Log("7 was added");
        //        }


        //    }
        //}

        public void AddNumberToList(int number)
        {
            if (!_portaNumeri.numeriPlayer.Contains(number))
            {
                _portaNumeri.numeriPlayer.Add(number);
                Debug.Log("<color=#A020F0>" + number + "was added </color>");
            }

        }

        public void RemoveNumberFromList(int number)
        {
            _portaNumeri.numeriPlayer.Remove(number);
            Debug.Log("<color=red>" + number + "was removed </color>");

        }

    }
}