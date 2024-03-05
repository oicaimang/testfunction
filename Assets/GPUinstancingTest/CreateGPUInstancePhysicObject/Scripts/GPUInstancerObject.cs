using UnityEngine;

public class GPUInstancerObject : MonoBehaviour
{
    // Start is called before the first frame update
    protected bool _isTransformSet;
    protected Transform _instanceTransform;
    void Start()
    {

    }

    public virtual Transform GetInstanceTransform(bool forceNew = false)
    {
        if (!_isTransformSet || forceNew)
        {
            _instanceTransform = transform;
            _isTransformSet = true;
        }
        return _instanceTransform;
    }
}
