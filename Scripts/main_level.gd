extends Node2D

@export_subgroup("Boss Phases")
var _phase01 = preload("res://Scenes/BossPhases/phase_01.tscn")

func StartFight(body: Node2D) -> void:
	$PreFight/PreFight.play("Phases/SetupZone")
	$bossTimelinePlayer.play("bossTimelines/bossSeminar")
	$MusicPlayer.play()

func CleanPreFight() -> void:
	$PreFight.queue_free()

func Phase01() -> void:
	
	var instance = _phase01.instantiate()
	add_child(instance)
