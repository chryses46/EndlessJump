using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{
   public class ButtonController : MonoBehaviour
    {   
        ObstacleFactory obFac;
        [SerializeField] Button startButton;

        void Start()
        {
            obFac = GetComponent<ObstacleFactory>();
        
            startButton.onClick.AddListener(StartGame);
        }


        public void StartGame()
        {
            startButton.gameObject.SetActive(false);
            obFac.SpawnObstacles();
        }
    } 
}

