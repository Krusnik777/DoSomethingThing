using CodeBase.Configs;

namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerProgress
    {
        public WeaponConfig EquippedWeapon;
        public int HealthPoints;
        public int CurrentDay;

        public PlayerProgress()
        {
            EquippedWeapon = null;
            HealthPoints = 3;
            CurrentDay = 1;
        }
    }
}
