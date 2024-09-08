using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] GameObject StaticObj;
    [SerializeField] GameObject BackGround;
    Vector3 diference;
    void Start()
    {
        InvokeRepeating("CheckPosition", 0f, 0.5f);
    }

    void Update()
    {
        diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - StaticObj.transform.position;
    }

    void CheckPosition()
    {
        if (diference.x > -2 & diference.x < 2)
        {
            BackGround.transform.SetPositionAndRotation(new Vector3(10, 5, 0), Quaternion.identity);
            //Debug.Log("middle");
        }
        if (diference.x > 0)
        {            
            if (diference.x > 2 & diference.x < 5)
            {
                BackGround.transform.SetPositionAndRotation(new Vector3(9.45f, 5, 0), Quaternion.identity);
                //Debug.Log("medium right");
            }
            else if (diference.x > 5)
            {
                BackGround.transform.SetPositionAndRotation(new Vector3(8.9f, 5, 0), Quaternion.identity);
                //Debug.Log("right");
            }

        }
        else
        {
            if (diference.x < -2 & diference.x > -5)
            {
                BackGround.transform.SetPositionAndRotation(new Vector3(10.55f, 5, 0), Quaternion.identity);
                //Debug.Log("medium left");
            }
            else if (diference.x < -5)
            {
                BackGround.transform.SetPositionAndRotation(new Vector3(11.1f, 5, 0), Quaternion.identity);
                //Debug.Log("left");
            }
        }

        //Debug.Log(diference.ToString());
    }
}
