using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    [Header("Drag your Weapon GameObjects here")]
    public GameObject handGunObject;
    public GameObject Spreadgun;
    public GameObject Lasergun;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        float currentSpeed = Mathf.Clamp01(movement.magnitude);

        _animator.SetFloat("Speed", currentSpeed);

        if (handGunObject != null)
        {
            _animator.SetBool("handgun", handGunObject.activeInHierarchy);
        }

        if (Spreadgun != null)
        {
            _animator.SetBool("Spreadgun", Spreadgun.activeInHierarchy);
        }

        if (Lasergun != null)
        {
            _animator.SetBool("lasergun", Lasergun.activeInHierarchy);
        }
    }
}