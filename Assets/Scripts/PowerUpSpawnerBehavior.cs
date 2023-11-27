using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerBehavior : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject powerUp;
    public GameObject newPowerUp; // current new power up to be added to the GameObject List
    public List<GameObject> powerUpObjects;
    Vector3 spawnPosition;
    float randX;
    float randY;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreateObject()
    {
        while (true)
        {
            if (powerUpObjects.Count < 2)
            {
                randX = Random.Range(-3, 3);
                randY = Random.Range(-3, 3);
                
                spawnPosition = new Vector3(gameObject.transform.position.x + randX, gameObject.transform.position.y +  randY);
                Debug.Log($"power up position: {randX}, {randY}");
                
                newPowerUp = Instantiate(powerUp, spawnPosition, Quaternion.Euler(0,0,0));
                powerUpObjects.Add(newPowerUp);
            }
            else
            {
                Debug.Log("too many power ups");
            }
            yield return new WaitForSeconds(30);
            powerUpObjects.Remove(newPowerUp);
        }
        
    }

}
