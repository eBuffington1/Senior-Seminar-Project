extends Node

func _input(event):
	if event.is_action_pressed("ResetLevel"):
		get_tree().change_scene_to_file("res://Scenes/Levels/MainLevel.tscn")
