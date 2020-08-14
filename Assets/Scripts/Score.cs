using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreValue = 0;
    Text score;
    
    [Tooltip("Points to win")]
    [SerializeField] public int MaxScore = 11;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score != null) { 
            score.text = scoreValue.ToString();
        }
    }
}
