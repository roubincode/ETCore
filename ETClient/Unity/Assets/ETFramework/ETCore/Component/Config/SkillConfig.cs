namespace ETModel
{
	[Config((int)( AppType.Gate | AppType.Map))]
	public partial class SkillConfigCategory : ACategory<SkillConfig>
	{
	}

	public class SkillConfig: IConfig
	{
		public long Id { get; set; }
        public string Class ;
        public string Name ;
		public string type;

        public bool isPassive;
        public bool learnDefault;

        public int requiredLevel;
        public int maxLevel;

        public int manaCosts;
		public float castTime;
		public float cooldown;

        public int baseDamage;
        public int damage;

        public int physicalDamage;
        public int healthMaxBonus;

        public string pType;

		public float castRange;
        public bool cancelCastIfTargetDied;
        public bool followupDefaultAttack;
        public bool allowMovement;
        
        public string requiredWeaponCategory;
        public long requiredExperience;
        
        public bool showCastBar;
        
        
        public float stunChance; 
        public float stunTime;  

        public int SkillId { get; set; }
	}
}
