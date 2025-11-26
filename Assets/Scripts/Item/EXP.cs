using UnityEngine;

public class EXP : item
{
    public override void Use(Player player)
    {
        if (player)
        {
            player.PlusExp(ItemValue);
            Destroy(this.gameObject);
        }
    }
}
