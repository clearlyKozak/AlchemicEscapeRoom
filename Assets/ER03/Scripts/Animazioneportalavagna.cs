using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;


namespace er03
{
    public class Animazioneportalavagna : MonoBehaviour
    {

        public Animator _paretiscorrevoli;
        public AudioSource _muro1;



        void Start()
        {
            _paretiscorrevoli = this.transform.parent.GetComponent<Animator>();

        }

        private void OnTriggerEnter(Collider target)

        {
            if (target.tag == "er03triggerporta")
            {
                _paretiscorrevoli.SetBool("Chiave", true);
                _muro1.Play();

            }



        }

        //public void AttivaAnimazionePorta()
        //{
        //    _paretiscorrevoli.SetBool("Chiave", true);
        //}


    }
}