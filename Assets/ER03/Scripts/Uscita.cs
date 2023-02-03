using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uscita : MonoBehaviour
{
    public Animator porteuscita;
    public AudioSource _uscitaaudio;
    

    private void OnTriggerEnter(Collider target)

    {
        if (target.tag == "er03triggerporta3")
        {
            porteuscita.SetBool("er03Chiaveuscita", true);
            _uscitaaudio.Play();
            //Destroy(_gameobject, 1.0f);

        }




    }
    // Start is called before the first frame update
    void Start()
    {
        porteuscita = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
