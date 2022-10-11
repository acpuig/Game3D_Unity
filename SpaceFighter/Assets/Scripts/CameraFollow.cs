using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform CamTransform;
    public Transform Player;
    private float followspeed = 2f; //Espai entre la mida de la pantalla i el joc

    // Start is called before the first frame update
    void Start()
    {
        CamTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 targetPosition = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);
       CamTransform.position = Vector3.Lerp(CamTransform.position, targetPosition, Time.deltaTime * followspeed);
    }

    /*
    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1f));
    }*/
}
