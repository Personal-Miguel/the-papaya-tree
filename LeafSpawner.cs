using UnityEngine;
using Random = System.Random;

public class LeafSpawner : MonoBehaviour
{
    private Random rand;
    private float elapsed = 0;

    private void Start()
    {
        rand = new Random();
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1.0f)
        {
            elapsed %= 1.0f;
            SpawnLeaf();
        }
        DestroyUnseenLeaves();
    }

    private void SpawnLeaf()
    {
        var position = new Vector3(transform.position.x + rand.Next(-7, 17), transform.position.y);
        var leaf = GameObject.Find("Leaf");
        Instantiate(leaf, position, Quaternion.identity);
    }


    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    private void DestroyUnseenLeaves()
    {
        var mainChar = GameObject.Find(MAIN_CHAR_NAME);
        var mainCharPos = mainChar.transform.position;

        var clone = GameObject.Find("Leaf(Clone)");
        if(clone?.transform.position.y < 1 || clone?.transform.position.y < mainCharPos.y - 15)
        {
            Destroy(clone);
        }
    }
}
