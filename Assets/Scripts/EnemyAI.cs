using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public bool roaming = true;
    public Seeker seeker;
    Path path;

    void CaculatePath()
    {
        Vector2 target = FindTarget();
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        if(roaming == true)
        {
            return (Vector2)playerPos + (Random.Range(10f,50f) * new Vector2(Random.Range(-1,1),Random.Range(-1,1)).normalized);
        }
        else
        {
            return playerPos;
        }
    }
}
