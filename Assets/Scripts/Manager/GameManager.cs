using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static  GameManager Instance { 
        get { 
                if (instance == null)
                 {
                    instance = new GameObject("GameMananger").AddComponent<GameManager>();
                }
                return instance;
        }

       
    }
    private Enemy enemy;
    public Enemy Enemy { get { return enemy; } set { enemy = value; } }

    private PlayerCondition playerCondition;
    public PlayerCondition PlayerCondition { get { return playerCondition; } set { playerCondition = value; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
