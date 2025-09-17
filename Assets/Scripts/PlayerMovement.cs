using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 50f;
    [SerializeField] private float xClampRange  = 30f;
    [SerializeField] private float yClampRange  = 30f;
    
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

        float rawXPOS = transform.localPosition.x + xOffset;
        float rawYPOS = transform.localPosition.y + yOffset;

        float clampedXPOS = Mathf.Clamp(rawXPOS, -xClampRange, xClampRange);
        float clampedYPOS = Mathf.Clamp(rawYPOS, -yClampRange, yClampRange);
        
        transform.localPosition = new Vector3(clampedXPOS,clampedYPOS,0f);
    }
}
