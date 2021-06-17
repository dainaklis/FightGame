using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

// -------------------------------------------------------------------------
    [SerializeField]
    private PlayerStats statistika;

    public PlayerStats Statistika 
    {  get 
        {
            return statistika;
        }
    
    }

// --------------------------------------------------------------------

    [SerializeField]
    private PlayerComponents components;
    private PlayerReference reference;
    private PlayerUtilities utilities;
    private PlayerAction action;

// -----------------------------------------------------------------------------------

    public PlayerComponents Components 
    { 
        get 
        {
            return components;
        }
        
    }

// ---------------------------------------------------------------------------------
    private void Awake() 
    {
        action = new PlayerAction(this);
        utilities = new PlayerUtilities(this);

        statistika.Speed = statistika.WalkSpeed;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        utilities.HandleInput();


    }

    private void FixedUpdate() 
    {
        action.Move(transform);

    }
}
