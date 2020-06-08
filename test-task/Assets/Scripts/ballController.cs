using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ballController : MonoBehaviour, IPointerDownHandler
{
  public static Vector2 CurrentPositionToMove { private set; get; }
  public static float speed = 7;
  [SerializeField]private Transform _ball;
  private Queue<Vector2> _positionsToMove = new Queue<Vector2>();

  private void FixedUpdate()
  {
    MoveBall();
    SetCurrentPosition();
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    _positionsToMove.Enqueue(Camera.main.ScreenToWorldPoint(eventData.position));
  }

  private void SetCurrentPosition()
  {
    if(_ball.position.x == CurrentPositionToMove.x && _ball.position.y == CurrentPositionToMove.y)
    {
      if(_positionsToMove.Any())
        CurrentPositionToMove = _positionsToMove.Dequeue();
    }
  }

  private void MoveBall()
  {
    _ball.position = Vector3.MoveTowards(_ball.position, CurrentPositionToMove, speed * Time.deltaTime);
  }

}
