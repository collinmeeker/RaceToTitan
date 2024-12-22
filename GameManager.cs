using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player; 
    private int currentLevel = 1;
    private Dictionary<string, List<GameObject>> levelObjects = new Dictionary<string, List<GameObject>>();
    private Dictionary<string, GameObject> messageObjects = new Dictionary<string, GameObject>();
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();
    public AudioSource explosionSound;
    public GameOverUIManager gameover;


    private Coroutine levelTimer;
    void Start()
    {
        
        
        explosionSound = GetComponent<AudioSource>();
        explosionSound.playOnAwake = false;

      


        CacheLevelObjects();
        levelTimer = StartCoroutine(LevelCountdown(30));  // 30 seconds countdown
        InitializeGame();
    }

  


    public int getCurrentLevel() { 
    
        return currentLevel; 
    
    }

    public void HandlePlayerDeath(GameObject playerObject)
    {
        
            explosionSound.Play();
            StartCoroutine(PlayerDeathRoutine(playerObject));
        
    }

    private IEnumerator PlayerDeathRoutine(GameObject playerObject)
    {
     
        playerObject.SetActive(false);
        yield return new WaitForSeconds(2);
        playerObject.SetActive(true);

        
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.lives--;
            Debug.Log("Lives Left: " + playerController.lives);
            if (playerController.lives <= 0)
            {
                
                playerController.GameOver();
                gameover.ShowGameOver();
            }
            else
            {
                Debug.Log("Restarting Level");
                RestartLevel();
            }
        }
        
    }
    private void CacheLevelObjects()
    {
        // loop through every object
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            // check to see if they are a level object
            if (obj.tag.StartsWith("Level"))
            {
                AddToLevelObjectsDictionary(obj);
            }
            //check for the message object
            else if (obj.tag.StartsWith("Mess"))
            {
                AddToMessageObjectsDictionary(obj);
            }
        }

        // activate first level
        ActivateLevelObjects("Level" + currentLevel);
    }

    // Helper method to add level objects to the dictionary and handle their initial state
    private void AddToLevelObjectsDictionary(GameObject obj)
    {
        if (!levelObjects.TryGetValue(obj.tag, out List<GameObject> list))
        {
            list = new List<GameObject>();
            levelObjects[obj.tag] = list;
        }
        list.Add(obj);
        originalPositions[obj] = obj.transform.position; // Store original position
        obj.SetActive(false); // Deactivate the object initially
        Debug.Log("Caching level object with tag: " + obj.tag + " - " + obj.name);
    }

    // Helper method to add message objects to their dictionary
    private void AddToMessageObjectsDictionary(GameObject obj)
    {
        if (!messageObjects.ContainsKey(obj.tag))
        {
            messageObjects[obj.tag] = obj;
            originalPositions[obj] = obj.transform.position; // Store original position
            obj.SetActive(false); // Deactivate the object initially
            Debug.Log("Caching message object with tag: " + obj.tag + " - " + obj.name);
        }
        else
        {
            Debug.LogWarning("Duplicate message object with tag: " + obj.tag + " ignored.");
        }
    }



    private IEnumerator LevelCountdown(float waitTime)
    {
        while (true)
        {
            // Wait for the specified amount of time
            yield return new WaitForSeconds(waitTime);

            // Change to the next level
            ChangeLevel();
        }
    }

    public void RestartLevel()
    {
        DeactivateLevelObjects("Level" + currentLevel);
        StartCoroutine(RestartLevelSequence());
        StopTimer();
        StartTimer();


    }

    public void StartTimer() {
        if (levelTimer == null) { 
            levelTimer = StartCoroutine(LevelCountdown(30));
        }
    
    }

    public void StopTimer() {
        if (levelTimer != null) { 
            StopCoroutine(levelTimer);
            levelTimer = null;
        }
    
    }

    private IEnumerator RestartLevelSequence()
    {
        // Optionally display a message or handle other UI feedback
        yield return StartCoroutine(DisplayLevelMessage("Mess" + currentLevel));

        // Reactivate the level objects
        ActivateLevelObjects("Level" + currentLevel);

        
    }

   

    private void LoadOutroScene()
    {
        SceneManager.LoadScene("OutroScene");
    }
    private void ChangeLevel()
    {
        if (currentLevel >= 10 && player.activeSelf) { //if player is alive after Level 10 they win
            Invoke("LoadOutroScene", 10f);
        }

        // Deactivate the current level objects
        DeactivateLevelObjects("Level" + currentLevel);

        // Increment the level
        currentLevel++;

        // Start the coroutine to display the level message and then activate level objects
        StartCoroutine(DisplayLevelMessage("Mess" + currentLevel));
    }

    private IEnumerator DisplayLevelMessage(string messageTag)
    {
        Debug.Log("Displaying message for tag: " + messageTag);

        // Find the message object
        if (messageObjects.ContainsKey(messageTag))
        {
            GameObject messageObject = messageObjects[messageTag];
            Debug.Log("Found message object: " + messageObject.name);

            // Activate the message object
            messageObject.SetActive(true);

            // Wait for 2 seconds
            yield return new WaitForSeconds(2);

            // Deactivate the message object
            messageObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Message object with tag " + messageTag + " not found");
        }

        // Activate the next level objects after the message has been displayed
        ActivateLevelObjects("Level" + currentLevel);
    }

    private void DeactivateLevelObjects(string tag)
    {
        if (levelObjects.ContainsKey(tag))
        {
            foreach (GameObject obj in levelObjects[tag])
            {
                obj.SetActive(false);  // Deactivate each object found with the specified tag
                Debug.Log("Deactivated object: " + obj.name);
            }
        }
        Debug.Log("Deactivated objects with tag: " + tag);
    }



    private void ActivateLevelObjects(string tag)
    {
        if (levelObjects.TryGetValue(tag, out List<GameObject> objects)) //assign objects to list of current level objects and return true if level exists
        {
            Debug.Log("Activating objects with tag: " + tag);
            Debug.Log("Number of objects found: " + objects.Count);

            foreach (GameObject obj in objects)
            {
                if (originalPositions.TryGetValue(obj, out Vector3 originalPos)) // sets orginalPos equal to current object's orignal position
                {
                    obj.transform.position = originalPos; // reset position
                }
                obj.SetActive(true); 
                Debug.Log("Activated object: " + obj.name);
            }
        }
        else
        {
            Debug.Log("No objects found with tag: " + tag);
        }
    }



    void InitializeGame()
    {
        Debug.Log("Game initialized.");
    }

    
    
}
