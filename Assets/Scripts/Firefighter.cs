using System.Collections;
using UnityEngine;

public class Firefighter : MonoBehaviour
{
    [SerializeField]
    private GameObject bugSpray;
    float timer;
    bool isSpraying = true;
    float originalXScale;

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
                bugSpray.transform.localScale = new Vector3(bugSpray.transform.localScale.x - 0.1f, 2,1);
                yield return null;
            }
            if(bugSpray.transform.localScale.x <= 0)
            {
                bugSpray.transform.localScale = new Vector3(0, 2,1);
            }
        }
        else
        {
            while (bugSpray.transform.localScale.x < originalXScale)
            {
                bugSpray.transform.localScale = new Vector3(bugSpray.transform.localScale.x + 0.1f, 2,1);
                yield return null;
            }
            if(bugSpray.transform.localScale.x > originalXScale)
            {
                bugSpray.transform.localScale = new Vector3(originalXScale, 2,1);
            }
        }
    }
}
