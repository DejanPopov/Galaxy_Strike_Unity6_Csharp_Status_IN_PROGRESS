using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 50f;
    
    private Vector2 _movement;
    
    void Update()
    {
        ProcessTranslation();
    }
    public void OnMove(InputValue value)
    {
        _movement = (value.Get<Vector2>());
    }
    
    private void ProcessTranslation()
    {
        float xOffset = _movement.x * controlSpeed * Time.deltaTime;
        float yOffset = _movement.y * controlSpeed * Time.deltaTime;
        
        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, 
                                              transform.localPosition.y + yOffset, 
                                              0f);
    }


}
