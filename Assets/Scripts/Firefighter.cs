using System.Collections;
using UnityEngine;

public class Firefighter : MonoBehaviour
{
    [SerializeField]
    private GameObject bugSpray;
    float timer;
    bool isSpraying = true;
    float originalXScale;
    float originalYScale;
    float originalZScale;

    void Start()
    {
        originalXScale = bugSpray.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            timer = 0;
            if(isSpraying)
            {
                isSpraying = false;
                StartCoroutine(ScaleSpray(true));
            } else
            {
                isSpraying = true;
                StartCoroutine(ScaleSpray(false));
            }

        }
    }

    IEnumerator ScaleSpray(bool scaleDown)
    {
        if (scaleDown)
        {
            while (bugSpray.transform.localScale.x > 0)
            {
                bugSpray.transform.localScale = new Vector3(bugSpray.transform.localScale.x - 0.1f, bugSpray.transform.localScale.y, bugSpray.transform.localScale.z);
                yield return null;
            }
            if(bugSpray.transform.localScale.x <= 0)
            {
                bugSpray.transform.localScale = new Vector3(0, originalYScale, originalZScale);
            }
        }
        else
        {
            while (bugSpray.transform.localScale.x < originalXScale)
            {
                bugSpray.transform.localScale = new Vector3(bugSpray.transform.localScale.x + 0.1f, bugSpray.transform.localScale.y, bugSpray.transform.localScale.z);
                yield return null;
            }
            if(bugSpray.transform.localScale.x > originalXScale)
            {
                bugSpray.transform.localScale = new Vector3(originalXScale, originalYScale, originalZScale);
            }
        }
    }
}
