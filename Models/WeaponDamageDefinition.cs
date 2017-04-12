namespace Turbo.Plugins.Jack.Models
{
    public class WeaponDamageDefinition
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Aps { get; set; }
        public int BaseMin { get; set; }
        public int BaseMax { get; set; }
        public int BonusMinMin { get; set; }
        public int BonusMinMax { get; set; }
        public int BonusMaxMin { get; set; }
        public int BonusMaxMax { get; set; }
        public int BonusAncientMinMin { get; set; }
        public int BonusAncientMinMax { get; set; }
        public int BonusAncientMaxMin { get; set; }
        public int BonusAncientMaxMax { get; set; }
    }
}