using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class hp : MonoBehaviourPunCallbacks  {
    public float hpplayer = 100f;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            hpplayer -= 30f;
        }
    }

   
}
