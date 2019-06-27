using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ObstacleFactory : MonoBehaviour
    {
        
        public List<GameObject> obstacles = new List<GameObject>();
        [SerializeField] Text gameOverText;
        
        Camera mainCam;

        Vector2 startPos = new Vector2 (1.3f,.1f);
        Vector2 endPos = new Vector2 (-1.3f, .1f);
        void Awake()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        public void SpawnObstacles()
        {
            Vector2 objSpawn = mainCam.ViewportToWorldPoint(startPos); //convert viewport 1,1 to world space (mobile responsive)
            Vector2 objectDeSpawn = mainCam.ViewportToWorldPoint(endPos); //convert viewport 1,1 to world space (mobile responsive)

            GameObject obstacle = Instantiate(obstacles[0], objSpawn, Quaternion.identity); // create object
            obstacle.GetComponent<DeathZone>().gameOverText = gameOverText;
            StartCoroutine(MoveObject(obstacle, objectDeSpawn));
        }

        IEnumerator MoveObject(GameObject obstacle, Vector2 dest)
        {
            
            var t = 0f;
            var origPos = obstacle.transform.position;

            while(t<1)
            {
                obstacle.transform.position = new Vector2 (Mathf.Lerp(origPos.x, dest.x, t), 0);
                t+= .02f; // lower = slower
                yield return new WaitForSeconds(.1f); // lower = faster

            }

            // repeats the process
            SpawnObstacles();

            Destroy(obstacle);
        }
    }
}