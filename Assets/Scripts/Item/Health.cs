using UnityEngine;

public class Heart : item
{
   

    public override void Use(Player player)
    {
        if (player)
        {
            player.Heal(ItemValue);
            Destroy(this.gameObject);
        }
    }

}
