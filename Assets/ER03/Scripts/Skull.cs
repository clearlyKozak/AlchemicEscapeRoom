using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using UnityEngine;
using er03;

namespace er03 
{
    public class Skull : MonoBehaviour
    {
        public GameObject chiave;
        public ParticleSystem _keyPop;

        private void Start()
        {
            print("Start");
        }

        private void OnCollisionEnter(Collision collision)
        {
            print(collision.gameObject.tag);
            if (collision.gameObject.CompareTag("FireableArrow"))
            {
                _keyPop.Play();
                chiave.SetActive(true);
                Destroy(gameObject);
            }
        }



        //public GameObject chiave;

        //void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.tag == "freccia")
        //    {
        //        Destroy(gameObject);
        //    }

        //}
    }
}

