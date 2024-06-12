using UnityEngine;

public class Follow : MonoBehaviour
{
    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    private readonly (float, float, float) CAM_OFFSET = (0f, 2.5f, -10f);

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
