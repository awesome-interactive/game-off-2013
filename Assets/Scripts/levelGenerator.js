#pragma strict
	
var minDistance:float = 3;
var maxDistance:float = 5;
var speed:float = 0.1;
var blockRepositoryTarget:String = "/levelBlocks";
var blockCount:int = 5;
private var currentOffset:float = 0;
private var frameCount = 0;


function Start () {
	//add first block to scene
	var firstBlock:GameObject = Instantiate(GameObject.Find(blockRepositoryTarget + '/1'));

	//add block to level
	firstBlock.transform.parent = transform;

	//update offset
	currentOffset += getBlockWidth(firstBlock) + 1.5;

	//generate initial level
	for(var i = 0; i < 20; i++) {
		addRandomBlock();
	}
}

function Update () {
	transform.position.x -= speed;
	frameCount++;
	if(frameCount % 200 == 0) {
		addRandomBlock();
	}
}

function getBlockWidth (block:GameObject) {

	var totalWidth:float = 0;

	//loop through each component in block
	var renderers = block.GetComponentsInChildren(Renderer);
	for (var render : Renderer in renderers) {
		//chimneys don't count towards width of block
		if(render.name !== "Chimney") {
			totalWidth += render.bounds.size.x;
		}
	}
	return totalWidth;

}

function addRandomBlock () {
	//generate random block index
	var blockIndex:int = Mathf.Floor(Random.Range(1,blockCount));

	//generate random distance
	var distance:float = Random.Range(minDistance,maxDistance);

	//generate level
	addBlock(blockIndex,distance);

}

function addBlock (blockIndex:int, distance:float) {

	var newBlock:GameObject = Instantiate(GameObject.Find(blockRepositoryTarget + '/' + blockIndex));
	newBlock.transform.parent = transform;
	newBlock.transform.position.x = (currentOffset + distance) + transform.position.x;
	currentOffset += getBlockWidth(newBlock) + distance;

}