using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Photon.Pun;


public class BaseCamp : MonoBehaviour
{
    public int value;
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        if (other.CompareTag("Player"))
        {
            PlayerController player = GameManager.instance.GetPlayer(other.gameObject);
            player.photonView.RPC("Heal", player.photonPlayer, value);
            Debug.Log("healing...");
        }
    }
}