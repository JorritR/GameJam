using System.Collections;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float wanderRange;

    private GameObject dog;
    private GameObject npc;

    void Start()
    {
        dog = transform.GetChild(0).gameObject;
        npc = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float randomTargetX = Random.Range(npc.transform.position.x - wanderRange, npc.transform.position.x + wanderRange);
        float randomTargetY = Random.Range(npc.transform.position.y - wanderRange, npc.transform.position.y + wanderRange);
        Vector3 randomTargetPosition = new Vector3(randomTargetX, randomTargetY, 0);

        Vector3 currentPosition = dog.transform.position;

        dog.transform.position = Vector3.MoveTowards(currentPosition, randomTargetPosition, 0.1f);
    }


}
