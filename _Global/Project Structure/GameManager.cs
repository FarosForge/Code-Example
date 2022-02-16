using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLOBAL
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] LevelList levelList;

        private LevelManager levelManager;

        void Start()
        {
            levelManager = new LevelManager(levelList);
            levelManager.Init();
        }

        void Update()
        {
            levelManager.Tik();
        }
    }
}
