using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject Jug1;

    void Update()
    {
        if (Jug1 != null)
        {
            Vector3 position = transform.position;
            position.x = Jug1.transform.position.x;
            transform.position = position;
        }
    }
}
