using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTarget : MonoBehaviour
{
    public Bullet bullet;

    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("Rise");
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetTrigger("Fall");
        }
    }
    
}
