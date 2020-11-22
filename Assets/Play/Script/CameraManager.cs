using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    private Vector3 targetPosition;

    public Vector3 center;
    public Vector3 size;

    float height;
    float width;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    void LateUpdate()
    {
        if(target.gameObject != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);

            float Ix = size.x * 0.5f - width;
            float clampX = Mathf.Clamp(transform.position.x, -Ix + center.x, Ix + center.x);
            float Iz = size.z * 0.5f - height;
            float clampZ = Mathf.Clamp(transform.position.z, -Iz + center.z, Iz + center.z);
            transform.position = new Vector3(clampX, 100, clampZ);

            transform.position = new Vector3(transform.position.x, 100, transform.position.z);
        }
        //

        //if (A.activeSelf)
        //{
        //    transform.position = Vector3.Lerp(transform.position, AT.position, 3f * Time.deltaTime);
        //    transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동
        //}
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
