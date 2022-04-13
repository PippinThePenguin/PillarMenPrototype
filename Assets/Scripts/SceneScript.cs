using UnityEngine;

public class SceneScript : MonoBehaviour
{
    public Transform WayPoint;
    public Vector3 MiddlePoint;
    public bool IsEmpty = false;    
    [SerializeField] private Transform EnemiesParent;    
    [SerializeField]private int enemiesCount;    
    void Start()
    {
        CountThem();
    }
    private void CountThem()
    {
        enemiesCount = 0;
        if (EnemiesParent != null)        
            foreach (Transform enemy in EnemiesParent)            
                enemiesCount++;                    
        CheckForEmpty();
        CalculateMiddle(gameObject);
    }
    private void CalculateMiddle(GameObject obj)
    {
        if (!IsEmpty)
        {
            Vector3 sum = new Vector3();
            foreach (Transform enemy in EnemiesParent)            
                if (enemy.GetComponent<EnemyScript>().Alive)                
                    sum += enemy.position;                                                                  
            sum = sum / enemiesCount;
            MiddlePoint = sum;
        }
        else
            MiddlePoint = Vector3.zero;
    }
    public void GotOne(GameObject obj)
    {
        enemiesCount--;
        CheckForEmpty();
        CalculateMiddle(obj);
    }
    private void CheckForEmpty()
    {
        if (enemiesCount <= 0)        
            IsEmpty = true;        
        else        
            IsEmpty = false;        
    }
}
