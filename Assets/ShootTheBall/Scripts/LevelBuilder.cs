﻿using UnityEngine;
using System.Collections;

public class LevelBuilder {

	public Level level;


	public LevelBuilder setLevelNumber(int levelNumber) {
		this.level.levelNumber = levelNumber;
		return this;
	}

	public LevelBuilder setRing1(Ring ring) {

		this.level.ring = ring;
		return this;
	}
	public LevelBuilder setRing1MinSpeed(int ringMinSpeed) {

		this.level.ringMinSpeed = ringMinSpeed;
		return this;
	}
	public LevelBuilder setRing1MaxSpeed(int ringMaxSpeed) {
		this.level.ringMaxSpeed = ringMaxSpeed;
		this.level.ring.rotateSpeed = this.level.ringMinSpeed;
		return this;
	}
	public LevelBuilder setLevel(Level level) {

		this.level = level;
		return  this;
	}
	public LevelBuilder setRing2(Ring ring2) {

		this.level.ring2 = ring2;
		return this;
	}
	public LevelBuilder setRing2MinSpeed(int speed) {
		this.level.ring2MinSpeed = speed;
		return this;
	}

	public LevelBuilder setRing2MaxSpeed(int speed) {
		this.level.ring2MaxSpeed = speed;
		return this;
	}
	public LevelBuilder setLevelUpCount(int levelUpCount) {
		this.level.levelUpCount = levelUpCount;
		return this;
	}

	public Level build() {
		return this.level;
	}

}
