using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] GameObject StaticObj; 
    [SerializeField] GameObject BackGround; 
    [SerializeField] float smoothSpeed = 5f; 
    [SerializeField] float maxOffset = 1.1f; 

    private Vector3 targetPosition;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = BackGround.transform.position;
    }

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float differenceX = mouseWorldPos.x - StaticObj.transform.position.x;

        float normalizedDifference = Mathf.Clamp(differenceX / 5f, -1f, 1f);

        float targetX = initialPosition.x - normalizedDifference * maxOffset;
        targetPosition = new Vector3(targetX, initialPosition.y, initialPosition.z);

        BackGround.transform.position = Vector3.Lerp(
            BackGround.transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}