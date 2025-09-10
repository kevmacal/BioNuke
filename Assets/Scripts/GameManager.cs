using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    GameObject Player;

    private PlayerController Jug1;

    private float timer = 0f;

    private void Start()
    {
        Jug1 = Player.GetComponent<PlayerController>();
    }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("GameManager"+timer);
    }

    public string TimeString => TimeSpan.FromSeconds(timer).ToString(@"mm\:ss");
    public void ResetTimer() => timer = 0f;

    public void OnBossDefeated()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(i + 1);
    }

    public GameObject PlayerObject { get { return Player; } }

    public void LoadLevelByName(string sceneName) { ResetTimer(); SceneManager.LoadScene(sceneName); }
}
