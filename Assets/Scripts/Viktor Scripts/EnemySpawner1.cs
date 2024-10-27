//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Splines;

//public class EnemySpawner : MonoBehaviour
//{
//    private float spawnRate = 2;

//    [SerializeField] private List<GameObject> enemyPrefabs;

//    [SerializeField] private List<GameObject> enemyPrefabs2;

//    [SerializeField] private List<GameObject> enemyPrefabs3;

//    [SerializeField] private GameObject regularNPCPrefab;

//    [SerializeField] private GameObject dogNPCPrefab;

//    [SerializeField] private bool canSpawn = true;

//    private GameObject player;

//    public float spawnTimeMin;

//    public float spawnTimeMax;

//    private void Start()
//    {
//        StartCoroutine(Spawner());
//        player = GameObject.FindGameObjectWithTag("Player");
//    }

//    public void Update()
//    {
//        if (player == null)
//        {
//            canSpawn = false;
//        }

//    }

//    private IEnumerator Spawner()
//    {
//        WaitForSeconds wait = new WaitForSeconds(spawnRate);

//        while (canSpawn)
//        {
//            spawnRate = Random.Range(spawnTimeMin, spawnTimeMax);
//            yield return wait;

//            int randomSplineNumber = Random.Range(0, 3);
//            //int randomSplineNumber = 0;

//            if (randomSplineNumber == 0)
//            {
//                var splines = GameObject.FindGameObjectsWithTag("Spline");
//                if (splines.Length == 0)
//                {
//                    Debug.LogError("No splines found with tag 'Spline'");
//                    continue;
//                }

//                var splineIndexToSpawnOn = Random.Range(0, splines.Length);
//                var splineToSpawnOn = splines[splineIndexToSpawnOn].GetComponent<SplineContainer>();

//                if (splineToSpawnOn == null)
//                {
//                    Debug.LogError("SplineContainer component not found on the selected spline GameObject");
//                    continue;
//                }

//                var randInt = Random.Range(0, 2);


//                if (randInt == 0)
//                {
//                    var spawncoords = new Vector3(0, 0, 10000);
//                    var newNpc = Instantiate(regularNPCPrefab, spawncoords, Quaternion.identity);

//                    var splineAnimateComponent = newNpc.AddComponent<SplineAnimate>();

//                    splineAnimateComponent.Container = splineToSpawnOn;
//                    splineAnimateComponent.Duration = 10;

//                    // Ensure the SplineAnimate component is properly initialized
//                    yield return null;
//                    splineAnimateComponent.Play();
//                } else
//                {
//                    var spawncoords = new Vector3(0, 0, 10000);

//                    var newNpc = Instantiate(dogNPCPrefab, spawncoords, Quaternion.identity);

//                    var dogEnemyNPC = newNpc.transform.GetChild(1);

//                    var splineAnimateComponent = dogEnemyNPC.gameObject.GetComponent<SplineAnimate>();

//                    splineAnimateComponent.Container = splineToSpawnOn;

//                    yield return null;
//                    splineAnimateComponent.Play();

//                    yield return StartCoroutine(waitsecs(1));


//                    var dog = newNpc.transform.GetChild(0);

//                    dog.transform.position = new Vector3(dogEnemyNPC.transform.position.x, dogEnemyNPC.transform.position.y, 0);
//                }

//            }
//            else
//            {
//                int rand = Random.Range(0, enemyPrefabs.Count);
//                GameObject enemyToSpawn = enemyPrefabs[rand];

//                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
//            }
//        }
//    }
//    IEnumerator waitsecs(float seconds)
//    {
//        yield return new WaitForSeconds(seconds);
//    }

//    public void evolveEnemySpawns(int evolutionLevel)
//    {
//        if (evolutionLevel == 1)
//        {
//            foreach (GameObject enemy in enemyPrefabs2)
//            {
//                enemyPrefabs.Add(enemy);
//            }
//        }
//        else if (evolutionLevel == 2)
//        {
//            foreach (GameObject enemy in enemyPrefabs3)
//            {
//                enemyPrefabs.Add(enemy);
//            }
//        }
//        else
//        {
//            return;
//        }
//    }
//}
