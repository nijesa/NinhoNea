using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliderCollission : MonoBehaviour
{
    public GenerateCoin gc;
    [SerializeField] bool canPress = true;
    [SerializeField] bool good;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moving"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (good)
                {
                    gc.ParentFails--;
                }
                else
                {
                    gc.ParentFails++;
                }
                
                
                 
            }
            
        }  
    }
    IEnumerator countSlider()
    {
        
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Can Press");
        canPress = true;

    }
}
