using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    float obstacleHeight, obstacleWidth, playerWidth, playerHeight;
    float areaWidth, areaHeight;
    public int maxAmount = 5;
    int currentAmount = 0;

    List<GameObject> obstacles = new List<GameObject>();

    void Start()
    {
        Debug.Log(Camera.main.orthographicSize * 2f * Camera.main.aspect);
        // Alto y ancho del srpite del obstáculo desde el centro
        obstacleHeight = obstacle.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        obstacleWidth = obstacle.GetComponent<SpriteRenderer>().bounds.size.x / 2;

        // Límites laterales y superior del área de generación de obstáculos
        areaWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        areaHeight = GetComponent<BoxCollider2D>().bounds.center.y - GetComponent<BoxCollider2D>().bounds.extents.y;

        // Alto y ancho del sprite del player
        playerWidth = player.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
        playerHeight = player.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y;

        // Creamos el primer obstáculo en una posición aleatoria
        Vector3 obstaclePos;
        do
        {
            obstaclePos = new Vector3(gameObject.transform.position.x + Random.Range(-areaWidth + obstacleWidth, areaWidth - obstacleWidth),
                    gameObject.transform.position.y + Random.Range(-(Camera.main.orthographicSize - obstacleHeight), areaHeight - obstacleHeight), 0);
        } while (obstaclePos.x < Camera.main.orthographicSize * 2f * Camera.main.aspect); // Se repite hasta que se cree fuera de la cámara

        obstacles.Add(Instantiate(obstacle, obstaclePos, Quaternion.identity, gameObject.transform));
        currentAmount++;

        while (currentAmount < maxAmount) // Hasta generar el máximo de objetos en la zona
        {
            // Generar una posición aleatoria para el obstáculo dentro de los límites preestablecidos usando las medidas calculadas
            // anteriormente y la posición actual de la zona
            obstaclePos = new Vector3(gameObject.transform.position.x + Random.Range(-areaWidth + obstacleWidth, areaWidth - obstacleWidth), 
                gameObject.transform.position.y + Random.Range(-(Camera.main.orthographicSize - obstacleHeight), areaHeight - obstacleHeight), 0);

            // Si la posición está por detrás de la cámara se descarta el obstáculo directamente
            if (obstaclePos.x > Camera.main.orthographicSize * 2f * Camera.main.aspect)
            {
                bool create = true;
                // Se comprueba que el objeto no solape con los obstáculos ya creados y deje siempre un hueco suficiente 
                // para que el jugador pueda pasar. Si no se cumple, se descarta el obstáculo y se genera otro
                foreach (var createdObstacle in obstacles)
                {
                    if (Mathf.Abs(createdObstacle.transform.position.x - obstaclePos.x) < playerWidth &&
                        Mathf.Abs(createdObstacle.transform.position.y - obstaclePos.y) < playerHeight)
                    {
                        create = false;
                        break;
                    }
                }

                if (create)
                {
                    obstacles.Add(Instantiate(obstacle, obstaclePos, Quaternion.identity, gameObject.transform));
                    currentAmount++;
                }
            }
        }
    }
}
