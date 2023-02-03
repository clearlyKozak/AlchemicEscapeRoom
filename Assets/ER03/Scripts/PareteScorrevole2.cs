using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;

namespace er03
{

    public class PareteScorrevole2 : MonoBehaviour
    {
        public Animator _muroscorrevole2;
        
        public AudioSource _muro2;

        private void OnTriggerEnter(Collider target)

        {
            if (target.tag == "er03triggerporta2")
            {
                _muroscorrevole2.SetBool("Chiave11", true);
                _muro2.Play();
                //Destroy(_gameobject, 1.0f);

            }




        }
        // Start is called before the first frame update
        void Start()
        {
            _muroscorrevole2 = this.transform.parent.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}