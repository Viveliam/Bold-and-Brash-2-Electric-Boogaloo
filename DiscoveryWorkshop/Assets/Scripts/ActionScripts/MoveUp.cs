using UnityEngine;

public class MoveUp: Action
{
    [SerializeField] private float speed = 5;
    private bool _active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
    }

    public override void DoAction()
    {
        this._active = true;
    }
}