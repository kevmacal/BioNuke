using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectManager;
    [SerializeField]
    float zombieVel;

    GameManager GManager;
    GameObject PlayerObject;
    private float distance;
    private int objectiveDirection = 0;
    Rigidbody2D ZombieRigidbody;
    private Vector2 direction = Vector2.right;
    //PlayerController Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GManager=ObjectManager.GetComponent<GameManager>();
        ZombieRigidbody = GetComponent<Rigidbody2D>();
        PlayerObject = GManager.PlayerObject;
        //Player=GManager.GetComponent<PlayerController>();
        //Debug.Log(PlayerObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(PlayerObject.transform.position.x - this.transform.position.x);        
        if (this.transform.position.x>PlayerObject.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            objectiveDirection = -1;
            //direction = Vector2.left;
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            objectiveDirection = 1;
            //direction = Vector2.right;
        }
        if (distance<1)
        {
            if (objectiveDirection==1)
            {
                SetDirection(Vector2.right);
            }
            else
            {
                SetDirection(Vector2.left);
            }
        }
        else
        {
            SetDirection(Vector2.zero);
        }
    }
    void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
        //Debug.Log("SetDirection");
    }
    private void FixedUpdate()
    {
        Vector2 posTmp = ZombieRigidbody.position;
        Vector2 translation = direction * zombieVel * Time.fixedDeltaTime;

        ZombieRigidbody.MovePosition(posTmp + translation);
    }
}
