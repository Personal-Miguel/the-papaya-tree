using UnityEngine;

public class FixedBg : MonoBehaviour
{
    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    private readonly (int, int, int) CAM_OFFSET = (0, 3, 0);

    private void Update()
    {
        var mainChar = GameObject.Find(MAIN_CHAR_NAME);
        var mainCharPos = mainChar.transform.position;

        transform.position = new Vector3(
            CAM_OFFSET.Item1,
            mainCharPos.y + CAM_OFFSET.Item2,
            mainCharPos.z + CAM_OFFSET.Item3
        );
    }
}
