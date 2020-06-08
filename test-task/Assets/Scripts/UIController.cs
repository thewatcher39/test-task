using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
  [SerializeField]private Slider _speedSlider;

  private void Start()
  {
    _speedSlider.value = ballController.speed;
  }

  public void SlideSpeed()
  {
    ballController.speed = _speedSlider.value;
  }
}
