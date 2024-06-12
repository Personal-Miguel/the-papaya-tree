using UnityEngine;

public class BoundaryCheck : MonoBehaviour
{
    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    private readonly (float, float) BOUNDARIES = (-10, 10);

    private void Update()
    {
        var mainChar = GameObject.Find(MAIN_CHAR_NAME);
        var mainCharPos = mainChar.transform.position;

        if (mainCharPos.x < BOUNDARIES.Item1)
        {
            transform.position = new Vector3(BOUNDARIES.Item1, mainCharPos.y, mainCharPos.z);
        }
        else if (mainCharPos.x > BOUNDARIES.Item2)
        {
            transform.position = new Vector3(BOUNDARIES.Item2, mainCharPos.y, mainCharPos.z);
        }
    }
}
