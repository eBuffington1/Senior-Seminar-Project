extends Control

var test = 5

func _ready() -> void:
	pass

func _DamageTest():
	print("button test")

func _ModifyHealth(currentHealth: int):
	get_node("Label").text = "Health: " + str(currentHealth)

func _slideInHealth():
	$AnimationPlayer.play("PlayerUI/HPSlidesIn")
