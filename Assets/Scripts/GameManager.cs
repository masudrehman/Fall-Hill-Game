using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Player player;
    public bool gameOver;
    public bool gameRunning;
    public static int score;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindObjectOfType<Player>();
        StartCoroutine(Score());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            Initiate.Fade("Game Over", Color.black, 1f);
            // SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        
    }


    IEnumerator Score() {
        while(!gameOver) {
            score += 1;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

   
}
