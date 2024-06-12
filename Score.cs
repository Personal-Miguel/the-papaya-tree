using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    public TextMeshProUGUI score;


    void Update()
    {
        var mainChar = GameObject.Find(MAIN_CHAR_NAME);
        var mainCharPos = mainChar.transform.position;
        score.text = ((int) mainCharPos.y + 3).ToString() + 'm';
    }
}
