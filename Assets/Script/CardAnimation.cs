using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public IEnumerator sposta(Vector3 goal)
    {
        goal = goal + new Vector3(0f, 0.3f, 0f);
        while (goal != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator rimetti(Vector3 goal)
    {
        goal = goal + new Vector3(0f, -9f, 0f);
        while (goal != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, 88f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
