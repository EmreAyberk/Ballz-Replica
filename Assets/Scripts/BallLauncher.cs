using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private BlockSpawner blockSpawner;
    private LaunhPreview launhPreview;
    
    private List<Ball> balls = new List<Ball>();

    [SerializeField] private Ball ballPrefab;
    private int ballsReady;

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        launhPreview = GetComponent<LaunhPreview>();
        launhPreview.SetStartPoint(transform.position);
        launhPreview.SetEndPoint(transform.position);

        CreateBall();
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab,transform.position,Quaternion.identity);
        balls.Add(ball);
        ballsReady++;
    }

    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)+ Vector3.back * -10;
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        StartCoroutine(LaunhBalls());
        
    }

    private IEnumerator LaunhBalls()
    {
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
        
        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);
            yield return new WaitForSeconds(0.1f);
        }

        ballsReady = 0;
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endPosition = worldPosition;
        var direction = endPosition - startPosition;
        
        launhPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startPosition = worldPosition;
        launhPreview.SetStartPoint(transform.position);
    }

    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == balls.Count)
        {
            blockSpawner.SpawnRowOfBlocks();
            CreateBall();
        }
    }
}
