using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]private Transform start;
    [SerializeField]private Pooler pool;
    [SerializeField] private LayerMask layers;
    void Start()
    {
        InputEvents.OnClickEvent += TapHandler;        
    }
    private void Shoot(Vector3 point)
    {
        pool.GetNextBullet(point, start.position);        
    }

    private void TapHandler(Touch touch)
    {       
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;         
        if (Physics.Raycast(ray, out hit,layers))
            Shoot(hit.point);
    }
}
