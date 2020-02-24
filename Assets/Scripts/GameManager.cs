using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.MemorySystem;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    [SerializeField]
    Score score;

    public Score Score { get => score; }
    public GameData GameData { get;set; }

   void Awake()
   {       
       if(instance)
       {
           Destroy(gameObject);
       }
       else
       {
           instance = this;
           GameData = new GameData();
       }
       DontDestroyOnLoad(gameObject);
   } 

   public void Save()
   {
       MemorySystem.SaveData(GameData);
   }

   public void Load()
   {
       GameData = MemorySystem.LoadData();
   }

   public void Delete()
   {
       MemorySystem.DeleteData();
   }
   void Start()
   {
       Load();
       Debug.Log(GameData.PlayerPos);
   }
}
