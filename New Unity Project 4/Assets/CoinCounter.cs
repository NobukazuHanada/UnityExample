using System;

public class CoinCounter  {
	private int counts;
	private static CoinCounter coinCounter;

	private CoinCounter(){
		this.counts = 0;
	}

	public static CoinCounter getInstance(){
		if(CoinCounter.coinCounter == null){
			CoinCounter.coinCounter = new CoinCounter();
		}
		return CoinCounter.coinCounter;
	}

	public int Count
	{
		get{ return this.counts; }
	}

	public void add(){
		this.counts++;
	}
}
