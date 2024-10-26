using System.Collections;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float wanderRange;

    private GameObject dog;
    private GameObject npc;

    private Vector3 targetPosition;

    void Start()
    {
        dog = transform.GetChild(0).gameObject;
        npc = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(dog == null || npc == null)
        {
            return;
        }
        if (targetPosition == null || targetPosition == Vector3.zero)
        {
            float randomTargetX = Random.Range(npc.transform.position.x - wanderRange, npc.transform.position.x + wanderRange);
            float randomTargetY = Random.Range(npc.transform.position.y - wanderRange, npc.transform.position.y + wanderRange);
            targetPosition = new Vector3(randomTargetX, randomTargetY, 0);
        }

        Vector3 currentPosition = dog.transform.position;

        dog.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, 0.13f);
        dog.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - currentPosition);

        if (Vector3.Distance(currentPosition, targetPosition) < 0.1f)
        {
            targetPosition = Vector3.zero;
        }
    }


}
