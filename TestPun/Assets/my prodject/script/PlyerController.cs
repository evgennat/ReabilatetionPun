using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlyerController : MonoBehaviourPunCallbacks {
    public Vector3 vect;
    public Quaternion playrqit;
    [PunRPC]
    public static bool follow = false;
    public GameObject player;
    public List<GameObject> camers = new List<GameObject>();
    public GameObject[] gameObjects ;
    public float speed = 40f;
    public GameObject camerstime;
    private bool onbutton = false;
    

    // Use this for initialization
    void Start () {
       
    }
   
    
    public void OnFollow() {
        
        if(player == null)
        {
            player = GameObject.FindWithTag("Patient");
        }
        if (follow == false && onbutton == false)
        {
            Debug.Log("button work");
            follow = true;

        }
       

    }
    
	
	// Update is called once per frame
	void Update () {

        
        
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        for(int i = 0; i< GameObject.FindGameObjectsWithTag("Camers").Length; i++)
        {
            if (camerstime == null )
            {
                camerstime = GameObject.FindGameObjectWithTag("Camers");
                camerstime.SetActive(false);
                camerstime.tag = null;
                camerstime = null;



            } 
            
            
        }
        
        if (player != null && follow == true)
        {
            gameObject.transform.position = player.transform.position;
            gameObject.transform.rotation = player.transform.rotation ;
        }
        if (Input.GetKey(KeyCode.H))
        {
             gameObject.transform.rotation = new Quaternion(0,0,0,0);
        }
        if (Input.GetKey(KeyCode.W)) //Если нажать W 
        {
            gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            gameObject.transform.position -= gameObject.transform.forward * speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= gameObject.transform.right * speed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += gameObject.transform.right * speed * Time.deltaTime;  
        }
        if (Input.GetKey(KeyCode.H))
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
