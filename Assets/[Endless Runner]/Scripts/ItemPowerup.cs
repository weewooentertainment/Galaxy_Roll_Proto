using UnityEngine;

namespace EndlessRunner
{
    [AddComponentMenu("CUSTOM / Item Powerup")]
    public class ItemPowerup : ItemBase
    {
        public override int HitPoints { get { return 200; } }

        public override void Reset()
        {
            transform.localPosition = new Vector3(Random.Range(-5f, 5f), 0, 0);
        }

        protected override void OnCollisionEnter(Collision collision)
        {
            if (collision.IsPlayer())
            {
				GlobalVariables.Player.ActivateDoubleJumpAbility();

                Hide();

                SoundManager.PlaySoundEffect("SpecialItemHit");

                GameDirector.AddScore(HitPoints);
            }
        }
    }
}