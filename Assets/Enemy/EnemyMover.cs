using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach(Waypoint waypoint in path) 
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            while (travelPercent < 1f)
            {
                float rotationBoost = 4.5f;
                float rotationSpeed = speed + rotationBoost;
                // == Smoothly rotate towards the target point. ==
                var targetRotation = Quaternion.LookRotation(endPosition - startPosition);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                // == ~Smoothly rotate towards the target point. ==

                // == Smooth travel between tiles ==
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                // == ~Smooth travel between tiles ==
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
    
}
