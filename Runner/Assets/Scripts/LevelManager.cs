using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Level System")]
    private int whichlevel = 0;
    [SerializeField] public List<ScriptableObject> levels = new List<ScriptableObject>();

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        whichlevel = PlayerPrefs.GetInt("whichlevel");

        if (PlayerPrefs.GetInt("randomlevel") > 0)
        {
            whichlevel = Random.Range(0, levels.Count);
        }

        //Instantiate(levels[whichlevel].levelPrefab, Vector3.zero, Quaternion.identity);
    }

    public void NextLevel()
    {
        whichlevel++;
        PlayerPrefs.SetInt("whichlevel", whichlevel);
        if(whichlevel >= levels.Count)
        {
            whichlevel--;
            PlayerPrefs.SetInt("randomlevel", 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame

    public int WhichLevel()
    {
        return whichlevel;
    }
    void Update()
    {
        
    }
}
