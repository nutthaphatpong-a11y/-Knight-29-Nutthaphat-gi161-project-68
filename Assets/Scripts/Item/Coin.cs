using UnityEngine;

public class Coin : item
{
    public override void Use(Player player)
    {
        if (player)
        {
            player.AddCoin(ItemValue);
            Destroy(this.gameObject);
        }
    }

}
