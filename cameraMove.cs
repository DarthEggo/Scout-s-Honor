
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follow;
    

    public static float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Start()
    {
        follow = GameObject.Find("Scout");
        
    }
    void LateUpdate()
    {
        transform.position = follow.transform.position + offset;
    }

}
  
