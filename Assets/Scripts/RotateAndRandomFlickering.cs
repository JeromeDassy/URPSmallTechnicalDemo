using UnityEngine;

public class RotateAndRandomFlickering : MonoBehaviour
{
    MeshRenderer mr => GetComponent<MeshRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.01f, 0);
        //mr.enabled = RandomEnable();//No time to do better and this just hurt eyes, but wuld be nice to have a better smoother and more controlled transition
    }

    private bool RandomEnable()
    {
        int i = Random.Range(0, 101);
        if(i < 25)
            return false;
        else
            return true;
    }
}
