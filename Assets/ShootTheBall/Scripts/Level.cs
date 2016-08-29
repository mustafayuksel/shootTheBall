using UnityEngine;
using System.Collections;

public class Level{

	public int levelNumber;
	public Ring ring;
	public Ring ring2;
	public int ringMinSpeed;
	public int ringMaxSpeed; 
	public int ring2MinSpeed;
	public int ring2MaxSpeed;
	public int levelUpCount;
	public Level() {

	}
	public Level(int _levelNumber,Ring _ring,int _ringMinSpeed,int _ringMaxSpeed,int _levelUpCount) {
		this.levelNumber = levelNumber;
		this.ring = _ring;
		this.ringMinSpeed = _ringMinSpeed;
		this.ringMaxSpeed = _ringMaxSpeed;
		this.levelUpCount = _levelUpCount;

	}

	public Level(int _levelNumber,Ring _ring,Ring _ring2,int _ringMinSpeed,int _ringMaxSpeed,int _levelUpCount) {
		this.levelNumber = levelNumber;
		this.ring = _ring;
		this.ring2 = _ring2;
		this.ringMinSpeed = _ringMinSpeed;
		this.ringMaxSpeed = _ringMaxSpeed;
		this.levelUpCount = _levelUpCount;
			
	}

	public void setupRing() {

		this.ring.minSpeed = this.ringMinSpeed;
		this.ring.maxSpeed = this.ringMaxSpeed;
		this.ring.rotateSpeed = this.ring.minSpeed;
		if (ring2 != null) {
			this.ring2.minSpeed = ring2MinSpeed;
			this.ring2.maxSpeed = ring2MaxSpeed;
			this.ring2.rotateSpeed = ring2MinSpeed;
		}
	}


}
