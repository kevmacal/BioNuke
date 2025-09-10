using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    bool log = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el collider est� en un hijo del Player, tambi�n lo detecta
        var player = other.GetComponentInParent<PlayerController>();
        if (player == null)
        {
            if (log) Debug.Log($"KillZone: entr� {other.name} pero no es el jugador.", other);
            return;
        }

        if (log) Debug.Log($"KillZone: �jugador detectado a trav�s de {other.name}!", other);

        
    }
}
