public class Vital : ModifiedStat
{

	private int _curVale;

	public Vital ()
	{
		_curVale = 0;
		ExpToLevel = 50;
		LevelModifier = 1.1f;
	}

	public int CurValue {
		get {
			if (_curVale > AdjustedBaseValue)
				_curVale = AdjustedBaseValue;

			return _curVale;
		}
		set{ _curVale = value; }
	}
	 
}

public enum VitalName
{

	Health,
	Mana
}
