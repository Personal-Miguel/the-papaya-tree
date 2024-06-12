using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    public TextMeshProUGUI score;
    int highScore = 0;

    void Update()
    {
        var mainChar = GameObject.Find(MAIN_CHAR_NAME);
        var mainCharPos = mainChar.transform.position;

        
        if(mainCharPos.y > highScore)
        {
            highScore = (int) mainCharPos.y + 3;
        }

        score.text = "Highest: " + highScore.ToString() + 'm';
    }
}
