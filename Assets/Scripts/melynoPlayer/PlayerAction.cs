using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction 
{
   
   private Player player;
   public PlayerAction (Player player) 
   {
       this.player = player;
   }
   public void Move(Transform transform)
   {
       player.Components.RigidBody.velocity = new Vector2(player.Statistika.Direction.x * player.Statistika.Speed * Time.deltaTime,player.Statistika.Direction.y);
   }
}
