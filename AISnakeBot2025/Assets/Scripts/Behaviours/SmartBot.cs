using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "AIBehaviours/SmartBot")]
public class SmartBot : AIBehaviour
{
    public float perceptionRadius = 10f;
    public float dangerRadius = 5f;

    public override void Init(GameObject own, SnakeMovement ownMove)
    {
        base.Init(own, ownMove);
        ownerMovement.speed = 3.5f;
    }

    public override void Execute()
    {
        // Desenhar os círculos de percepção e perigo para visualização
        DrawDebugCircles();

        // Estado de maior prioridade: SeekOrb
        GameObject closestOrb = FindClosestObjectWithTag("Orb", perceptionRadius);
        if (closestOrb != null)
        {
            MoveToTarget(closestOrb.transform.position);
            return;
        }

        // Estado intermediário: Flee
        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            FleeFrom(closestEnemy.transform.position);
            return;
        }

        // Estado de menor prioridade: Wander
        Wander();
    }

    void DrawDebugCircles()
    {
        // Usar Debug.DrawLine para desenhar um círculo no plano XY
        int segments = 40;
        float angle = 0f;
        Vector3 prevPoint;

        // Círculo perceptionRadius (cor verde)
        prevPoint = owner.transform.position + new Vector3(Mathf.Cos(0) * perceptionRadius, Mathf.Sin(0) * perceptionRadius, 0);
        for (int i = 1; i <= segments; i++)
        {
            angle = i * 2 * Mathf.PI / segments;
            Vector3 nextPoint = owner.transform.position + new Vector3(Mathf.Cos(angle) * perceptionRadius, Mathf.Sin(angle) * perceptionRadius, 0);
            Debug.DrawLine(prevPoint, nextPoint, Color.green);
            prevPoint = nextPoint;
        }

        // Círculo dangerRadius (cor vermelha)
        prevPoint = owner.transform.position + new Vector3(Mathf.Cos(0) * dangerRadius, Mathf.Sin(0) * dangerRadius, 0);
        for (int i = 1; i <= segments; i++)
        {
            angle = i * 2 * Mathf.PI / segments;
            Vector3 nextPoint = owner.transform.position + new Vector3(Mathf.Cos(angle) * dangerRadius, Mathf.Sin(angle) * dangerRadius, 0);
            Debug.DrawLine(prevPoint, nextPoint, Color.red);
            prevPoint = nextPoint;
        }
    }

    GameObject FindClosestObjectWithTag(string tag, float radius)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject obj in objs)
        {
            float dist = Vector3.Distance(owner.transform.position, obj.transform.position);
            if (dist < radius && dist < minDist)
            {
                minDist = dist;
                closest = obj;
            }
        }

        return closest;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] snakes = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject snake in snakes)
        {
            if (snake == owner) continue;

            float dist = Vector3.Distance(owner.transform.position, snake.transform.position);
            if (dist < dangerRadius && dist < minDist)
            {
                minDist = dist;
                closest = snake;
            }
        }

        return closest;
    }

    void MoveToTarget(Vector3 target)
    {
        Vector3 dir = (target - owner.transform.position).normalized;
        RotateTowards(dir);
        owner.transform.position += dir * ownerMovement.speed * Time.deltaTime;
    }

    void FleeFrom(Vector3 threat)
    {
        Vector3 dir = (owner.transform.position - threat).normalized;
        RotateTowards(dir);
        owner.transform.position += dir * ownerMovement.speed * Time.deltaTime;
    }

    void Wander()
    {
        if ((randomPoint - owner.transform.position).magnitude < 1f)
        {
            PickRandomPoint();
        }

        Vector3 dir = (randomPoint - owner.transform.position).normalized;
        RotateTowards(dir);
        owner.transform.position += dir * ownerMovement.speed * Time.deltaTime;
    }

    void PickRandomPoint()
    {
        float range = 10f;
        randomPoint = new Vector3(
            Random.Range(owner.transform.position.x - range, owner.transform.position.x + range),
            Random.Range(owner.transform.position.y - range, owner.transform.position.y + range),
            0
        );
    }

    void RotateTowards(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, rotation, ownerMovement.speed * Time.deltaTime);
    }
}