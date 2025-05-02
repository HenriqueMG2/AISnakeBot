using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIBehaviours/PlayerbotAuto")]
public class PlayerbotAuto : AIBehaviour
{
    public float rotationSpeed = 5f;
    public float detectionRadius = 30f;
    public float fleeDistance = 10f;

    private Transform targetOrb;
    private Vector3 randomPoint;
    private Vector3 direction;

    private Vector3 fleeForce;

    public override void Init(GameObject own, SnakeMovement ownMove)
    {
        base.Init(own, ownMove);
        ChooseRandomPoint();
        ownerMovement.StartCoroutine(UpdateDirEveryXSeconds(3f));
    }

    public override void Execute()
    {
        FindClosestOrb();
        EvaluateOtherSnakes();

        Vector3 finalDir = Vector3.zero;

        // FUGIR > IR PARA ORB > MOVER ALEATÓRIO
        if (fleeForce.magnitude > 0.1f)
        {
            finalDir = fleeForce.normalized;
        }
        else if (targetOrb != null)
        {
            finalDir = (targetOrb.position - owner.transform.position).normalized;
        }
        else
        {
            finalDir = (randomPoint - owner.transform.position).normalized;
        }

        MoveInDirection(finalDir);

        // Novo ponto se chegou perto do aleatório
        if (targetOrb == null && fleeForce.magnitude == 0)
        {
            if (Vector2.Distance(owner.transform.position, randomPoint) < 0.5f)
            {
                ChooseRandomPoint();
            }
        }
    }

    void MoveInDirection(Vector3 dir)
    {
        Vector3 newPos = owner.transform.position + dir * ownerMovement.speed * Time.deltaTime;
        owner.transform.position = newPos;

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void ChooseRandomPoint()
    {
        randomPoint = new Vector3(
            Random.Range(owner.transform.position.x - 10f, owner.transform.position.x + 10f),
            Random.Range(owner.transform.position.y - 10f, owner.transform.position.y + 10f),
            0f
        );
        direction = randomPoint - owner.transform.position;
        direction.z = 0f;
    }

    IEnumerator UpdateDirEveryXSeconds(float x)
    {
        while (true)
        {
            yield return new WaitForSeconds(x);
            if (targetOrb == null && fleeForce.magnitude == 0)
            {
                ChooseRandomPoint();
            }
        }
    }

    void FindClosestOrb()
    {
        GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
        float closestDist = Mathf.Infinity;
        targetOrb = null;

        foreach (GameObject orb in orbs)
        {
            float dist = Vector3.Distance(owner.transform.position, orb.transform.position);
            if (dist < closestDist && dist <= detectionRadius)
            {
                closestDist = dist;
                targetOrb = orb.transform;
            }
        }
    }

    void EvaluateOtherSnakes()
    {
        fleeForce = Vector3.zero;

        SnakeMovement[] allSnakes = GameObject.FindObjectsOfType<SnakeMovement>();
        foreach (var snake in allSnakes)
        {
            if (snake == ownerMovement || snake.isDead) continue;

            float dist = Vector3.Distance(owner.transform.position, snake.transform.position);
            if (dist > detectionRadius) continue;

            if (dist < fleeDistance)
            {
                Vector3 diff = owner.transform.position - snake.transform.position;
                fleeForce += diff.normalized / dist; // steering behavior: quanto mais perto, mais forte foge
            }
        }
    }
}
