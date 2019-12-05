using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public SceneLoader sceneLoader { get; private set; }
    public GameStatus gameStatus { get; private set; }

    [SerializeField] bool isAutoPlay;

    public int breakableBlocks;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        sceneLoader = GetComponent<SceneLoader>();
        gameStatus = GetComponent<GameStatus>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void OnBlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlay;
    }
}
