using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    [SerializeField] private Transform[] players;
    private float minX, maxX, minY, maxY;
    [SerializeField] private float yOffset;

    [SerializeField] private float maxScreenX, minScreenY, minScreenX, maxScreenY;

    private void LateUpdate()
    {
        minX = maxX = players[0].position.x;
        minY=maxY = players[0].position.y;

        if (minX > players[1].position.x)
        {
            minX = players[1].position.x;
        }

        if (maxX < players[1].position.x)
        {
            maxX = players[1].position.x;
        }

        if (minY > players[1].position.y)
        {
            minY = players[1].position.y;
        }

        if (maxY < players[1].position.y)
        {
            maxY = players[1].position.y;
        }

        float xMiddle = (maxX + minX) / 2;
        float yMiddle = (maxY + minY) / 2;

        if (xMiddle > maxScreenX) 
            xMiddle = maxScreenX;
        if (yMiddle > maxScreenY)
            yMiddle = maxScreenY;
        if(xMiddle < minScreenX)
            xMiddle = minScreenX;
        if (yMiddle < minScreenY)
            yMiddle = minScreenY;

        transform.position = new Vector2(xMiddle, yMiddle + yOffset);
    }
}
