using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
      _numSeedsLeft = 5;
      _numSeedsPlanted = 0;
      _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
    }

    private void Update()
    {   
        Vector3 CurrentPosition = transform.position;
        //define CurrentPisition as the place where Player object now is
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                CurrentPosition.y += _speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                CurrentPosition.y -= _speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                CurrentPosition.x -= _speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                CurrentPosition.x += _speed * Time.deltaTime;
            }
        if (Input.GetKeyDown(KeyCode.Space))
            {
                PlantSeed();
            }
        //when player press the button, make Player Object move by _speed * deltaTime
        transform.position = CurrentPosition;
        //send back the position changes to Value CurrenPosition
    }

    public void PlantSeed ()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _numSeedsLeft > 0)
            {   
                 Debug.Log("PlantSeed called"); 
                Instantiate(_plantPrefab, transform.position, Quaternion.identity);
                _numSeedsLeft -= 1;
                _numSeedsPlanted +=1;
                _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
               
            }
    }
}
