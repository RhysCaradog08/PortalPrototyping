using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    bool playerOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if(playerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.forward, portalToPlayer);

            Debug.Log("Dot Product: " + dotProduct);

            if(dotProduct <0)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0, rotationDiff, 0) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                playerOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOverlapping = false;
        }
    }
}
