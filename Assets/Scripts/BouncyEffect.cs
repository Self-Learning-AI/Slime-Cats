using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyEffect : MonoBehaviour
{
     public float maxSize;
     public float scaleSpeed;
     public float delay;
 
     void Start()
     {
         StartCoroutine(Scale());
     }
 
     public IEnumerator Scale()
     {
         float timer = 0;

        // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.y)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime * scaleSpeed;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(delay);

            timer = 0;
            while (1 < transform.localScale.y)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(0, 1, 0) * Time.deltaTime * scaleSpeed;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(delay);
        }
     }
}
