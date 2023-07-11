using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTarget : MonoBehaviour
{
    public Bell bell;
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
        if (bell.timer == 0)
        {
            _animator.SetTrigger("Idle");
        }
        else if (Random.value > 0.8f && bell.duration != bell.timer)
        {
            _animator.SetTrigger("Rise");  
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetTrigger("Fall");
            Debug.Log("Puntaje: " + bell.score);
            bell.score += 1;
        }
    }


}
