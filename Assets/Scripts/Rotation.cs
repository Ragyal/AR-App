using UnityEngine;

public class Rotation : MonoBehaviour
{

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        this.transform.Rotate(new Vector3(0, 10*Time.deltaTime, 0), Space.World);
	}
}
