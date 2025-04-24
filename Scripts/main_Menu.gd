extends Node

func _StartGame():
	get_tree().change_scene_to_file("res://Scenes/Levels/MainLevel.tscn")
	

func _ExitGame():
	get_tree().quit()
