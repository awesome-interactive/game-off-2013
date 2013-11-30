#pragma strict

public var scrollSpeed:float = 0.1;

private var spriteSize:float = 0;
private var currentShift:int = 1;
private var travelDistance:float = 0;
private var groupName:String;

function Start () {
	groupName = transform.name;
	spriteSize = gameObject.Find(groupName + '/1').renderer.bounds.size.x;
}

function Update () {
	transform.position.x -= scrollSpeed;
	travelDistance += scrollSpeed;
	if(travelDistance >= spriteSize) {
		gameObject.Find(groupName + '/' + currentShift.ToString()).transform.position.x += (3 * spriteSize);
		currentShift++;
		if(currentShift > 3) {
			currentShift = 1;
		}
		travelDistance = 0;
	}
}