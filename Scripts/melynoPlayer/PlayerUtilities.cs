﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities 
{
    Player player;

    public PlayerUtilities(Player player)
    {
        this.player = player;
    }

    public void HandleInput()
    {
       player.Statistika.Direction = new Vector2( Input.GetAxisRaw("Horizontal"), player.Components.RigidBody.velocity.y);
    }
}
