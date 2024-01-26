using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public Transform playerTrans;
    public float moveSpeed = 3.0f;

    private void Update()
    {
        // Ensure the playerTrans is not null before attempting to follow.
        if (playerTrans != null)
        {
            // Calculate the direction from the monster to the player.
            Vector3 directionToPlayer = playerTrans.position - transform.position;

            // Normalize the direction to get a unit vector.
            Vector3 normalizedDirection = directionToPlayer.normalized;

            // Calculate the rotation to face the player.
            Quaternion lookRotation = Quaternion.LookRotation(normalizedDirection);

            // Rotate the monster towards the player smoothly.
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);

            // Move the monster forward in the direction of the player.
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
