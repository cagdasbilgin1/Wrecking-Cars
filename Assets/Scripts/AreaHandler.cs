using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHandler : MonoBehaviour
{
    [SerializeField] GameObject GreenCircle;
    List<int> targetPositions = new List<int>();

    void Awake()
    {
        AssignRandomOriginValuesToList();
    }    

    void FixedUpdate()
    {
        if (Time.time > 135 && transform.localScale.x >= 100)
        {
            SetAreaOriginPoint(targetPositions[8], targetPositions[9], .01f);
            SetAreaSize(100, .2f);
        }
        else if (Time.time > 105 && transform.localScale.x >= 150)
        {
            SetAreaOriginPoint(targetPositions[6], targetPositions[7], .01f);
            SetAreaSize(150, .2f);
        }
        else if (Time.time > 75 && transform.localScale.x >= 200)
        {
            SetAreaOriginPoint(targetPositions[4], targetPositions[5], .01f);
            SetAreaSize(200, .2f);
        }
        else if (Time.time > 45 && transform.localScale.x >= 250)
        {
            SetAreaOriginPoint(targetPositions[2], targetPositions[3], .01f);
            SetAreaSize(250, .2f);
        }
        else if (Time.time > 15 && transform.localScale.x >= 300)
        {
            SetAreaOriginPoint(targetPositions[0], targetPositions[1], .01f);
            SetAreaSize(300, .2f);
        }
    }

    void SetAreaOriginPoint(int x, int z, float speed)
    {
        GreenCircle.SetActive(true);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, 0, z), speed);
        GreenCircle.transform.position = new Vector3(x, 0.01f, z);
    }

    void SetAreaSize(int areaSize, float speed)
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(areaSize, areaSize, areaSize), speed);
        GreenCircle.transform.localScale = new Vector3(areaSize * 0.2f, .2f, areaSize * 0.2f);
    }

    void AssignRandomOriginValuesToList()
    {
        int limit = 5;
        for (int i = 0; i < 11; i++)
        {
            targetPositions.Add(Random.Range(-limit, limit));
            if (i % 2 == 0)
            {
                limit--;
            }
        }
    }

    public List<int> GetOriginValues()
    {
        return targetPositions;
    }
}
