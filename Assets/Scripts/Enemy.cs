using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }

    // A bool variable to prevent multiple collisions with the player
    private bool debounce = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null && !debounce && player.Health > 0)
        {
            debounce = true;
            player.Health -= 1;
            Debug.Log($"Player health: {player.Health}");

            if (player.Health < 0 )
            {
                player.Health = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            debounce = false;
        }
    }
}
