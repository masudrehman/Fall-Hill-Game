using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ToPlayScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score; 
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game Over") {
            score.text = (GameManager.score).ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void PlayGame() {
        GameManager.score = 0;
        Initiate.Fade("Play", Color.black, 1f);
        // SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }
}
