using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;


namespace er03
{
    public class er03_NumeroZero : MonoBehaviour
    {
        er03_PortanumeriController _portaNumeri;

        private void Awake()
        {
            //Setup reference to PortaNumeri
            _portaNumeri = GameObject.Find("er03_PortaNumeri").GetComponent<er03_PortanumeriController>();
        }

        public void AddNumberToList(int number)
        {
            if (!_portaNumeri.numeriPlayer.Contains(number))
            {
                _portaNumeri.numeriPlayer.Add(number);
                Debug.Log("<color=#A00F0>" + number + "was added </color>");
            }

        }

        public void RemoveNumberFromList(int number)
        {
            _portaNumeri.numeriPlayer.Remove(number);
            Debug.Log("<color=red>" + number + "was removed </color>");

        }

    }
}

