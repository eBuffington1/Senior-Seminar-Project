extends Node

func endPhase() -> void:
	queue_free()

func deleteExclamation() -> void:
	$"Exclamation Mark".queue_free()
