using UnityEngine;

public class EXP : item
{
    public override void Use(Player player)
    {
        if (player)
        {
            //player.PlusExp(ItemValue);
            player.AddExp(ItemValue);
            Destroy(this.gameObject);
            
        }
    }
}
