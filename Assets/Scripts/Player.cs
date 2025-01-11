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
        if(Input.GetKey(KeyCode.W))
            {
                CurrentPosition.y += _speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.S))
            {
                CurrentPosition.y -= _speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.A))
            {
                CurrentPosition.x -= _speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.D))
            {
                CurrentPosition.x += _speed * Time.deltaTime;
            }
        //when player press the button, make Player Object move by _speed * deltaTime
        transform.position = CurrentPosition;
        //send back the position changes to Value CurrenPosition
    }

    public void PlantSeed ()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _numSeedsLeft > 0)
            {
                Instantiate(_plantPrefab, transform.position, Quaternion.identity);
                _numSeedsLeft -= 1;
                _numSeedsPlanted +=1;
                _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
                Debug.Log($"PlantSeed called. Seeds Left: {_numSeedsLeft}, Seeds Planted: {_numSeedsPlanted}");
            }
    }
}
