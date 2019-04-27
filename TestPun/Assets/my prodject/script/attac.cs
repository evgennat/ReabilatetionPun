using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class attac : MonoBehaviour {
    public float hp= 100f;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cartridge")
        {
            hp -= 30f;
        }
    }

}
