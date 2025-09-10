using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    bool log = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el collider está en un hijo del Player, también lo detecta
        var player = other.GetComponentInParent<PlayerController>();
        if (player == null)
        {
            if (log) Debug.Log($"KillZone: entró {other.name} pero no es el jugador.", other);
            return;
        }

        if (log) Debug.Log($"KillZone: ¡jugador detectado a través de {other.name}!", other);

        
    }
}
