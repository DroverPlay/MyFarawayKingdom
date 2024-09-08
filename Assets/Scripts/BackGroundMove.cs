using System.Collections;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] GameObject StaticObj;
    [SerializeField] GameObject BackGround;
    Vector3 diference;
    public float acceleration = 0.1f;
    public float startPosition = 10f;
    public float maxPosition = 11.1f;
    public float minPosition = 8.9f;
    private float currentPosition;

    void Start()
    {
        InvokeRepeating("CheckPosition", 0f, 0.5f);
        StartCoroutine(IncreaseObjectSpeed());
    }

    void Update()
    {
        currentPosition = startPosition;
        diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - StaticObj.transform.position;
    }
    private IEnumerator IncreaseObjectSpeed()
    {
        while (currentPosition < maxPosition)
        {
            currentPosition += acceleration * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
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
                //currentPosition = BackGround.transform.position.x;
                //BackGround.transform.SetPositionAndRotation(new Vector3(currentPosition - 0.05f, 5, 0), Quaternion.identity);
                BackGround.transform.SetPositionAndRotation(new Vector3(9.45f, 5, 0), Quaternion.identity);
                //Debug.Log("medium right");
            }
            else if (diference.x > 5)
            {
                //currentPosition = BackGround.transform.position.x;
                //BackGround.transform.SetPositionAndRotation(new Vector3(currentPosition - 0.05f, 5, 0), Quaternion.identity);
                BackGround.transform.SetPositionAndRotation(new Vector3(8.9f , 5, 0), Quaternion.identity);
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
